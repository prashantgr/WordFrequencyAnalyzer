using System.Diagnostics.CodeAnalysis;
using TextProcessingLibrary.Interface;
using TextProcessingLibrary.Utilities;

namespace Test
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static string EnteredVal = "";
        static void Main(string[] args)
        {
            /*
            while (true)
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

                Console.WriteLine("-----------------------------");
                Console.WriteLine("Do you want to continue? (Y/N)");
                
                string input = Console.ReadLine();
                if (input.ToUpper() == "N")
                {
                    break;
                }
                Console.Clear();
                Console.WriteLine("Let's keep going!");

            }

            */
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eget urna nec nisi consequat ultrices. Morbi dignissim odio mauris, non luctus sapien efficitur ut. Quisque ultrices tristique lacus, id rutrum ligula posuere ut. Duis vestibulum auctor velit. Aliquam lacinia, neque nec interdum finibus, enim purus vestibulum ligula, vitae scelerisque mi metus ut lorem.";

            WordFrequencyAnalyzer2 analyzer = new WordFrequencyAnalyzer2();

            Console.WriteLine("1. CalculateHighestFrequency should return the highest frequency in the text");
            int highestFrequency = analyzer.CalculateHighestFrequency(text);
            Console.WriteLine($"Highest Frequency: {highestFrequency}");

            Console.WriteLine("2. CalculateFrequencyForWord should return the frequency of the specified word");
            string word = "Lorem";
            int frequencyForWord = analyzer.CalculateFrequencyForWord(text, word);
            Console.WriteLine($"Frequency for the word '{word}': {frequencyForWord}");

            Console.WriteLine("3. CalculateMostFrequentNWords should return a list of the most frequent 'n' words");
            int n = 3;
            IList<IWordFrequency> mostFrequentWords = analyzer.CalculateMostFrequentNWords(text, n);
            Console.WriteLine($"Most frequent {n} words:");
            foreach (var wordFrequency in mostFrequentWords)
            {
                Console.WriteLine($"{wordFrequency.Word}: {wordFrequency.Frequency}");
            }

            Console.ReadLine();

        }
    }
}
