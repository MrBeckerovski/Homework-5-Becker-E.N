using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EX_2
{

        public static class Message
        {
            
            public static Dictionary<string, int> TextFreqAnalis(string[] words, string text)
            {
                char[] separator = new char[] { ' ', ',', '.', '!', '?', ':', ';' };
                Dictionary<string, int> list = new Dictionary<string, int>();
                List<string> textWords = text.ToLower().Split(separator).Where(w => w != "").ToList();

                foreach (var item in words)
                    list.Add(item, 0);

                for (int i = 0; i < words.Length; i++)
                {
                    foreach (var item in textWords)
                    {
                        if (words[i].CompareTo(item) == 0)
                        {
                            list[words[i]]++;
                        }
                    }
                }

                return list;
            }
          
            public static List<string> GetNSymbolWords(string line, int n)
            {
                char[] separator = new char[] { ' ', ',', '.' };
                var arr = line.Trim().Split(separator).Where(el => el != "").ToList();
                List<string> words = new List<string>();

                for (int i = 0; i < arr.Count; i++)
                {
                    if (arr[i].Length <= n)
                    {
                        words.Add(arr[i]);
                    }
                }
                return words;
            }
            
            public static string DelWordByWordEndSymbol(string line, char c)
            {
                var arr = line.Trim().Split(' ').Where(el => el != "").ToList();
                var newArr = arr.Where(el => (el[el.Length - 1] == c
                        || (el[el.Length - 1] == ',' && el[el.Length - 2] == c)
                        || (el[el.Length - 1] == '.' && el[el.Length - 2] == c))).ToList();

                foreach (var item in newArr)
                    line = line.Replace(item, "");

                return line;
            }
            
            public static List<string> MaxLenWords(string line)
            {
                List<string> maxLenWords = new List<string>();
                char[] separator = { ' ', ',', '.' };
                var arr = line.Trim().Split(separator).Where(el => el != "").ToList();
                var lenArr = arr.Select(el => el.Length).ToList();

                lenArr.Sort();

                int maxLenWord = lenArr[lenArr.Count - 1];

                foreach (var item in arr)
                    if (item.Length == maxLenWord) maxLenWords.Add(item);

                return maxLenWords;
            }
          
            public static string MaxWordsLine(string line)
            {
                List<string> maxLenWords = MaxLenWords(line);
                StringBuilder sb = new StringBuilder();

                foreach (var item in maxLenWords)
                    sb.Append(item + " ");

                return sb.ToString().TrimEnd();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Исходная строка:");
                string str = " Hello, World!  EveryBody this,  ManGo  is nice  colparalo baby colorado 123 aso.  ";
                Console.WriteLine(str);

             
                Console.WriteLine("\nСлова из строки не больше указанной длины:");
                foreach (var item in Message.GetNSymbolWords(str, 4))
                    Console.WriteLine(item);

                Console.WriteLine("\nРезультирующая строка:");
                Console.WriteLine(Message.DelWordByWordEndSymbol(str, 'o'));

         
                Console.WriteLine("\nСписок длинных слов:");
                foreach (var item in Message.MaxLenWords(str))
                    Console.WriteLine(item);

           
                Console.WriteLine("\nСтрока из длинных слов:");
                Console.WriteLine(Message.MaxWordsLine(str));

                
                Console.WriteLine("\nЧастотный анализ текста:");
                string text = "test testing asdag Test kasd test, asdkl asd asd asd Asd aSd asfef";
                var list = Message.TextFreqAnalis(new string[] { "test", "asd" }, text);
                Console.WriteLine($"Исходный текст:\n{text}");

                foreach (var item in list)
                {
                    Console.WriteLine($"слово: {item.Key} в тексте встречается: {item.Value} раз");
                }
            }
        }
    }