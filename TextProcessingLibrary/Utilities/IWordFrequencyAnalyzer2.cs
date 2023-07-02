using TextProcessingLibrary.Interface;

namespace TextProcessingLibrary.Utilities
{
    public interface IWordFrequencyAnalyzer2
    {
        int CalculateFrequencyForWord(string text, string word);
        int CalculateHighestFrequency(string text);
        IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n);
    }
}