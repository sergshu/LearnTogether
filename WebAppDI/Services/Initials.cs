using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDI.Models;

namespace WebAppDI.Services
{
    public class Initials : IInitials
    {
        public string Get(TestItemView item)
        {
            return $"{item.Name[0]}.{item.SurName[0]}.";
        }
    }
}
