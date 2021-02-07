using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    class FigureList<T> where T : IPerimetr
    {
        public FigureList()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; }

        public void Add(T item)
        {
            Items.Add(item);
        }

        public T Get<TParam>()
        {
            foreach(var item in Items)
            {
                if(item.GetType() == typeof(TParam))
                {
                    return item;
                }
            }

            return default(T);
        }
    }
}
