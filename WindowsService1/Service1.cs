using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        private bool _cancel;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _cancel = false;

            Task.Run(() => Processing());

            EventLog.WriteEntry("We did it! Started", EventLogEntryType.Information);
        }

        private void Processing()
        {
            try
            {
                while(!_cancel)
                {
                    Thread.Sleep(100);
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        protected override void OnStop()
        {
            _cancel = true;

            EventLog.WriteEntry("We did it! Stoped", EventLogEntryType.Information);
        }
    }
}
