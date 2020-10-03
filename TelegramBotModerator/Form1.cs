using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelegramBotModerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ucStartStop1_Start(object sender, EventArgs e)
        {
            Task.Run(() => BO.TelegramHelper.Start());
        }

        private async void ucStartStop1_Stop(object sender, EventArgs e)
        {
            await BO.TelegramHelper.Stop();
            ucStartStop1.Init();
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewWord.Text))
            {
                BO.WordsHelper.AddWord(txtNewWord.Text);
                bindingSource1.ResetBindings(false);

                txtNewWord.Text = string.Empty;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbWords.SelectedItem != null)
            {
                BO.WordsHelper.DeleteWord(lbWords.SelectedItem.ToString());
                bindingSource1.ResetBindings(false);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(null, null);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbWords.Items.Clear();
        }

        private void tableLayoutPanel1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void lbWords_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(lbWords, e.Location);
            }
        }

        private void txtNewWord_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddWord_Click(null, null);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = BO.WordsHelper.WordsList;
        }
    }
}
