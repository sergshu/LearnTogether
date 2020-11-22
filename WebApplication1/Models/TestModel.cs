using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TestModel
    {
        public string Text { get; set; } = "Test";
        public string Result { get; set; }
        public string Selected { get; set; }
        public IEnumerable<string> Items { get; set; } = new List<string> { "1", "2", "3" };

        public IEnumerable<MyItemModel> MyItems { get; set; }
    }

    public class MyItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}