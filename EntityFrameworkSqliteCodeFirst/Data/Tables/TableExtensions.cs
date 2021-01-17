using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSqliteCodeFirst.Data.Tables
{
    public static class TableExtensions
    {
        public static string ToRowString(this Order order)
        {
            return $"{order.Id} - {order.Date:dd.MM.yyyy} - {order.Name}";
        }
        public static string ToPersonsString(this Person p)
        {
            return $"{p.Id}-{p.Name}-{p.Age} Role: {p.PersonRole?.Name} {(p.Orders.Count > 0 ? ("\n             " + string.Join("\n             ", p.Orders.Select(o => o.ToRowString()))) : string.Empty)}";
        }
    }
}
