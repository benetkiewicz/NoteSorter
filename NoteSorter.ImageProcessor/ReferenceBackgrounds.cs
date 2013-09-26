namespace NoteSorter.ImageProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class ReferenceBackgrounds
    {
        private IDictionary<string, Uri> referenceBackgroundImages;

        public ReferenceBackgrounds()
        {
            this.referenceBackgroundImages = new Dictionary<string, Uri>();
        }

        public void Add(string backgroundLabel, Uri referenceBackgroundImage)
        {
            this.referenceBackgroundImages.Add(backgroundLabel, referenceBackgroundImage);
        }

        public IDictionary<string, Color> GetAverageColors()
        {
            var result = new Dictionary<string, Color>();
            foreach (var referenceBackgroundImage in this.referenceBackgroundImages.Keys)
            {
                result.Add(referenceBackgroundImage, ImageUtils.CalculateAverageColorFor(this.referenceBackgroundImages[referenceBackgroundImage]));
            }

            return result;
        } 
    }
}