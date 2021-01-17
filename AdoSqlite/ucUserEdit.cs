using AdoSqlite.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoSqlite
{
    public partial class ucUserEdit : UserControl
    {
        private User user;

        public DAL.User User { get => user; set { user = value; bind(); } }

        private void bind()
        {
            if (user != null)
            {
                txtName.DataBindings.Clear();
                txtName.DataBindings.Add("Text", User, "Name");
                txtUserName.DataBindings.Clear();
                txtUserName.DataBindings.Add("Text", User, "UserName");
                dtpDate.DataBindings.Clear();
                dtpDate.DataBindings.Add("Value", User, "Date");
            }
        }

        public ucUserEdit()
        {
            InitializeComponent();
        }
    }
}
