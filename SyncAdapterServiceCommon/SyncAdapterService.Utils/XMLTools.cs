namespace SyncAdapterService.Utils
{
    using System;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Schema;

    public static class XMLTools
    {
        /// <summary>
        ///     Метод получение XSD-схемы из указанной XML.
        /// </summary>
        /// <param name="XMLpathIn">Путь до XML</param>
        /// <param name="XSDpathOut">Путь куда сохранять полученные XSD-схемы. Должен содержать расширение .xsd</param>
        public static void GetXSDFromXML(string XMLpathIn, string XSDpathOut)
        {
            if (!string.IsNullOrEmpty(XMLpathIn))
            {
                using (var reader = XmlReader.Create(XMLpathIn))
                {
                    var schema = new XmlSchemaInference();
                    var schemaSet = schema.InferSchema(reader);

                    if (!string.IsNullOrEmpty(XSDpathOut))
                    {
                        int i = 0;
                        int insertIndex = XSDpathOut.IndexOf(".xsd", StringComparison.CurrentCulture);
                        foreach (XmlSchema s in schemaSet.Schemas())
                        {
                            var path = XSDpathOut.Insert(insertIndex, $"_{i++}");
                            using (var writer = XmlWriter.Create(path))
                            {
                                s.Write(writer);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Метод получение XSD-схемы из указанного класса.
        /// </summary>
        /// <typeparam name="T">Тип, для которого нужно создать схему.</typeparam>
        /// <param name="XSDpathOut">Путь куда сохранять полученные XSD-схемы. Должен содержать расширение .xsd</param>
        public static void GetXSDFromClassModel<T>(string XSDpathOut)
        {
            var exporter = new XsdDataContractExporter();
            if (exporter.CanExport(typeof(T)))
            {
                exporter.Export(typeof(T));
                var schemaSet = exporter.Schemas;

                if (!string.IsNullOrEmpty(XSDpathOut))
                {
                    int i = 0;
                    int insertIndex = XSDpathOut.IndexOf(".xsd", StringComparison.CurrentCulture);
                    foreach (XmlSchema s in schemaSet.Schemas())
                    {
                        var path = XSDpathOut.Insert(insertIndex, $"_{i++}");
                        using (var writer = XmlWriter.Create(path))
                        {
                            s.Write(writer);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Метод, который проверяет что заданный XML соответствует заданной XSD схеме.
        /// </summary>
        /// <param name="XMLpathIn">Путь до XML</param>
        /// <param name="XSDpathIn">Путь до XSD</param>
        /// <returns></returns>
        public static bool CheckXMLFromFiletoXSD(string XMLpathIn, string XSDpathIn)
        {
            var settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.Schema
            };
            settings.Schemas.Add(null, XSDpathIn);
            settings.ValidationType = ValidationType.Schema;

            using (var reader = XmlReader.Create(XMLpathIn, settings))
            {
                var document = new XmlDocument();
                document.Load(reader);
                document.Validate((s, e) =>
                {
                    if (e.Severity == XmlSeverityType.Error)
                    {
                        throw new XmlSchemaValidationException(e.Message);
                    }
                });

            }

            return true;
        }

        /// <summary>
        ///     Метод, который удаляет из XML-строки все namespace xmlns и xsi.
        /// </summary>
        /// <param name="XMLMessage"></param>
        /// <returns></returns>
        public static string ClearAllXmlNameSpace(string XMLMessage)
        {
            var strXMLPattern = @"xmlns(:\w+)?=""([^""]+)""|xsi(:\w+)?=""([^""]+)""";
            return Regex.Replace(XMLMessage, strXMLPattern, "");
        }

        /// <summary>
        ///     Метод, который проверяет что заданный XML соответствует заданной XSD схеме.
        /// </summary>
        /// <param name="xml">XML-строка</param>
        /// <param name="XSDpathIn">Путь до XSD</param>
        /// <returns></returns>
        public static bool CheckXMLFromStringtoXSD(string xml, string XSDpathIn)
        {
            XmlDocument doc = new  XmlDocument();
            doc.Schemas.Add(null, XSDpathIn);
            doc.LoadXml(xml);
            doc.Validate((s, e) =>
            {
                if (e.Severity == XmlSeverityType.Error)
                {
                    throw new XmlSchemaValidationException($"Не пройдена валидация XSD схемой: {e.Message}");
                }
            });

            return true;
        }
    }
}