namespace SyncAdapterService.Utils
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    ///     Класс для сериализации/десериализации объектов в XML для передачи в сообщениях для шины.
    /// </summary>
    public static class SerializationTools
    {
        private const string XmlDeclarationSh = "&lt;?xml version=\"1.0\" encoding=\"UTF-8\"?&gt;";
        private const string XmlDeclaration = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

        public static string SerializeDataContract<T>(T dataObj)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (var strWriter = new StringWriter())
            using (var xmlWriter = new XmlTextWriter(strWriter))
            using (var dicWriter = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter))
            {
                serializer.WriteObject(dicWriter, dataObj, new UniversalDataContractResolver());
                return strWriter.ToString();
            }
        }

        public static string SerializeWithXmlSerializer<T>(T dataObj)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var ms = new MemoryStream())
            using (var xmlWriter = new XmlTextWriter(ms, Encoding.UTF8))
            {
                serializer.Serialize(xmlWriter, dataObj);
                ms.Position = 0;
                using (var sr = new StreamReader(ms))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        /// <summary>
        ///     Метод для десериализации объекта.
        /// </summary>
        /// <param name="type"> Тип объекта который хотим получить.</param>
        /// <param name="dataStr"> Строка с сериализованным значением объекта.</param>
        /// <param name="clearXMLNamespace"> Очистить xml-namespace из строки dataStr.</param> 
        public static object DeserialiseDataContract(Type type, string dataStr, bool clearXMLNamespace = true)
        {
            object result = null;
            MethodInfo method = typeof(SerializationTools).GetMethod(
                nameof(DeserialiseDataContract),
                BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly,
                null,
                CallingConventions.Any,
                new[] { typeof(string), typeof(bool) },
                null);
            if (method != null)
            {
                MethodInfo generic = method.MakeGenericMethod(type);
                result = generic.Invoke(null, new object[] { dataStr, clearXMLNamespace });
            }

            return result;
        }

        /// <summary>
        ///     Метод для десериализации объекта.
        /// </summary>
        /// <typeparam name="T"> Тип объекта который хотим получить.</typeparam>
        /// <param name="dataStr"> Строка с сериализованным значением объекта.</param>
        /// <param name="clearXMLNamespace"> Очистить xml-namespace из строки dataStr.</param>
        /// <returns></returns>
        public static T DeserialiseDataContract<T>(string dataStr, bool clearXMLNamespace = true)
        {
            object result = null;
            if (!string.IsNullOrEmpty(dataStr))
            {
                if (clearXMLNamespace)
                {
                    dataStr = XMLTools.ClearAllXmlNameSpace(dataStr);
                }

                var serializer = new DataContractSerializer(typeof(T));
                using (var strReader = new StringReader(dataStr))
                using (var xmlReader = new XmlTextReader(strReader))
                using (var dicReader = XmlDictionaryReader.CreateDictionaryReader(xmlReader))
                {
                    result = serializer.ReadObject(dicReader, false, new UniversalDataContractResolver());
                }
            }

            return (T) result;

        }

        public static T DeserializeFromXml<T>(XmlDocument doc)
        {
            try
            {
                using (var reader = XmlReader.Create(new StringReader(doc.OuterXml)))
                {
                    reader.MoveToContent();
                    return (T) new XmlSerializer(typeof(T)).Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Десериализация строки \"{doc.InnerXml}\" в тип \"{typeof(T).FullName}\" невозможна.", ex);
            }
        }

        public static string PrepareMessageToParseInXmlDoc(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return message;

            var splitted = message.Split(new[] {XmlDeclaration}, StringSplitOptions.None);
            if (splitted.Length > 2)
            {
                message = splitted[0] + XmlDeclaration;
                message = splitted.Skip(1).Take(splitted.Length - 2)
                    .Aggregate(message, (current, s) => current + s + XmlDeclarationSh);
                message += splitted.Last();
            }

            return message;
        }

        private class UniversalDataContractResolver : DataContractResolver
        {
            private readonly XmlDictionary dictionary = new XmlDictionary();

            public override Type ResolveName(string typeName, string typeNamespace, Type declaredType,
                DataContractResolver knownTypeResolver)
            {
                var type = knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null);
                if (type == null) type = Type.GetType(typeName + ", " + typeNamespace);
                return type;
            }

            public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver,
                out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
            {
                var resolved =
                    knownTypeResolver.TryResolveType(type, declaredType, null, out typeName, out typeNamespace);
                if (!resolved)
                {
                    typeName = dictionary.Add(type.FullName);
                    typeNamespace = dictionary.Add(type.Assembly.FullName);
                    return true;
                }

                return resolved;
            }
        }
    }
}