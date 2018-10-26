namespace SyncAdapterService.BusListener
{
    using System;
    using System.IO;
    using System.ServiceModel;
    using System.Web;
    using System.Xml.Schema;
    using CustomException;
    using ICSSoft.STORMNET;
    using NewPlatform.Flexberry.HighwaySB;
    using NewPlatform.Flexberry.HighwaySB.ClientTools;
    using Utils;
    using XMLMessageModel.Interface;

    /// <summary>
    ///     Класс, обрабатвыающий вызовы от шины по интерфейсу <see cref="ICallbackSubscriber" />.
    /// </summary>
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class CallbackSubscriber : ICallbackSubscriber
    {
        private const string MessageErrorHeader =
            "BusListenerService: Ошибка при попытке сохранить полученное сообщение!";

        /// <summary>
        ///     Принять сообщение из шины.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        public void AcceptMessage([MessageParameter(Name = "msg")] MessageFromESB message)
        {
            LogService.LogInfo($"BusListenerService: Принял соообщение - {message.MessageTypeID}!");

            // Ищем в конфиг файле, привязку между типов сообщения и xml-классом этого сообщения.
            var xmlClassName = Context.GetMessageXMLClassNameByMessageID(message.MessageTypeID);
            if (!string.IsNullOrEmpty(xmlClassName))
            {
                // Получаем тип по названию класса из конфиг файла.
                var messageType = Type.GetType(xmlClassName);
                if (messageType != null)
                {
                    try
                    {
                        ICommonMessage messageObj = null;
                        if (!string.IsNullOrEmpty(message.Body))
                        {
                            // Проверка валидация по XSD-схеме полученного xml.
                            if (Context.EnableXSDValidation)
                            {
                                var pathToXSD = Path.Combine(HttpRuntime.AppDomainAppPath,
                                    $"{Context.XSDSchemasPath}{message.MessageTypeID}.xsd");
                                if (File.Exists(pathToXSD))
                                {
                                    XMLTools.CheckXMLFromStringtoXSD(message.Body, pathToXSD);
                                }
                                else
                                {
                                    LogService.LogWarn(
                                        $"BusListenerService: При получении сообщения включена проверка валидности сообщения XSD-схеме, но XSD-схема для сообщения типа {message.MessageTypeID} не найдена!{Environment.NewLine} Путь для ожидаемой XSD-схемы - {pathToXSD}");
                                }
                            }

                            // Десериализуем сообщение для его сохранения.
                            messageObj =
                                SerializationTools.DeserialiseDataContract(messageType, message.Body) as ICommonMessage;
                        }

                        if (messageObj != null)
                        {
                            // Сохранение сообщения в SyncLogItem.
                            messageObj.Save(message.SenderName, message.Body, true);
                        }
                        else
                        {
                            LogService.LogWarn(
                                $"BusListenerService: Получено пустое сообщение типа {message.MessageTypeID}. Сообщение не будет сохранено в БД!");
                        }
                    }
                    catch (XmlSchemaValidationException ex)
                    {
                        LogService.LogError(
                            $"{MessageErrorHeader} Не пройдена валидация XSD-схемы для сообщения типа {message.MessageTypeID}",
                            ex);
                        throw;
                    }
                    catch (Exception ex)
                    {
                        LogService.LogError($"{MessageErrorHeader}", ex);
                        throw;
                    }
                }
                else
                {
                    var errorMessage =
                        $"{MessageErrorHeader} Не найден XML-класс типа сообщения с названием {xmlClassName}";
                    LogService.LogError(errorMessage);
                    throw new InvalidOperationException(errorMessage);
                }
            }
            else
            {
                var errorMessage =
                    $"{MessageErrorHeader} Неизвестный тип сообщения - {message.MessageTypeID}. Проверьте настройки секции {Context.CustomSBListenerConfigSectionName} в конфигурационном файле.";
                LogService.LogError(errorMessage);
                throw new UnknowMessageTypeException(errorMessage);
            }
        }

        /// <summary>
        ///     Получить идентификатор клиента.
        /// </summary>
        /// <returns>Идентификатор клиента (для межшинного взаимодействия).</returns>
        public string GetSourceId()
        {
            return Context.AppName;
        }

        /// <summary>
        ///     Получить уведомление о событии из шины.
        /// </summary>
        /// <param name="eventTypeId">Идентификатор типа события.</param>
        public void RiseEvent([MessageParameter(Name = "ИдТипаСобытия")]
            string eventTypeId)
        {
            LogService.LogWarn(
                "BusListenerService: обнаружена попытка вызвать событие, для которого не предусмотрена обработка!");
        }
    }
}