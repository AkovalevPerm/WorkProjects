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
    using ICSSoft.STORMNET;
    using System;
    using System.Xml;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using ICSSoft.STORMNET.Business;
    using ICSSoft.STORMNET.Business.Audit;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Simple test audit project.
    /// </summary>
    // *** Start programmer edit section *** (SimpleTestAuditProjectDesktop CustomAttributes)

    // *** End programmer edit section *** (SimpleTestAuditProjectDesktop CustomAttributes)
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class SimpleTestAuditProjectDesktop : ICSSoft.STORMNET.Windows.Forms.Desktop
    {
        
        // *** Start programmer edit section *** (Form Designer Fields)

        private int dummyint;
        
        // *** End programmer edit section *** (Form Designer Fields)
        private System.ComponentModel.IContainer components = null;
        
        // *** Start programmer edit section *** (SimpleTestAuditProjectDesktop CustomMembers)

        // *** End programmer edit section *** (SimpleTestAuditProjectDesktop CustomMembers)

        
        public SimpleTestAuditProjectDesktop()
        {
            this.InitializeComponent();
            // *** Start programmer edit section *** (Form Constructor)

            // *** End programmer edit section *** (Form Constructor)
        }
        
        // *** Start programmer edit section *** (Form Designer Initialize)

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(300, 300);
            this.Text = "SimpleTestAuditProjectDesktop";
            this.Text = "Simple test audit project";
        }
        
        // *** End programmer edit section *** (Form Designer Initialize)
        private void Dummy()
        {
        }
        
        [STAThread()]
        static void Main()
        {
            try
            {
                // *** Start programmer edit section *** (SimpleTestAuditProject Before authorization)

                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.ThreadException += ICSSoft.STORMNET.Windows.Forms.ErrorBox.ApplicationThreadException;
                System.AppDomain.CurrentDomain.UnhandledException += ICSSoft.STORMNET.Windows.Forms.ErrorBox.CurrentDomainUnhandledException;
                // *** End programmer edit section *** (SimpleTestAuditProject Before authorization)
                SimpleTestAuditProjectDesktop desktop = new SimpleTestAuditProjectDesktop();
                if (ICSSoft.STORMNET.Windows.Forms.WinApplication.CheckAlreadyRunning(desktop, "{16f5cf7c-b5e1-4d1f-8375-3b20300f8159}"))
                {
                    return;
                }
                //ICSSoft.STORMNET.RightManager.DisableAllRightChecks();
                // *** Start programmer edit section *** (SimpleTestAuditProject Main())

                ICSSoft.STORMNET.Windows.Forms.WinApplication.SetUICultureAsRussian();
                AuditSetter.InitAuditService(DataServiceProvider.DataService);
                // *** End programmer edit section *** (SimpleTestAuditProject Main())
                ICSSoft.STORMNET.Business.LockService.ClearAllUserLocks();
                desktop.DesktopCustomizer = new SimpleTestAuditProject.SimpleTestAuditProjectDesktopCustomizer();
                Application.Run(desktop);
                // *** Start programmer edit section *** (SimpleTestAuditProject Main() End)

                // *** End programmer edit section *** (SimpleTestAuditProject Main() End)
            }
            catch (System.Exception e)
            {
                // *** Start programmer edit section *** (SimpleTestAuditProject Main() Error)

                ICSSoft.STORMNET.Windows.Forms.ErrorBox.Show(e);
                // *** End programmer edit section *** (SimpleTestAuditProject Main() Error)
            }
        }
    }
}
