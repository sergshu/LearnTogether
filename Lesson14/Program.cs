using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lesson14
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var task = Task.Run(ReadFile);
                await Task.WhenAll(task);
            }
            catch (FileNotFoundEx ex) { write("FileNotFoundEx: " + ex.Message); }
            catch (Exception ex) { write(ex.ToString()); }

            Console.WriteLine("Нажмите кнопку");
            Console.ReadKey();
        }

        private static void ReadFile()
        {
            try
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, "test.txt");

                File.ReadAllText(filePath);
            }
            catch (FileNotFoundException ex)
            {
                write("!!! File not found");
                throw new FileNotFoundEx(ex);
            }
            catch (Exception ex) { write("ReadFile: " + ex.Message); }
            catch { write("ReadFile: Error"); }
            finally { write("Finally"); }
        }

        private static void writeNewLine()
        {
            Console.WriteLine();
        }

        private static void write(string v)
        {
            Console.WriteLine(v);
        }
    }

    [Serializable]
    internal class FileNotFoundEx : Exception
    {
        private FileNotFoundException ex;

        public FileNotFoundEx()
        {
        }

        public FileNotFoundEx(FileNotFoundException ex)
        {
            this.ex = ex;
        }

        public FileNotFoundEx(string message) : base(message)
        {
        }

        public FileNotFoundEx(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileNotFoundEx(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
