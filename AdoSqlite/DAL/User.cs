using System;
using System.ComponentModel;

namespace AdoSqlite.DAL
{
    internal class User
    {
        [DisplayName("ID")]
        [Browsable(false)]
        public int Id { get; internal set; }
        [DisplayName("User Name")]
        public string UserName { get; internal set; }
        [DisplayName("Name")]
        public string Name { get; internal set; }
        [DisplayName("Date created")]
        public DateTime Date { get; internal set; }
    }
}