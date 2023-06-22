using Microsoft.VisualStudio.TestPlatform.TestHost;
using TextProcessingLibrary.Interface;
using TextProcessingLibrary.Utilities;

namespace WordFrequencyAnalyzerTest
{
    public class Tests
    {
        [TestFixture]
        public class WordFrequencyAnalyzerTests
        {
            private IWordFrequencyAnalyzer _wordFrequencyAnalyzer;

            [SetUp]
            public void SetUp()
            {
                _wordFrequencyAnalyzer = new WordFrequencyAnalyzer();
            }

            [Test]
            public void CalculateHighestFrequency_WithEmptyText_ReturnsZero()
            {
                string text = "";
                int highestFrequency = _wordFrequencyAnalyzer.CalculateHighestFrequency(text);
                Assert.That(highestFrequency, Is.EqualTo(0));
            }

            [Test]
            public void CalculateHighestFrequency_WithText_ReturnsCorrectFrequency()
            {
                string text = "The sun shines over the lake";
                int highestFrequency = _wordFrequencyAnalyzer.CalculateHighestFrequency(text);
                Assert.That(highestFrequency, Is.EqualTo(2));
            }

            [Test]
            public void CalculateFrequencyForWord_WithEmptyText_ReturnsZero()
            {
                string text = "";
                string word = "the";
                int frequency = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word);
                Assert.That(frequency, Is.EqualTo(0));
            }

            [Test]
            public void CalculateFrequencyForWord_WithText_ReturnsCorrectFrequency()
            {
                string text = "The sun shines over the lake";
                string word = "the";
                int frequency = _wordFrequencyAnalyzer.CalculateFrequencyForWord(text, word);
                Assert.That(frequency, Is.EqualTo(2));
            }

            [Test]
            public void CalculateMostFrequentNWords_WithEmptyText_ReturnsEmptyList()
            {
                string text = "";
                int n = 3;
                IList<IWordFrequency> mostFrequentWords = _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, n);
                Assert.That(mostFrequentWords.Count, Is.EqualTo(0));
            }

            [Test]
            public void CalculateMostFrequentNWords_WithText_ReturnsMostFrequentWords()
            {
                string text = "The sun shines over the lake";
                int n = 3;
                IList<IWordFrequency> mostFrequentWords = _wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, n);
                Assert.That(mostFrequentWords.Count, Is.EqualTo(3));

                Assert.That(mostFrequentWords[0].Word, Is.EqualTo("the"));
                Assert.That(mostFrequentWords[0].Frequency, Is.EqualTo(2));

                Assert.That(mostFrequentWords[1].Word, Is.EqualTo("lake"));
                Assert.That(mostFrequentWords[1].Frequency, Is.EqualTo(1));

                Assert.That(mostFrequentWords[2].Word, Is.EqualTo("over"));
                Assert.That(mostFrequentWords[2].Frequency, Is.EqualTo(1));
            }


        }
    }
}