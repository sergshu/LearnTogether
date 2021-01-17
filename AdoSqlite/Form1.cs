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
    public partial class Form1 : Form
    {
        private List<DAL.User> _list;
        private bool _newUserEdit;

        public Form1()
        {
            InitializeComponent();

            _list = new List<DAL.User>();
            bsUser.DataSource = _list;
            dataGridView1.AutoGenerateColumns = true;

            ucUserEdit1.User = new DAL.User { Date = DateTime.Now.Date };
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void refreshTable()
        {
            _list.Clear();

            List<DAL.User> list = DAL.SqliteHelper.GetUsers();
            if (list != null && list.Count > 0)
            {
                _list.AddRange(list);
                bsUser.ResetBindings(false);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var user = (DAL.User)bsUser.Current;
            ucUserEdit1.User = user;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucUserEdit1.User = new DAL.User { Date = DateTime.Now.Date };
            _newUserEdit = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_newUserEdit)
            {
                if (DAL.SqliteHelper.AddUser(ucUserEdit1.User))
                {
                    _newUserEdit = false;
                }
            }
            else
            {
                DAL.SqliteHelper.SaveUser(ucUserEdit1.User);
            }

            refreshTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DAL.SqliteHelper.DeleteUser(id: ucUserEdit1.User?.Id ?? 0);

            refreshTable();
        }
    }
}
