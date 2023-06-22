using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextProcessingLibrary.Interface;
using Moq;
using TextProcessingLibrary.Utilities;
using TextProcessingLibrary.Model;
using static System.Net.Mime.MediaTypeNames;

namespace WordFrequencyAnalyzerTest
{
    [TestFixture]
    public class UserInputTests
    {
        private IUserInput _userInput;
        private Mock<IConsoleReader> _consoleReaderMock;
        private Mock<IWordFrequencyAnalyzer> _wordFrequencyAnalyzer;


        [SetUp]
        public void SetUp()
        {
            _wordFrequencyAnalyzer = new Mock<IWordFrequencyAnalyzer>();
            _userInput = new UserInput();
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
                    _userInput.CalculateHighestFrequencyUserInput();

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
                    _userInput.CalculateFrequencyForWordUserInput();

                    consoleWriterMock.Verify(w => w.WriteLine("Frequency For Word: 2"), Times.Once);
                }
            }
        }

        //[Test]
        //public void CalculateMostFrequentNWordsUserInput_WithValidInput_CalculatesMostFrequentNWords()
        //{
        //    string text = "The sun shines over the lake";
        //    string nValue = "2";
        //    _consoleReaderMock.SetupSequence(r => r.ReadLine())
        //        .Returns(text)
        //        .Returns(nValue)
        //        .Returns(string.Empty);

        //    using (var consoleReaderScope = new ConsoleReaderScope(_consoleReaderMock.Object))
        //    {
        //        var consoleWriterMock = new Mock<IConsoleWriter>();
        //        using (var consoleWriterScope = new ConsoleWriterScope(consoleWriterMock.Object))
        //        {
        //            _userInput.CalculateMostFrequentNWordsUserInput();

        //            consoleWriterMock.Verify(w => w.WriteLine("Input Frequent N Words: 2"), Times.Once);
        //            consoleWriterMock.Verify(w => w.WriteLine("{\"the\" , 2 }"), Times.Once);
        //            consoleWriterMock.Verify(w => w.WriteLine("{\"lake\" , 1 }"), Times.Once);
        //        }
        //    }
        //}

//        [Test]
//        public void CalculateMostFrequentNWordsUserInput_ValidInput_ReturnsMostFrequentWords()
//        {
//            // Arrange
//            string userInput = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis molestie consectetur arcu.";
//            int nuberInput = 3;


//            List<WordFrequency> wordFrequencies = new List<WordFrequency>
//{
//    new WordFrequency { Word = "Lorem", Frequency = 2 },
//    new WordFrequency { Word = "ipsum", Frequency = 3 },
//    new WordFrequency { Word = "dolor", Frequency = 1 },
//    new WordFrequency { Word = "sit", Frequency = 4 }
//};

//            var sut = new WordFrequencyAnalyzer();
//            IList<IWordFrequency> mostFrequentWords = sut.CalculateMostFrequentNWords(userInput, nuberInput);


//            var userMock = new Mock<UserInput>();
//            _wordFrequencyAnalyzer.Setup(a => a.CalculateMostFrequentNWords(userInput, nuberInput))
//                .Returns(mostFrequentWords);

//            var consoleOutput = new StringWriter();
//            Console.SetOut(consoleOutput);

//            // Act
//            userMock.Object.CalculateMostFrequentNWordsUserInput();

//            // Assert
//            string expectedOutput = "Input Frequent N Words: 3\n" +
//                                    "{\"Lorem\" , 2 }\n" +
//                                    "{\"ipsum\" , 2 }\n" +
//                                    "{\"dolor\" , 1 }\n";
//            Assert.AreEqual(expectedOutput, consoleOutput.ToString());
//        }

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
