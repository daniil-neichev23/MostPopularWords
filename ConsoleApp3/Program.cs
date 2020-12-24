using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public static Dictionary<string, int> MostPopWords(string sent)
        {
            Dictionary<string, int> mostPop = new Dictionary<string, int>();
            sent = sent.ToLower();
            List<string> words = new List<string>(sent.Split(' '));
            for (int i = 0; i < words.Count; ++i)
            {
                if (char.IsPunctuation(words[i].Last())) words[i] = words[i].Remove(words[i].Length - 1);
            }
            foreach (var word in words)
            {
                if (mostPop.ContainsKey(word)) mostPop[word] += 1;
                else mostPop[word] = 1;
            }
            List<string> keyList = new List<string>(mostPop.Keys);
            if( keyList.Count < 3) return new Dictionary<string, int>();
            var prList = mostPop.ToList();
            prList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            prList = prList.GetRange(0, 3);
            mostPop = prList.ToDictionary(x => x.Key, x => x.Value);
            return mostPop;

        }
        static void Main(string[] args)
        {
            string sampleSent = "Hello my na'me is na'me. Random sentence is na'me is, is hello.";
            var result = MostPopWords(sampleSent);
            
            foreach(var pair in result)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            Console.ReadLine();
        }
    }
}
