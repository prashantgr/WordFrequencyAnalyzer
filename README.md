# Text Processing Library

This is a text processing library that provides functionality to analyze word frequencies in a given text.

## Assumptions and Definitions

- **Word**: A word is represented by a sequence of one or more characters between 'a' and 'z' or between 'A' and 'Z'. For example, "agdfBh".

- **Letter Case**: The library considers the frequency of words in a case-insensitive manner. For example, "the", "The", and "tHE" would all have the same frequency.

- **Input Text**: The input text contains words separated by various separator characters. Characters from 'a' to 'z' and 'A' to 'Z' can only appear within words.

## Interface

The library provides the following interface:

```csharp
namespace Test
{
    public interface IWordFrequency
    {
        string Word { get; }
        int Frequency { get; }
    }

    public interface IWordFrequencyAnalyzer
    {
        int CalculateHighestFrequency(string text);
        int CalculateFrequencyForWord(string text, string word);
        IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n);
    }
}
