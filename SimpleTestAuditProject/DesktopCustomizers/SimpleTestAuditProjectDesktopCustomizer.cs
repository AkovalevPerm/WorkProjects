﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleTestAuditProject
{
    using System;
    using System.Xml;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Simple test audit project.
    /// </summary>
    // *** Start programmer edit section *** (SimpleTestAuditProjectDesktopCustomizer CustomAttributes)

    // *** End programmer edit section *** (SimpleTestAuditProjectDesktopCustomizer CustomAttributes)
    public class SimpleTestAuditProjectDesktopCustomizer : ICSSoft.STORMNET.UI.DesktopCustomizer
    {
        
        // *** Start programmer edit section *** (SimpleTestAuditProjectDesktopCustomizer CustomMembers)

        // *** End programmer edit section *** (SimpleTestAuditProjectDesktopCustomizer CustomMembers)

        
        public override string GetDesktopCaption()
        {
            // *** Start programmer edit section *** (SimpleTestAuditProject GetDesktopCaption())

            // *** End programmer edit section *** (SimpleTestAuditProject GetDesktopCaption())
            return "Simple test audit project";
        }
        
        public override ICSSoft.STORMNET.UI.Runner[] GetRunners()
        {
            System.Collections.ArrayList arr = new System.Collections.ArrayList();
            arr.AddRange(base.GetRunners());
            // *** Start programmer edit section *** (SimpleTestAuditProject GetRunners())

            // *** End programmer edit section *** (SimpleTestAuditProject GetRunners())
            arr.Add(new ICSSoft.STORMNET.UI.ContRunner(typeof(SimpleTestAuditProject.MainObjL), "SimpleTestAuditProject", "Main obj", ""));
            arr.Add(new ICSSoft.STORMNET.UI.ContRunner(typeof(SimpleTestAuditProject.MasterObjL), "SimpleTestAuditProject", "Master obj", ""));
            arr.Add(new ICSSoft.STORMNET.UI.ContRunner(typeof(SimpleTestAuditProject.DetailMasterL), "SimpleTestAuditProject", "DetailMasterL", ""));
            arr.Add(new ICSSoft.STORMNET.Windows.Forms.FormRunner(typeof(SimpleTestAuditProject.WinformShowAuditFormU), "SimpleTestAuditProject", "ShowAuditFormU", ""));
            // *** Start programmer edit section *** (SimpleTestAuditProject GetRunners() End)

            // *** End programmer edit section *** (SimpleTestAuditProject GetRunners() End)
            // *** Start programmer edit section *** (SimpleTestAuditProject Audit)
            arr.Add(new ICSSoft.STORMNET.UI.ContRunner(typeof(ICSSoft.STORMNET.Business.Audit.WinForms.AuditEntityL), "Аудит", "Аудит операций", ""));
            arr.Add(new ICSSoft.STORMNET.UI.ContRunner(typeof(ICSSoft.STORMNET.Business.Audit.WinForms.AuditEntityByObjectsL), "Аудит", "Аудит объектов", ""));
            // *** End programmer edit section *** (SimpleTestAuditProject Audit)
            ICSSoft.STORMNET.UI.Runner[] retArray = new ICSSoft.STORMNET.UI.Runner[arr.Count];
            arr.CopyTo(retArray);
            return retArray;
        }
    }
}
