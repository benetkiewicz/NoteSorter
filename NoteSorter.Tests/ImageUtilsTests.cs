namespace NoteSorter.Tests
{
    using System;
    using System.Drawing;

    using NUnit.Framework;

    using NoteSorter.ImageProcessor;

    [TestFixture]
    public class ImageUtilsTests
    {
        [Test]
        public void AverageRedShouldBeCalculatedCorrectly()
        {
            Color red = Color.FromArgb(228, 2, 4);
            Color result = ImageUtils.CalculateAverageColorFor(new Uri("C:\\temp\\processorTests\\red.jpg"));

            Assert.AreEqual(red.B, result.B);
            Assert.AreEqual(red.G, result.G);
            Assert.AreEqual(red.R, result.R);
        } 
    }
}