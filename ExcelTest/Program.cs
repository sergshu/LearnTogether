using System;
using System.IO;

namespace ExcelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (BO.ExcelHelper helper = new BO.ExcelHelper())
                {
                    if (helper.Open(filePath: Path.Combine(Environment.CurrentDirectory, "TestLT.xlsx")))
                    {
                        helper.Set(column: "A", row: 1, data: "lksadklsajdkl");
                        var val = helper.Get(column: "A", row: 1);
                        helper.Set(column: "B", row: 1, data: DateTime.Now);

                        helper.Save();
                    }
                }

                Console.Read();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
