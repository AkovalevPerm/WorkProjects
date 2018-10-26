namespace Synchronization.SyncAdapter.Tests
{
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ServiceBus.ObjectMessageModel;
    using System.Linq;
    using System.Xml;
    using Utils;

    [TestClass]
    public class SynchronizationTest
    {
        #region FromTU

        [TestMethod]
        public void TestToMsrFromTUResponseSerializeMethod()
        {
            var testMsg = SynchronizationTestHelper.GetToMsrFromTUMessage();

            var xmlStringMsg = SerializationTools.SerializeDataContract(testMsg);
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.LoadXml(xmlStringMsg);
            xmlCurrentDoc.DocumentElement?.SetAttribute("xmlns", "http://eais.com/tomsrfromtu.xsd");
            xmlCurrentDoc.Save($"{Context.XMLMessagePath}{ToMsrFromTUResponse.NameForESB}.xml");

            var xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.Load($"{Context.XMLMessagePath}{ToMsrFromTUResponse.NameForESB}Template.xml");

            Assert.AreEqual(xmlCurrentDoc.OuterXml, xmlTemplateDoc.OuterXml);
        }

        [TestMethod]
        public void TestToMsrFromTUResponseDeserializeMethod()
        {
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.Load($"{Context.XMLMessagePath}{ToMsrFromTUResponse.NameForESB}.xml");

            var messageObj =
                SerializationTools.DeserialiseDataContract<ToMsrFromTUResponse>(xmlCurrentDoc.OuterXml);
            var originalMessageObj = SynchronizationTestHelper.GetToMsrFromTUMessage();

            Assert.AreEqual(messageObj.RequestInfo, originalMessageObj.RequestInfo);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.Beneficiary?.Guid,
                originalMessageObj.Items.FirstOrDefault()?.Beneficiary?.Guid);
            Assert.AreEqual(messageObj.Items.LastOrDefault()?.ChlenSemi.Guid,
                originalMessageObj.Items.LastOrDefault()?.ChlenSemi.Guid);
        }

        [TestMethod]
        public void TestToMsrFromTUResponseCheckXSD()
        {
            XMLTools.CheckXMLFromFiletoXSD($"{Context.XMLMessagePath}{ToMsrFromTUResponse.NameForESB}.xml",
                $"{Context.XSDSchemasPath}{ToMsrFromTUResponse.NameForESB}.xsd");
        }

        #endregion

        #region Catalog

        [TestMethod]
        public void TestToMsrFromReestrMspCatalogDataSerializeMethod()
        {
            var testMsg = SynchronizationTestHelper.GetToMsrFromReestrMspCatalogDataMessage();

            var xmlStringMsg = testMsg.Serialize(true);
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.LoadXml(xmlStringMsg);
            xmlCurrentDoc.Save($"{Context.XMLMessagePath}{ToMsrFromReestrMspCatalogDataChanges.NameForESB}.xml");

            var xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.Load($"{Context.XMLMessagePath}{ToMsrFromReestrMspCatalogDataChanges.NameForESB}Template.xml");

            Assert.AreEqual(xmlCurrentDoc.OuterXml, xmlTemplateDoc.OuterXml);
        }

        [TestMethod]
        public void TestToMsrFromReestrMspCatalogDataDeserializeMethod()
        {
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.Load($"{Context.XMLMessagePath}{ToMsrFromReestrMspCatalogDataChanges.NameForESB}.xml");

            var messageObj =
                SerializationTools
                    .DeserialiseDataContract<ToMsrFromReestrMspCatalogDataChanges>(xmlCurrentDoc.OuterXml);
            var originalMessageObj = SynchronizationTestHelper.GetToMsrFromReestrMspCatalogDataMessage();

            Assert.AreEqual(messageObj.RequestInfo, originalMessageObj.RequestInfo);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.Classifier.Guid,
                originalMessageObj.Items.FirstOrDefault()?.Classifier.Guid);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.Classifier.Category.Name,
                originalMessageObj.Items.FirstOrDefault()?.Classifier.Category.Name);
        }

        [TestMethod]
        public void TestToMsrFromReestrMspCatalogDataCheckXSD()
        {
            XMLTools.CheckXMLFromFiletoXSD(
                $"{Context.XMLMessagePath}{ToMsrFromReestrMspCatalogDataChanges.NameForESB}.xml",
                $"{Context.XSDSchemasPath}{ToMsrFromReestrMspCatalogDataChanges.NameForESB}.xsd");
        }

        [TestMethod]
        public void TestToMsrFromReestrMspCatalogItemsResponseSerializeMethod()
        {
            var testMsg = SynchronizationTestHelper.GetToMsrFromReestrMspCatalogItemsResponseMessage();

            var xmlStringMsg = testMsg.Serialize(true);
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.LoadXml(xmlStringMsg);
            xmlCurrentDoc.Save($"{Context.XMLMessagePath}{ToMsrFromReestrMspCatalogItemsResponse.NameForESB}.xml");

            var xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.Load(
                $"{Context.XMLMessagePath}{ToMsrFromReestrMspCatalogItemsResponse.NameForESB}Template.xml");

            Assert.AreEqual(xmlCurrentDoc.OuterXml, xmlTemplateDoc.OuterXml);
        }

        [TestMethod]
        public void TestToMsrFromReestrMspCatalogItemsResponseDeserializeMethod()
        {
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.Load($"{Context.XMLMessagePath}{ToMsrFromReestrMspCatalogItemsResponse.NameForESB}.xml");

            var messageObj =
                SerializationTools.DeserialiseDataContract<ToMsrFromReestrMspCatalogItemsResponse>(xmlCurrentDoc
                    .OuterXml);
            var originalMessageObj = SynchronizationTestHelper.GetToMsrFromReestrMspCatalogItemsResponseMessage();

            Assert.AreEqual(messageObj.RequestInfo, originalMessageObj.RequestInfo);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.Classifier.Guid,
                originalMessageObj.Items.FirstOrDefault()?.Classifier.Guid);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.Classifier.Category.Name,
                originalMessageObj.Items.FirstOrDefault()?.Classifier.Category.Name);
        }

        #endregion

        #region DataChanges

        [TestMethod]
        public void TestToReestrMspFromMsrDataChangesSerializeMethod()
        {
            var testMsg = SynchronizationTestHelper.GetToReestrMspFromMsrDataChangesMessage();

            var xmlStringMsg = testMsg.Serialize(true);
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.LoadXml(xmlStringMsg);
            xmlCurrentDoc.Save($"{Context.XMLMessagePath}{ToReestrMspFromMsrDataChanges.NameForESB}.xml");

            var xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.Load($"{Context.XMLMessagePath}{ToReestrMspFromMsrDataChanges.NameForESB}Template.xml");

            Assert.AreEqual(xmlCurrentDoc.OuterXml, xmlTemplateDoc.OuterXml);
        }

        [TestMethod]
        public void TestToReestrMspFromMsrDataChangesDeserializeMethod()
        {
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.Load($"{Context.XMLMessagePath}{ToReestrMspFromMsrDataChanges.NameForESB}.xml");

            var messageObj =
                SerializationTools.DeserialiseDataContract<ToReestrMspFromMsrDataChanges>(xmlCurrentDoc.OuterXml);
            var originalMessageObj = SynchronizationTestHelper.GetToReestrMspFromMsrDataChangesMessage();

            Assert.AreEqual(messageObj.RequestInfo, originalMessageObj.RequestInfo);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.Beneficiary.Registration.Guid,
                originalMessageObj.Items.FirstOrDefault()?.Beneficiary.Registration.Guid);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.Beneficiary.Location.Street.Territory.FIAS,
                originalMessageObj.Items.FirstOrDefault()?.Beneficiary.Location.Street.Territory.FIAS);
        }

        [TestMethod]
        public void TestToReestrMspFromMsrDataChangesCheckXSD()
        {
            XMLTools.CheckXMLFromFiletoXSD($"{Context.XMLMessagePath}{ToReestrMspFromMsrDataChanges.NameForESB}.xml",
                $"{Context.XSDSchemasPath}{ToReestrMspFromMsrDataChanges.NameForESB}.xsd");
        }

        #endregion

        #region RequestToReestrMSP

        [TestMethod]
        public void TestToReestrMspFromMsrCatalogItemsRequestSerializeMethod()
        {
            var testMsg = SynchronizationTestHelper.GetToReestrMspFromMsrCatalogItemsRequestMessage();

            var xmlStringMsg = testMsg.Serialize(true);
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.LoadXml(xmlStringMsg);
            xmlCurrentDoc.Save($"{Context.XMLMessagePath}{ToReestrMspFromMsrCatalogItemsRequest.NameForESB}.xml");

            var xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.Load($"{Context.XMLMessagePath}{ToReestrMspFromMsrCatalogItemsRequest.NameForESB}.xml");

            Assert.AreEqual(xmlCurrentDoc.OuterXml, xmlTemplateDoc.OuterXml);
        }

        [TestMethod]
        public void TestToReestrMspFromMsrCatalogItemsRequestDeserializeMethod()
        {
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.Load($"{Context.XMLMessagePath}{ToReestrMspFromMsrCatalogItemsRequest.NameForESB}.xml");
            
            var messageObj =
                SerializationTools.DeserialiseDataContract<ToReestrMspFromMsrCatalogItemsRequest>(xmlCurrentDoc.OuterXml);
            var originalMessageObj = SynchronizationTestHelper.GetToReestrMspFromMsrCatalogItemsRequestMessage();

            //TODO поправить по аналогии с TestToMsrFromReestrMspCatalogDataDeserializeMethod
            //Assert.IsFalse(message == null);
            Assert.AreEqual(messageObj.RequestInfo, originalMessageObj.RequestInfo);
            Assert.AreEqual(messageObj.Criteria.Type, originalMessageObj.Criteria.Type);

            for (int i = 0; i < messageObj.Criteria.Condition.Length; i++)
            {
                Assert.AreEqual(messageObj.Criteria.Condition[i].Attribute, originalMessageObj.Criteria.Condition[i].Attribute);
                Assert.AreEqual(messageObj.Criteria.Condition[i].Operator, originalMessageObj.Criteria.Condition[i].Operator);
                Assert.AreEqual(messageObj.Criteria.Condition[i].Value, originalMessageObj.Criteria.Condition[i].Value);
            }
          
            Assert.AreEqual(messageObj.Criteria.Criteria, originalMessageObj.Criteria.Criteria);
            Assert.AreEqual(messageObj.Sorting, originalMessageObj.Sorting);
            Assert.AreEqual(messageObj.Type, originalMessageObj.Type);
        }

        [TestMethod]
        public void TestToReestrMspFromMsrCatalogItemsRequestCheckXSD()
        {
            XMLTools.CheckXMLFromFiletoXSD($"{Context.XMLMessagePath}{ToReestrMspFromMsrCatalogItemsRequest.NameForESB}.xml",
                $"{Context.XSDSchemasPath}{ToReestrMspFromMsrCatalogItemsRequest.NameForESB}.xsd");
        }

        #endregion

        #region FIAS

        [TestMethod]
        public void TestToMsrFromReestrMspFiasDataSerializeMethod()
        {
            var testMsg = SynchronizationTestHelper.GetToMsrFromReestrMspFiasDataChangesMessage();

            var xmlStringMsg = testMsg.Serialize(true);
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.LoadXml(xmlStringMsg);
            xmlCurrentDoc.Save($"{Context.XMLMessagePath}{ToMsrFromReestrMspFiasDataChanges.NameForESB}.xml");

            var xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.Load($"{Context.XMLMessagePath}{ToMsrFromReestrMspFiasDataChanges.NameForESB}Template.xml");

            Assert.AreEqual(xmlCurrentDoc.OuterXml, xmlTemplateDoc.OuterXml);
        }


        [TestMethod]
        public void TestToMsrFromReestrMspFiasDataDeserializeMethod()
        {
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.Load($"{Context.XMLMessagePath}{ToMsrFromReestrMspFiasDataChanges.NameForESB}.xml");

            var messageObj =
                SerializationTools.DeserialiseDataContract<ToMsrFromReestrMspFiasDataChanges>(xmlCurrentDoc.OuterXml);
            var originalMessageObj = SynchronizationTestHelper.GetToMsrFromReestrMspFiasDataChangesMessage();

            Assert.AreEqual(messageObj.RequestInfo, originalMessageObj.RequestInfo);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.FiasAddressObjects.AOGUID,
                originalMessageObj.Items.FirstOrDefault()?.FiasAddressObjects.AOGUID);
            Assert.AreEqual(messageObj.Items.LastOrDefault()?.FiasHousesStructures.AOGUID,
                originalMessageObj.Items.LastOrDefault()?.FiasHousesStructures.AOGUID);
        }

        [TestMethod]
        public void TestToMsrFromReestrMspFiasDataCheckXSD()
        {
            XMLTools.CheckXMLFromFiletoXSD($"{Context.XMLMessagePath}{ToMsrFromReestrMspFiasDataChanges.NameForESB}.xml",
                $"{Context.XSDSchemasPath}{ToMsrFromReestrMspFiasDataChanges.NameForESB}.xsd");
        }

        [TestMethod]
        public void TestToMsrFromReestrMspFiasItemsResponseSerializeMethod()
        {
            var testMsg = SynchronizationTestHelper.GetToMsrFromReestrMspFiasItemsMessage();

            var xmlStringMsg = testMsg.Serialize(true);
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.LoadXml(xmlStringMsg);
            xmlCurrentDoc.Save($"{Context.XMLMessagePath}{ToMsrFromReestrMspFiasItemsResponse.NameForESB}.xml");

            var xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.Load($"{Context.XMLMessagePath}{ToMsrFromReestrMspFiasItemsResponse.NameForESB}Template.xml");

            Assert.AreEqual(xmlCurrentDoc.OuterXml, xmlTemplateDoc.OuterXml);
        }


        [TestMethod]
        public void TestToMsrFromReestrMspFiasItemsResponseDeserializeMethod()
        {
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.Load($"{Context.XMLMessagePath}{ToMsrFromReestrMspFiasItemsResponse.NameForESB}.xml");

            var messageObj =
                SerializationTools.DeserialiseDataContract<ToMsrFromReestrMspFiasItemsResponse>(xmlCurrentDoc.OuterXml);
            var originalMessageObj = SynchronizationTestHelper.GetToMsrFromReestrMspFiasItemsMessage();

            Assert.AreEqual(messageObj.RequestInfo, originalMessageObj.RequestInfo);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.FiasAddressObjects.AOGUID,
                originalMessageObj.Items.FirstOrDefault()?.FiasAddressObjects.AOGUID);
            Assert.AreEqual(messageObj.Items.LastOrDefault()?.FiasHousesStructures.AOGUID,
                originalMessageObj.Items.LastOrDefault()?.FiasHousesStructures.AOGUID);
        }

        [TestMethod]
        public void TestToMsrFromReestrMspFiasItemsResponseCheckXSD()
        {
            XMLTools.CheckXMLFromFiletoXSD($"{Context.XMLMessagePath}{ToMsrFromReestrMspFiasItemsResponse.NameForESB}.xml",
                $"{Context.XSDSchemasPath}{ToMsrFromReestrMspFiasItemsResponse.NameForESB}.xsd");
        }

        #endregion

        #region MergeItems

        [TestMethod]
        public void TestToMsrFromReestrMspMergeItemsSerializeMethod()
        {
            var testMsg = SynchronizationTestHelper.GetToMsrFromReestrMspMergeItemsMessage();

            var xmlStringMsg = testMsg.Serialize(true);
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.LoadXml(xmlStringMsg);
            xmlCurrentDoc.Save($"{Context.XMLMessagePath}{ToMsrFromReestrMspMergedItemsResponse.NameForESB}.xml");

            var xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.Load($"{Context.XMLMessagePath}{ToMsrFromReestrMspMergedItemsResponse.NameForESB}Template.xml");

            Assert.AreEqual(xmlCurrentDoc.OuterXml, xmlTemplateDoc.OuterXml);
        }

        [TestMethod]
        public void TestToMsrFromReestrMspMergedItemsResponseDeserializeMethod()
        {
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.Load($"{Context.XMLMessagePath}{ToMsrFromReestrMspMergedItemsResponse.NameForESB}.xml");

            var messageObj =
                SerializationTools.DeserialiseDataContract<ToMsrFromReestrMspMergedItemsResponse>(
                    xmlCurrentDoc.OuterXml);
            var originalMessageObj = SynchronizationTestHelper.GetToMsrFromReestrMspMergeItemsMessage();

            Assert.AreEqual(messageObj.RequestInfo, originalMessageObj.RequestInfo);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.Beneficiary?.Guid,
                originalMessageObj.Items.FirstOrDefault()?.Beneficiary?.Guid);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.Sources.FirstOrDefault()?.Key,
                originalMessageObj.Items.FirstOrDefault()?.Sources.FirstOrDefault()?.Key);
        }

        [TestMethod]
        public void TestToMsrFromReestrMspMergedItemsResponseCheckXSD()
        {
            XMLTools.CheckXMLFromFiletoXSD($"{Context.XMLMessagePath}{ToMsrFromReestrMspMergedItemsResponse.NameForESB}.xml",
                $"{Context.XSDSchemasPath}{ToMsrFromReestrMspMergedItemsResponse.NameForESB}.xsd");
        }

        #endregion

        #region ToTUFromMSR

        [TestMethod]
        public void TestToTUFromMSRResponseSerializeMethod()
        {
            var testMsg = SynchronizationTestHelper.GetToTUFromMsrResponseMessage();

            string xmlStringMsg = testMsg.Serialize(true);
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.LoadXml(xmlStringMsg);
            xmlCurrentDoc.Save($"{Context.XMLMessagePath}{ToTUFromMsrResponse.NameForESB}.xml");

            var xmlTemplateDoc = new XmlDocument();
            xmlTemplateDoc.Load($"{Context.XMLMessagePath}{ToTUFromMsrResponse.NameForESB}Template.xml");

            Assert.AreEqual(xmlCurrentDoc.OuterXml, xmlTemplateDoc.OuterXml);
        }

        [TestMethod]
        public void TestToTUFromMSRResponseDeserializeMethod()
        {
            var xmlCurrentDoc = new XmlDocument();
            xmlCurrentDoc.Load($"{Context.XMLMessagePath}{ToTUFromMsrResponse.NameForESB}.xml");

            var messageObj =
                SerializationTools.DeserialiseDataContract<ToTUFromMsrResponse>(xmlCurrentDoc.OuterXml);
            var originalMessageObj = SynchronizationTestHelper.GetToTUFromMsrResponseMessage();

            Assert.AreEqual(messageObj.RequestInfo, originalMessageObj.RequestInfo);
            Assert.AreEqual(messageObj.Items.FirstOrDefault()?.Territory?.Guid,
                originalMessageObj.Items.FirstOrDefault()?.Territory?.Guid);
            Assert.AreEqual(messageObj.Items.LastOrDefault()?.TypeDocument?.Guid,
                originalMessageObj.Items.LastOrDefault()?.TypeDocument?.Guid);
        }

        [TestMethod]
        public void TestToTUFromMSRResponseCheckXSD()
        {
            XMLTools.CheckXMLFromFiletoXSD($"{Context.XMLMessagePath}{ToTUFromMsrResponse.NameForESB}.xml",
                $"{Context.XSDSchemasPath}{ToTUFromMsrResponse.NameForESB}.xsd");
        }

        #endregion
    }
}