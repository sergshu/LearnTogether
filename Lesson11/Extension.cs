namespace Lesson11
{
    static class Extension
    {
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
