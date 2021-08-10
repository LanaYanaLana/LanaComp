using System;
using System.Collections.Generic;
using System.Linq;

namespace LanaComp
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var key in Compress(RandomString(2000)))
            {
                Console.WriteLine(key);
            }
        }

        //https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcde";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static Dictionary<string, int> Compress(string toCompress)
        {
            Dictionary<string, int> compressed = new Dictionary<string, int>(); 
            for (int i = 0; i < toCompress.Length; i++)
            {
                string substr = toCompress.Substring(i, 1);
                if (compressed.ContainsKey(substr))
                {
                    compressed[substr]++;
                }
                else
                {
                    compressed.Add(substr, 1);
                }
            }

            return compressed;
        }
    }
}
