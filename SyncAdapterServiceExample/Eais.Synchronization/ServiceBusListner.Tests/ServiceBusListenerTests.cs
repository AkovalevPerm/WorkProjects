namespace ServiceBusListner.Tests
{
    using System;
    using System.IO;
    using System.Web;
    using System.Xml;
    using FakeHttpContext;
    using ICSSoft.STORMNET;
    using ICSSoft.STORMNET.Business;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using NewPlatform.Flexberry.HighwaySB;
    using ServiceBus.ObjectMessageModel;
    using ServiceBusListener;
    using ServiceBusListener.CustomException;
    using Synchronization.Common;
    using Synchronization.Utils;

    [TestClass]
    public class ServiceBusListenerTests
    {
        public ServiceBusListenerTests()
        {
            DataServiceProvider.AlwaysNewDS = false;
            var mock = new Mock<IDataService>();
            mock.Setup(ds => ds.UpdateObject(It.Is<DataObject>(obj => true)));
            DataServiceFactory.Init(mock.Object);
        }

        [TestMethod]
        public void TestSBListenerService()
        {
            try
            {
                BusListenerServiceHostFactory.StartService();
                BusListenerServiceHostFactory.StopService();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Произошло неожиданное исключение - {ex.Message}");
            }
        }

        [TestMethod]
        public void TestCallBackServiceAcceptToMsrFromReestrMspCatalogDataMessage()
        {
            using (new FakeHttpContext())
            {
                var pathToXML = Path.Combine(HttpRuntime.AppDomainAppPath,
                    $"{Context.XMLMessagePath}{ToMsrFromReestrMspCatalogDataChanges.NameForESB}.xml");
                var xmlTemplateDoc = new XmlDocument();
                xmlTemplateDoc.Load(pathToXML);
                var xmlStringMsg = xmlTemplateDoc.InnerXml;

                var msg = new MessageFromESB
                {
                    MessageTypeID = ToMsrFromReestrMspCatalogDataChanges.NameForESB,
                    Body = xmlStringMsg,
                    SenderName = "TestSender"
                };

                var cb = new CallbackSubscriber();
                try
                {
                    cb.AcceptMessage(msg);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Произошло неожиданное исключение - {ex.Message}");
                }
            }
        }

        [TestMethod]
        public void TestCallBackServiceAcceptToMsrFromReestrMspCatalogItemsResponseMessage()
        {
            using (new FakeHttpContext())
            {
                var pathToXML = Path.Combine(HttpRuntime.AppDomainAppPath,
                    $"{Context.XMLMessagePath}{ToMsrFromReestrMspCatalogItemsResponse.NameForESB}.xml");
                var xmlTemplateDoc = new XmlDocument();
                xmlTemplateDoc.Load(pathToXML);
                var xmlStringMsg = xmlTemplateDoc.InnerXml;

                var msg = new MessageFromESB
                {
                    MessageTypeID = ToMsrFromReestrMspCatalogItemsResponse.NameForESB,
                    Body = xmlStringMsg,
                    SenderName = "TestSender"
                };

                var cb = new CallbackSubscriber();
                try
                {
                    cb.AcceptMessage(msg);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Произошло неожиданное исключение - {ex.Message}");
                }
            }
        }

        [TestMethod]
        public void TestCallBackServiceAcceptToMsrFromTUResponseMessage()
        {
            using (new FakeHttpContext())
            {
                var pathToXML = Path.Combine(HttpRuntime.AppDomainAppPath,
                    $"{Context.XMLMessagePath}{ToMsrFromTUResponse.NameForESB}.xml");
                var xmlTemplateDoc = new XmlDocument();
                xmlTemplateDoc.Load(pathToXML);
                var xmlStringMsg = xmlTemplateDoc.InnerXml;

                var msg = new MessageFromESB
                {
                    MessageTypeID = ToMsrFromTUResponse.NameForESB,
                    Body = xmlStringMsg,
                    SenderName = "TestSender"
                };

                var cb = new CallbackSubscriber();
                try
                {
                    cb.AcceptMessage(msg);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Произошло неожиданное исключение - {ex.Message}");
                }
            }
        }

        [TestMethod]
        public void TestCallBackServiceAcceptToMsrFromReestrMspFiasDataMessage()
        {
            using (new FakeHttpContext())
            {
                var pathToXML = Path.Combine(HttpRuntime.AppDomainAppPath,
                    $"{Context.XMLMessagePath}{ToMsrFromReestrMspFiasDataChanges.NameForESB}.xml");
                var xmlTemplateDoc = new XmlDocument();
                xmlTemplateDoc.Load(pathToXML);
                var xmlStringMsg = xmlTemplateDoc.InnerXml;

                var msg = new MessageFromESB
                {
                    MessageTypeID = ToMsrFromReestrMspFiasDataChanges.NameForESB,
                    Body = xmlStringMsg,
                    SenderName = "TestSender"
                };

                var cb = new CallbackSubscriber();
                try
                {
                    cb.AcceptMessage(msg);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Произошло неожиданное исключение - {ex.Message}");
                }
            }
        }

        [TestMethod]
        public void TestCallBackServiceAcceptToMsrFromReestrMspFiasItemsResponseMessage()
        {
            using (new FakeHttpContext())
            {
                var pathToXML = Path.Combine(HttpRuntime.AppDomainAppPath,
                    $"{Context.XMLMessagePath}{ToMsrFromReestrMspFiasItemsResponse.NameForESB}.xml");
                var xmlTemplateDoc = new XmlDocument();
                xmlTemplateDoc.Load(pathToXML);
                var xmlStringMsg = xmlTemplateDoc.InnerXml;

                var msg = new MessageFromESB
                {
                    MessageTypeID = ToMsrFromReestrMspFiasItemsResponse.NameForESB,
                    Body = xmlStringMsg,
                    SenderName = "TestSender"
                };

                var cb = new CallbackSubscriber();
                try
                {
                    cb.AcceptMessage(msg);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Произошло неожиданное исключение - {ex.Message}");
                }
            }
        }


        [TestMethod]
        public void TestCallBackServiceAcceptToMsrFromReestrMspMergedItemsResponseMessage()
        {
            using (new FakeHttpContext())
            {
                var pathToXML = Path.Combine(HttpRuntime.AppDomainAppPath,
                    $"{Context.XMLMessagePath}{ToMsrFromReestrMspMergedItemsResponse.NameForESB}.xml");
                var xmlTemplateDoc = new XmlDocument();
                xmlTemplateDoc.Load(pathToXML);
                var xmlStringMsg = xmlTemplateDoc.InnerXml;

                var msg = new MessageFromESB
                {
                    MessageTypeID = ToMsrFromReestrMspMergedItemsResponse.NameForESB,
                    Body = xmlStringMsg,
                    SenderName = "TestSender"
                };

                var cb = new CallbackSubscriber();
                try
                {
                    cb.AcceptMessage(msg);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Произошло неожиданное исключение - {ex.Message}");
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UnknowMessageTypeException),
            "Ошибка при попытке сохранить полученное сообщение!\r\nНеизвестный тип сообщения - TestUnknowTypeMessage. Проверьте настройки секции serviceBusListener в конфигурационном файле.")]
        public void TestCallBackServiceUnknowMessageEx()
        {
            var msg = new MessageFromESB
            {
                MessageTypeID = "TestUnknowTypeMessage",
                Body = "",
                SenderName = "TestSender"
            };

            try
            {
                var cb = new CallbackSubscriber();
                cb.AcceptMessage(msg);
            }
            catch (UnknowMessageTypeException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Произошло неожиданное исключение - {ex.Message}");
            }
        }

        [TestMethod]
        public void TestCallBackServiceAcceptToTUfromMSRMessage()
        {
            using (new FakeHttpContext())
            {
                string pathToXML = Path.Combine(HttpRuntime.AppDomainAppPath,
                    $"{Context.XMLMessagePath}{ToTUFromMsrResponse.NameForESB}.xml");
                var xmlTemplateDoc = new XmlDocument();
                xmlTemplateDoc.Load(pathToXML);
                string xmlStringMsg = xmlTemplateDoc.InnerXml;

                var msg = new MessageFromESB
                {
                    MessageTypeID = ToTUFromMsrResponse.NameForESB,
                    Body = xmlStringMsg,
                    SenderName = "TestSender"
                };

                var cb = new CallbackSubscriber();
                try
                {
                    cb.AcceptMessage(msg);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Произошло неожиданное исключение - {ex.Message}");
                }
            }
        }
    }
}