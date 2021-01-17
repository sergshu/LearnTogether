using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AdoSqlite.DAL
{
    public class User : IBindableComponent
    {
        //Members of IBindableComponent
        ISite iSite;
        ControlBindingsCollection dataBindings;
        BindingContext bindingContext = new BindingContext();

        public User()
        {
            dataBindings = new ControlBindingsCollection(this);
        }
        [Browsable(false)]
        public event EventHandler Disposed;
        [Browsable(false)]
        public void Dispose()
        {
            //your code for disposing
        }
        [Browsable(false)]
        public BindingContext BindingContext
        {
            get { return bindingContext; }
            set { bindingContext = value; }
        }
        [Browsable(false)]
        public ControlBindingsCollection DataBindings
        {
            get { return dataBindings; }
        }
        [Browsable(false)]
        public ISite Site
        {
            get { return iSite; }
            set { iSite = value; }
        }


        [DisplayName("ID")]
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Date created")]
        public DateTime Date { get; set; }
    }
}