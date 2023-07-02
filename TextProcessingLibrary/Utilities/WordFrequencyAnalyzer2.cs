using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessingLibrary.Interface;
using TextProcessingLibrary.Model;

namespace TextProcessingLibrary.Utilities
{
    public class WordFrequencyAnalyzer2 : IWordFrequencyAnalyzer2
    {
        public int CalculateHighestFrequency(string text)
        {
            int maxFrequency = 0;
            using (var reader = new StringReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    maxFrequency = Math.Max(maxFrequency, CalculateLineHighestFrequency(line));
                }
            }
            return maxFrequency;
        }

        public int CalculateFrequencyForWord(string text, string word)
        {
            int frequency = 0;
            using (var reader = new StringReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    frequency += CalculateLineFrequencyForWord(line, word);
                }
            }
            return frequency;
        }

        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            var wordFrequencies = CountWordFrequencies(text);
            var mostFrequentWords = wordFrequencies
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .Take(n)
                .Select(x => new WordFrequency { Word = x.Key.ToLower(), Frequency = x.Value })
                .ToList<IWordFrequency>();

            return mostFrequentWords;
        }

        private int CalculateLineHighestFrequency(string line)
        {
            var wordFrequencyMap = CountLineWordFrequencies(line);
            return wordFrequencyMap.Count > 0 ? wordFrequencyMap.Max(x => x.Value) : 0;
        }

        private int CalculateLineFrequencyForWord(string line, string word)
        {
            var wordFrequencyMap = CountLineWordFrequencies(line);
            word = word.ToLower();
            return wordFrequencyMap.ContainsKey(word) ? wordFrequencyMap[word] : 0;
        }

        private Dictionary<string, int> CountLineWordFrequencies(string line)
        {
            var wordFrequencyMap = new Dictionary<string, int>();
            var separatorChars = GetSeparatorChars(line);
            var words = line.Split(separatorChars, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                var normalizedWord = word.ToLower();
                if (!wordFrequencyMap.ContainsKey(normalizedWord))
                    wordFrequencyMap[normalizedWord] = 0;
                wordFrequencyMap[normalizedWord]++;
            }
            return wordFrequencyMap;
        }

        private char[] GetSeparatorChars(string line)
        {
            var separatorChars = new List<char>();
            foreach (var c in line)
            {
                if (!char.IsLetter(c))
                    separatorChars.Add(c);
            }
            return separatorChars.ToArray();
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
    }



}
