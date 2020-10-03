using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotModerator.BO
{
    static class WordsHelper
    {
        private const string FILE_NAME = "words.txt";

        private static List<string> _wordsList;

        public static List<string> WordsList { get { if (_wordsList == null) loadList(); return _wordsList; } }

        private static  void loadList()
        {
            try
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, FILE_NAME);

                if (File.Exists(filePath))
                {
                    _wordsList = File.ReadAllLines(filePath).ToList();
                }
                else
                {
                    _wordsList = new List<string>();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public static bool AddWord(string word)
        {
            if (!string.IsNullOrWhiteSpace(word) && !_wordsList.Any(w => w.Equals(word.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                _wordsList.Add(word.Trim());

                return saveList();
            }

            return false;
        }

        public static bool DeleteWord(string word)
        {
            int idx;
            if (!string.IsNullOrWhiteSpace(word) && (idx = _wordsList.FindIndex(w => w.Equals(word.Trim(), StringComparison.OrdinalIgnoreCase))) >= 0)
            {
                _wordsList.RemoveAt(idx);

                return saveList();
            }

            return false;
        }

        private static bool saveList()
        {
            try
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, FILE_NAME);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                File.WriteAllLines(filePath, _wordsList);

                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return false;
        }
    }
}
