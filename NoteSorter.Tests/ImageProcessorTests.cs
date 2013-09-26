namespace NoteSorter.Tests
{
    using System;

    using NoteSorter.ImageProcessor;
    using NUnit.Framework;

    [TestFixture]
    public class ImageProcessorTests
    {
        [Test]
        public void PinkShouldBeRecognizedAsRedTest()
        {
            var referenceBackgrounds = new ReferenceBackgrounds();
            referenceBackgrounds.Add("yellow", new Uri("C:\\temp\\processorTests\\yellow.jpg"));
            referenceBackgrounds.Add("black", new Uri("C:\\temp\\processorTests\\black.jpg"));
            referenceBackgrounds.Add("red", new Uri("C:\\temp\\processorTests\\red.jpg"));
            referenceBackgrounds.Add("green", new Uri("C:\\temp\\processorTests\\green.jpg"));
            var ip = new ImageProcessor(referenceBackgrounds);

            Assert.AreEqual("red", ip.GetNearestColor(new Uri("C:\\temp\\processorTests\\pink.jpg")));
        }

        [Test]
        public void DarkGreyShouldBeRecognizedAsBlackTest()
        {
            var referenceBackgrounds = new ReferenceBackgrounds();
            referenceBackgrounds.Add("black", new Uri("C:\\temp\\processorTests\\black.jpg"));
            referenceBackgrounds.Add("red", new Uri("C:\\temp\\processorTests\\red.jpg"));
            referenceBackgrounds.Add("green", new Uri("C:\\temp\\processorTests\\green.jpg"));
            referenceBackgrounds.Add("yellow", new Uri("C:\\temp\\processorTests\\yellow.jpg"));
            var ip = new ImageProcessor(referenceBackgrounds);

            Assert.AreEqual("black", ip.GetNearestColor(new Uri("C:\\temp\\processorTests\\darkGrey.jpg")));
        }

        [Test]
        public void PhotoYellowNoteShouldBeRecognizedAsYellowTest()
        {
            var referenceBackgrounds = new ReferenceBackgrounds();
            referenceBackgrounds.Add("black", new Uri("C:\\temp\\processorTests\\black.jpg"));
            referenceBackgrounds.Add("red", new Uri("C:\\temp\\processorTests\\red.jpg"));
            referenceBackgrounds.Add("yellow", new Uri("C:\\temp\\processorTests\\yellow.jpg"));
            referenceBackgrounds.Add("green", new Uri("C:\\temp\\processorTests\\green.jpg"));
            var ip = new ImageProcessor(referenceBackgrounds);

            Assert.AreEqual("yellow", ip.GetNearestColor(new Uri("C:\\temp\\processorTests\\yellowNote.jpg")));
        }
    }
}