using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.Models
{
    static class ModelsExtension
    {
        public static string GetFormatedString(this ContactModel model)
        {
            return $"Ф:{model.Surname} И:{model.Name} Т:{model.PhoneNumber}";
        }
    }
}
