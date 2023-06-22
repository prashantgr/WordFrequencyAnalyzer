using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessingLibrary.Interface;
using Moq;
using TextProcessingLibrary.Utilities;

namespace WordFrequencyAnalyzerTest
{
    [TestFixture]
    public class UserInputTests
    {
        private IUserInput _wordFrequencyAnalyzer;
        private Mock<IConsoleReader> _consoleReaderMock;

        [SetUp]
        public void SetUp()
        {
            _wordFrequencyAnalyzer = new UserInput();
            _consoleReaderMock = new Mock<IConsoleReader>();
        }

        [Test]
        public void CalculateHighestFrequencyUserInput_WithValidInput_CalculatesHighestFrequency()
        {
            string text = "The sun shines over the lake";
            _consoleReaderMock.SetupSequence(r => r.ReadLine())
                .Returns(text)
                .Returns(string.Empty);

            using (var consoleReaderScope = new ConsoleReaderScope(_consoleReaderMock.Object))
            {
                var consoleWriterMock = new Mock<IConsoleWriter>();
                using (var consoleWriterScope = new ConsoleWriterScope(consoleWriterMock.Object))
                {
                    _wordFrequencyAnalyzer.CalculateHighestFrequencyUserInput();

                    consoleWriterMock.Verify(w => w.WriteLine("Highest frequency: 2"), Times.Once);
                }
            }
        }

        //[Test]
        //public void CalculateHighestFrequencyUserInput_WithEmptyInput_RepromptsUser()
        //{
        //    string text = "";
        //    _consoleReaderMock.SetupSequence(r => r.ReadLine())
        //        .Returns(text)
        //        .Returns("The sun shines over the lake")
        //        .Returns(string.Empty);

        //    using (var consoleReaderScope = new ConsoleReaderScope(_consoleReaderMock.Object))
        //    {
        //        var consoleWriterMock = new Mock<IConsoleWriter>();
        //        using (var consoleWriterScope = new ConsoleWriterScope(consoleWriterMock.Object))
        //        {
        //            _wordFrequencyAnalyzer.CalculateHighestFrequencyUserInput();

        //            consoleWriterMock.Verify(w => w.WriteLine("Highest frequency: 2"), Times.AtLeastOnce);
        //        }
        //    }
        //}

        [Test]
        public void CalculateFrequencyForWordUserInput_WithValidInput_CalculatesFrequencyForWord()
        {
            string text = "The sun shines over the lake";
            string word = "the";
            _consoleReaderMock.SetupSequence(r => r.ReadLine())
                .Returns(text)
                .Returns(word)
                .Returns(string.Empty);

            using (var consoleReaderScope = new ConsoleReaderScope(_consoleReaderMock.Object))
            {
                var consoleWriterMock = new Mock<IConsoleWriter>();
                using (var consoleWriterScope = new ConsoleWriterScope(consoleWriterMock.Object))
                {
                    _wordFrequencyAnalyzer.CalculateFrequencyForWordUserInput();

                    consoleWriterMock.Verify(w => w.WriteLine("Frequency For Word: 2"), Times.Once);
                }
            }
        }

        [Test]
        public void CalculateMostFrequentNWordsUserInput_WithValidInput_CalculatesMostFrequentNWords()
        {
            string text = "The sun shines over the lake";
            string nValue = "2";
            _consoleReaderMock.SetupSequence(r => r.ReadLine())
                .Returns(text)
                .Returns(nValue)
                .Returns(string.Empty);

            using (var consoleReaderScope = new ConsoleReaderScope(_consoleReaderMock.Object))
            {
                var consoleWriterMock = new Mock<IConsoleWriter>();
                using (var consoleWriterScope = new ConsoleWriterScope(consoleWriterMock.Object))
                {
                    _wordFrequencyAnalyzer.CalculateMostFrequentNWordsUserInput();

                    consoleWriterMock.Verify(w => w.WriteLine("Input Frequent N Words: 2"), Times.Once);
                    consoleWriterMock.Verify(w => w.WriteLine("{\"the\" , 2 }"), Times.Once);
                    consoleWriterMock.Verify(w => w.WriteLine("{\"lake\" , 1 }"), Times.Once);
                }
            }
        }

        public interface IConsoleReader
        {
            string ReadLine();
        }

        public interface IConsoleWriter
        {
            void WriteLine(string message);
        }
    }
}
