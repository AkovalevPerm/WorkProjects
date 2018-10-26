namespace BusMessageHandler.MessageHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    using Configuration;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.LINQProvider;
    using IIS.Synchronizer;
    using IIS.Synchronizer.Services;
    using IIS.University.Tools;
    using Interface;
    using Mappers.XMLtoAPP;
    using ServiceBus.ObjectDataModel.Common;
    using ServiceBus.ObjectDataModel.Common.Attribute;
    using ServiceBus.ObjectDataModel.Common.Interfaces;
    using ServiceBus.ObjectMessageModel.Common.Interfaces;
    using Synchronization.Objects;
    using Synchronization.Utils;

    public class DefaultDataChangeMessageHandler:IDataMessageHandler
    {
        /// <summary>
        ///     Сервис данных по умолчанию.
        /// </summary>
        private SQLDataService _defDS { get; }

        /// <summary>
        ///     Сервис данных для бд синхронизации.
        /// </summary>
        private SQLDataService _syncDS { get; }

        private readonly string sObjectType = typeof(ObjectType).FullName;
        private readonly string sSource = typeof(Source).FullName;
        private readonly string sConformity = typeof(Conformity).FullName;

        public DefaultDataChangeMessageHandler(IDataService appDS, IDataService syncDS)
        {
            _defDS = (SQLDataService)appDS;
            _syncDS = (SQLDataService)syncDS;
        }

        /// <summary>
        ///     Обработать сообщение.
        /// </summary>
        /// <param name="logItem">Сообщение из журнала синхронизации.</param>
        public void HandleDataChangeMessage<TMessage, TItem>(SyncLogItem logItem)
            where TMessage : IDataChangeMessageResponse<TItem>
            where TItem : IChangedItem
        {
            if (!string.IsNullOrEmpty(logItem.DataSet))
            {
                var doc = new XmlDocument();
                doc.LoadXml(logItem.DataSet);

                var xmlClassName = Settings.GetMessageClassTypeName(logItem.Description);
                if (!string.IsNullOrEmpty(xmlClassName))
                {
                    // Получаем тип по названию класса из конфиг файла.
                    var messageType = Type.GetType(xmlClassName);
                    if (messageType != null)
                    {
                        TMessage response;
                        try
                        {
                            response =
                                SerializationTools.DeserialiseDataContract<TMessage>(logItem.DataSet);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(
                                $"Ошибка десерилизации объекта SyncLogItem.Pk = {logItem.__PrimaryKey}, тип ToMsrFromTUResponse.", ex);
                        }

                        if (response?.Items == null)
                        {
                            LogService.LogWarnFormat(
                                "В сообщениии SyncLogItem.Pk = {0}, отсутствуют объекты для обработки.",
                                logItem.__PrimaryKey);
                            return;
                        }

                        var arrToUpdate = new List<DataObject>();
                        var arrConformity = new Dictionary<string, List<DataObject>>
                        {
                            { sObjectType, new List<DataObject>() },
                            { sSource, new List<DataObject>() },
                            { sConformity, new List<DataObject>() }
                        };

                        Source source = null;
                        try
                        {
                            source = _syncDS.Query<Source>(Source.Views.SourceE)
                                .FirstOrDefault(x => x.name == logItem.DataSource);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(
                                $"Произошла ошибка при вычитке источника из БД Source.Name = '{logItem.DataSource}'.", ex);
                        }

                        if (source == null)
                        {
                            source = new Source {name = logItem.DataSource};
                            arrConformity[sSource].Add(source);
                        }

                        foreach (var item in response.Items)
                        {
                            var obj = GetXMLDataObjInChangedItem(item);
                            //Получаем настройки для обработки типа сообщения.
                            GetSyncSettings(obj, out var destType, out var mapper);
                            ProcessObject(obj, item.State, destType, mapper,
                                item.СhangedAttributes?.Select(x => x.Name).ToList(), source, ref arrToUpdate,
                                ref arrConformity);
                        }

                        var listSync = new List<DataObject>();
                        listSync.AddRange(arrConformity[sObjectType]);
                        listSync.AddRange(arrConformity[sSource]);
                        var objectsDef = arrToUpdate.ToArray();
                        var objectsSync = listSync.ToArray();

                        try
                        {
                            _defDS.UpdateObjectsOrdered(ref objectsDef);

                            _syncDS.UpdateObjects(ref objectsSync);
                            objectsSync = arrConformity[sConformity].ToArray();
                            _syncDS.UpdateObjects(ref objectsSync);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Произошла ошибка при сохранении объектов в БД. {ex.InnerException?.Message ?? ex.Message}");
                        }
                    }
                    else
                    {
                        var errorMessage = $" Не найден XML-класс типа сообщения с названием {xmlClassName}";
                        throw new InvalidOperationException(errorMessage);
                    }
                }
                else
                {
                    var errorMessage =
                        $"Незаполнен тип xml-класса, для сообщения {logItem.Description}. Проверьте настройки секции messageHandlers в конфигурационном файле.";
                    throw new Exception(errorMessage);
                }
            }
        }

        private SyncXMLDataObject GetXMLDataObjInChangedItem(IChangedItem item)
        {
            SyncXMLDataObject obj = null;
            var itemType = item.GetType();
            var objProperties = itemType.GetProperties();
            foreach (var property in objProperties)
            {
                if (property.GetCustomAttribute<XMLDataFieldType>() != null)
                {
                    obj = property.GetValue(item) as SyncXMLDataObject;
                    if (obj != null)
                    {
                        break;
                    }
                }
            }

            return obj;
        }

        /// <summary>
        ///     Обработка объекта
        /// </summary>
        /// <param name="obj">объект, который пришел</param>
        /// <param name="state">тип изменения, входящего объекта</param>
        /// <param name="type">тип объекта, в который преобразуем</param>
        /// <param name="mapper">маппер для преобразования</param>
        /// <param name="attrs">список изменяемых свойств</param>
        /// <param name="source">Источник изменений</param>
        /// <param name="arrToUpd">Список обновляемых объектов данных</param>
        /// <param name="arrConformity">Список обновляемых объектов синхронизации</param>
        private void ProcessObject(SyncXMLDataObject obj, tState state, Type type,
            IPropertyMapperWithChangedAttrs mapper, List<string> attrs, Source source, ref List<DataObject> arrToUpd,
            ref Dictionary<string, List<DataObject>> arrConformity)
        {
            if (obj == null)
            {
                return;
            }

            var view = mapper.GetView();
            var nameType = type.FullName;

            var otype = arrConformity[sObjectType].Cast<ObjectType>().FirstOrDefault(x => x.name == nameType) ??
                        _syncDS.Query<ObjectType>(ObjectType.Views.ObjectTypeE)
                            .FirstOrDefault(x => x.name == nameType) ??
                        new ObjectType {name = nameType, id = type.Name};
            if (otype.GetStatus() == ObjectStatus.Created)
            {
                arrConformity[sObjectType].Add(otype);
            }

            Conformity conformity = null;

            if (otype.GetStatus() != ObjectStatus.Created && source.GetStatus() != ObjectStatus.Created)
            {
                conformity = _syncDS.Query<Conformity>(Conformity.Views.ConformityE).FirstOrDefault(x =>
                    x.Source.__PrimaryKey.Equals(source.__PrimaryKey)
                    && x.Type.__PrimaryKey.Equals(otype.__PrimaryKey) && x.pkSource.Equals(obj.Guid));
            }

            if (state != tState.deleted) //создание/изменение
            {
                DataObject dest = null;
                if (conformity != null) //ищем по pk
                {
                    dest = GetDataObject(type, view, conformity.pkDest);
                }
                else
                {
                    dest = GetDataObject(type, view, obj.Guid);
                }

                if (dest == null) //ищем по альтернативному ключу
                {
                    var queryAlt = mapper.GetAltKey(obj, _defDS, _syncDS, source, ref arrToUpd, ref arrConformity);
                    dest = queryAlt?.FirstOrDefault();

                    if (queryAlt != null && dest != null)
                    {
                        LogService.LogInfo($"BusMessageHandlerService: Удалось найти объект(pk-{obj.Guid}) по альтернативному ключу для типа {nameType}. Сопоставленный объект объект(pk-{dest.__PrimaryKey})");
                    }
                }

                if (dest == null)
                {
                    dest = (DataObject) Activator.CreateInstance(type);
                }

                dest.GetStatus();

                dest = mapper.Map(obj, dest, attrs);

                // Проверяем было ли помещено создание объекта на апдейт. Если да, то такой объект уже считается существующим и статус нового объекта с таким же ключом меняется на Altered.
                var alreadyExistsCreatedObj = arrToUpd.Exists(x => PKHelper.EQPK(x, dest) && x.GetStatus(false)==ObjectStatus.Created);
                if (alreadyExistsCreatedObj)
                {
                    dest.SetLoadingState(LoadingState.Loaded);
                    dest.SetStatus(ObjectStatus.Altered);
                }
                arrToUpd.Add(dest);
                //заполнение мастеров///////////////////////////////////////////////////////////////////////////////
                mapper.SetMasters(obj, dest, attrs, _defDS, _syncDS, source, ref arrToUpd, ref arrConformity);
                if (conformity == null)
                {
                    conformity = new Conformity
                    {
                        Source = source,
                        Type = otype,
                        pkSource = obj.Guid,
                        pkDest = new Guid(dest.__PrimaryKey.ToString())
                    };
                    arrConformity[sConformity].Add(conformity);
                }
            }
            else //удаление
            {
                if (conformity != null)
                {
                    var count = _syncDS.Query<Conformity>(Conformity.Views.ConformityE).Count(x =>
                        x.Type.__PrimaryKey.Equals(otype.__PrimaryKey)
                        && x.pkDest.Equals(conformity.pkDest));
                    if (count >= 1)
                    {
                        conformity.SetStatus(ObjectStatus.Deleted);
                        arrConformity[sConformity].Add(conformity);
                    }

                    if (count == 1)
                    {
                        var dest = GetDataObject(type, view, conformity.pkDest);
                        if (dest != null)
                        {
                            dest.SetStatus(ObjectStatus.Deleted);
                            arrToUpd.Add(dest);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Получить настройки по входящему типу.
        /// </summary>
        /// <param name="source">входящий объект</param>
        /// <param name="destType">Тип объекта, который был изменён.</param>
        /// <param name="mapper">Маппер для объекта, который был изменён.</param>
        private void GetSyncSettings(ISync source, out Type destType, out IPropertyMapperWithChangedAttrs mapper)
        {
            SyncSetting setting = null;
            destType = null;
            mapper = null;
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            try
            {
                setting = SettingService.Current.GetSettings(source).First();
                destType = setting.Destination.ExtractType();
                mapper = setting.ExtractMapper<IPropertyMapperWithChangedAttrs>();
            }
            catch (Exception ex)
            {
                var text = "Ошибка: не удалось";
                if (setting == null)
                {
                    text = $"{text} загрузить настройки SyncSettings для входящего типа = {source.GetType().FullName}.";
                }
                else if (destType == null)
                {
                    text = $"{text} получить исходящий тип из настройки SyncSettings.PK - {setting.__PrimaryKey}.";
                }
                else if (mapper == null)
                {
                    text = $"{text} получить маппер из настройки SyncSettings.PK - {setting.__PrimaryKey}.";
                }

                throw new Exception($"{text}{Environment.NewLine}{ex.Message}");
            }
        }

        /// <summary>
        ///     Получить объект по первичному ключу
        /// </summary>
        /// <param name="type"></param>
        /// <param name="view"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        private DataObject GetDataObject(Type type, View view, Guid primaryKey)
        {
            var lcs = LoadingCustomizationStruct.GetSimpleStruct(type, view);
            lcs.LimitFunction = FunctionBuilder.BuildEquals(primaryKey);
            lcs.ReturnTop = 1;
            DataObject dobj = null;
            try
            {
                dobj = _defDS.LoadObjects(lcs).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при вычитке объекта из БД, Тип = {type.FullName}, Pk = '{primaryKey.ToString()}'", ex);
            }

            return dobj;
        }
    }
}