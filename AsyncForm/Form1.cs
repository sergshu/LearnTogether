using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncForm
{
    public partial class Form1 : Form
    {
        private bool _cancel;

        public Form1()
        {
            InitializeComponent();

            FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cancel = true;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            _cancel = false;
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            await Task.Run(() => process());
        }

        private void process()
        {
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    //boxing
                    object o = i;
                    //unboxing
                    int ii = (int)o;

                    Task.Run(() =>
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"nonboxed: {i} boxing: {ii}");
                    });
                }

                foreach (var i in Enumerable.Range(1, 5))
                {
                    //boxing
                    object o = i;
                    //unboxing
                    int ii = (int)o;

                    Task.Run(() =>
                    {
                        Thread.Sleep(100);
                        Console.WriteLine($"foreach - nonboxed: {i} boxing: {ii}");
                    });
                }

                Parallel.ForEach(Enumerable.Range(1, 5), (i) =>
                {
                    //boxing
                    object o = i;
                    //unboxing
                    int ii = (int)o;

                    Thread.Sleep(100);
                    Console.WriteLine($"Parallel.ForEach - nonboxed: {i} boxing: {ii}");
                });


                {
                    int i = 0;
                    while (!_cancel)
                    {
                        i++;

                    }
                }

                Invoke((MethodInvoker)delegate
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                });
            }
            catch (Exception ex) { }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cancel = true;
        }
    }
}
