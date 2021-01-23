using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6.Models
{
    static class ModelsExtension
    {
        public static ContactModel CreateContactModel(this string row)
        {
            string[] columns = row.Split('\t');
            if (columns.Length == 3)
            {
                if (long.TryParse(columns[2], out long number)
                    && !string.IsNullOrEmpty(columns[0])
                    && !string.IsNullOrEmpty(columns[1]))
                {
                    return new ContactModel { Name = columns[1], PhoneNumber = number, Surname = columns[0] };
                }
            }

            return null;
        }

        public static string GetFormatedString(this ContactModel model)
        {
            return $"Ф:{model.Surname} И:{model.Name} Т:{model.PhoneNumber}";
        }
    }
}
