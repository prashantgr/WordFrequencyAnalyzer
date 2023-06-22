using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessingLibrary.Interface
{
    public interface IWordFrequencyAnalyzer
    {
        int CalculateFrequencyForWord(string text, string word);
        int CalculateHighestFrequency(string text);
        IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n);
    }
}
