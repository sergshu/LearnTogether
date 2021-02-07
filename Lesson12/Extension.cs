using System;

namespace Lesson12
{
    static class Extension
    {
        public static string ToFormatedString(this Tuple<double, decimal> tuple)
        {
            return $"Perimetr {tuple.Item1} Area {tuple.Item2}";
        }

        public static string GetPerimetr(this IPerimetr v)
        {
            return $"Perimetr = {v.Perimetr}";
        }

        public static string GetPerimetr(this Figure v)
        {
            //return $"Perimetr = {(v as IPerimetr).Perimetr}";
            return $"Perimetr = {((IPerimetr)v).Perimetr}";
        }
    }
}
