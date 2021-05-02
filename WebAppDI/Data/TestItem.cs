using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppDI.Data
{
    [Table("LearningItems", Schema = "lto")]
    public class TestItem
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime Date { get; set; }
    }
}
