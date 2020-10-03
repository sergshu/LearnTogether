using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelegramBotModerator
{
    public partial class ucStartStop : UserControl
    {
        public event EventHandler Start;
        public event EventHandler Stop;
        public ucStartStop()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Start?.Invoke(this, EventArgs.Empty);
            btnStart.Visible = false;
            btnStop.Visible = btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop?.Invoke(this, EventArgs.Empty);
            btnStop.Enabled = false;
        }

        public void Init()
        {
            btnStart.Visible = true;
            btnStop.Visible = false;
        }
    }
}
