﻿using System.Diagnostics.CodeAnalysis;
using TextProcessingLibrary.Utilities;

namespace Test
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static string EnteredVal = "";
        static void Main(string[] args)
        {
            var analyzer = new UserInput();
            Console.WriteLine("Word Frequency Analyzer");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. CalculateHighestFrequency should return the highest frequency in the text");

            analyzer.CalculateHighestFrequencyUserInput();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("2. CalculateFrequencyForWord should return the frequency of the specified word");

            analyzer.CalculateFrequencyForWordUserInput();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("3. CalculateMostFrequentNWords should return a list of the most frequent „n‟ words");

            analyzer.CalculateMostFrequentNWordsUserInput();
            Console.ReadLine();
        }
    }
}
