﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessingLibrary.Interface;

namespace TextProcessingLibrary.Utilities
{
    public class UserInput : IUserInput
    {
        //CalculateHighestFrequency should return the highest frequency in the text
        private static int nuberInput;
        public void CalculateHighestFrequencyUserInput()
        {
            try
            {
                var analyzer = new WordFrequencyAnalyzer();
                Console.Write("Enter the text to Analyze: ");
                string enteredVal = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(enteredVal))
                {
                    Console.WriteLine("Word Frequency Analyzer Results");
                    int highestFrequency = analyzer.CalculateHighestFrequency(enteredVal);
                    Console.WriteLine($"Highest frequency: {highestFrequency}");
                    return;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    CalculateHighestFrequencyUserInput();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CalculateFrequencyForWord should return the frequency of the specified word
        public void CalculateFrequencyForWordUserInput()
        {
            try
            {
                var analyzer = new WordFrequencyAnalyzer();
                Console.Write("Enter the text to Analyze: ");
                string enteredVal = Console.ReadLine();

                Console.Write("Enter the word to count frequency : ");
                string wordInspect = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(enteredVal) && !string.IsNullOrWhiteSpace(wordInspect))
                {
                    Console.WriteLine("Word Frequency Analyzer Results");
                    int highestFrequencyWord = analyzer.CalculateFrequencyForWord(enteredVal.Trim(), wordInspect.Trim());
                    Console.WriteLine($"Frequency For Word: {highestFrequencyWord}");
                    return;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    ClearCurrentConsoleLine();
                    CalculateFrequencyForWordUserInput();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CalculateMostFrequentNWords should return a list of the most frequent „n‟ words
        public void CalculateMostFrequentNWordsUserInput()
        {
            try
            {
                var analyzer = new WordFrequencyAnalyzer();
                Console.Write("Enter the text to Analyze: ");
                string enteredVal = Console.ReadLine();
              
                if (!string.IsNullOrWhiteSpace(enteredVal))
                {
                    Console.Write("Enter the Number word to Returns Most Frequent Words count (only Number): ");
                    //string wordInspect = Console.ReadLine();
                    IsValidNumber();
                    IList<IWordFrequency> mostFrequentWords = analyzer.CalculateMostFrequentNWords(enteredVal, nuberInput);
                    Console.WriteLine();
                   Console.WriteLine($"Input Frequent N Words: {mostFrequentWords.Count}");
                    for (int i = 0; i < mostFrequentWords.Count; i++)
                    {
                        Console.WriteLine($"{{\"{mostFrequentWords[i].Word}\" , {mostFrequentWords[i].Frequency} }}");
                    }
                    return;
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    CalculateMostFrequentNWordsUserInput();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }


        // for CalculateMostFrequentNWordsUserInput should be only number allow only number
        static void IsValidNumber()
        {
            string _val = "";
            //Console.Write("Enter your value: ");
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace)
                {
                    double val = 0;
                    bool _x = double.TryParse(key.KeyChar.ToString(), out val);
                    if (_x)
                    {
                        _val += key.KeyChar;
                        Console.Write(key.KeyChar);
                        nuberInput = Convert.ToInt32( _val);
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && _val.Length > 0)
                    {
                        _val = _val.Substring(0, (_val.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
        }
    }
}
