using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessingLibrary.Interface;
using TextProcessingLibrary.Model;

namespace TextProcessingLibrary.Utilities
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        public int CalculateHighestFrequency(string text)
        {
            var wordFrequencyMap = CountWordFrequencies(text);
            return wordFrequencyMap.Count > 0 ? wordFrequencyMap.Max(x => x.Value) : 0;
        }

        public int CalculateFrequencyForWord(string text, string word)
        {
            var wordFrequencyMap = CountWordFrequencies(text);
            word = word.ToLower();
            return wordFrequencyMap.ContainsKey(word) ? wordFrequencyMap[word] : 0;
        }

        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            var wordFrequencyMap = CountWordFrequencies(text);
            var mostFrequentWords = wordFrequencyMap
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Take(n)
                .Select(x => new WordFrequency { Word = x.Key.ToLower(), Frequency = x.Value })
                .ToList<IWordFrequency>();

            return mostFrequentWords;
        }

        private Dictionary<string, int> CountWordFrequencies(string text)
        {
            var wordFrequencyMap = new Dictionary<string, int>();
            var separatorChars = GetSeparatorChars(text);

            var words = text.Split(separatorChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                var normalizedWord = word.ToLower();
                if (!wordFrequencyMap.ContainsKey(normalizedWord))
                    wordFrequencyMap[normalizedWord] = 0;
                wordFrequencyMap[normalizedWord]++;
            }

            return wordFrequencyMap;
        }

        private char[] GetSeparatorChars(string text)
        {
            var separatorChars = new List<char>();
            foreach (var c in text)
            {
                if (!char.IsLetter(c))
                    separatorChars.Add(c);
            }
            return separatorChars.ToArray();
        }
    }
}
