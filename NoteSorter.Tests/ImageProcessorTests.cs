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
            referenceBackgrounds.Add("yellow", new Uri("resources\\yellow.jpg", UriKind.Relative));
            referenceBackgrounds.Add("black", new Uri("resources\\black.jpg", UriKind.Relative));
            referenceBackgrounds.Add("red", new Uri("resources\\red.jpg", UriKind.Relative));
            referenceBackgrounds.Add("green", new Uri("resources\\green.jpg", UriKind.Relative));
            var ip = new ImageProcessor(referenceBackgrounds);

            Assert.AreEqual("red", ip.GetNearestColor(new Uri("resources\\pink.jpg", UriKind.Relative)));
        }

        [Test]
        public void DarkGreyShouldBeRecognizedAsBlackTest()
        {
            var referenceBackgrounds = new ReferenceBackgrounds();
            referenceBackgrounds.Add("black", new Uri("resources\\black.jpg", UriKind.Relative));
            referenceBackgrounds.Add("red", new Uri("resources\\red.jpg", UriKind.Relative));
            referenceBackgrounds.Add("green", new Uri("resources\\green.jpg", UriKind.Relative));
            referenceBackgrounds.Add("yellow", new Uri("resources\\yellow.jpg", UriKind.Relative));
            var ip = new ImageProcessor(referenceBackgrounds);

            Assert.AreEqual("black", ip.GetNearestColor(new Uri("resources\\darkGrey.jpg", UriKind.Relative)));
        }

        [Test]
        public void PhotoYellowNoteShouldBeRecognizedAsYellowTest()
        {
            var referenceBackgrounds = new ReferenceBackgrounds();
            referenceBackgrounds.Add("black", new Uri("resources\\black.jpg", UriKind.Relative));
            referenceBackgrounds.Add("red", new Uri("resources\\red.jpg", UriKind.Relative));
            referenceBackgrounds.Add("yellow", new Uri("resources\\yellow.jpg", UriKind.Relative));
            referenceBackgrounds.Add("green", new Uri("resources\\green.jpg", UriKind.Relative));
            var ip = new ImageProcessor(referenceBackgrounds);

            Assert.AreEqual("yellow", ip.GetNearestColor(new Uri("resources\\yellowNote.jpg", UriKind.Relative)));
        }
    }
}