namespace Synchronization.Utils
{
    using ICSSoft.STORMNET;
    using Synchronization.Utils.CustomException;

    using System;
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;
    using System.Web;
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
        ///     Метод, который проверяет что XML по заданному пути соответствует заданной XSD.
        /// </summary>
        /// <param name="XMLpathIn">Путь до XML</param>
        /// <param name="XSDpathIn">Путь до XSD</param>
        /// <returns></returns>
        public static bool CheckXMLFromFiletoXSD(string XMLpathIn, string XSDpathIn)
        {
            if (File.Exists(XSDpathIn))
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
            }
            else
            {
                throw new XSDExistenceException(XSDpathIn);
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
        ///     Метод, который проверяет что заданный XML соответствует заданной XSD.
        /// </summary>
        /// <param name="XMLstring">XML-строка</param>
        /// <param name="XSDpathIn">Путь до XSD</param>
        /// <returns></returns>
        public static bool CheckXMLtoXSD(string XMLstring, string XSDpathIn, bool throwXSDExistenceException = false)
        {
            if (File.Exists(XSDpathIn))
            {
                XmlDocument doc = new XmlDocument();
                doc.Schemas.Add(null, XSDpathIn);
                doc.LoadXml(XMLstring);
                doc.Validate((s, e) =>
                {
                    if (e.Severity == XmlSeverityType.Error)
                    {
                        throw new XmlSchemaValidationException(e.Message);
                    }
                });
            }
            else
            {
                if (throwXSDExistenceException)
                {
                    throw new XSDExistenceException(XSDpathIn);
                }
            }

            return true;
        }
               
    }
}