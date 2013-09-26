namespace NoteSorter.ImageProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class ImageProcessor
    {
        private readonly ReferenceBackgrounds referenceBackgrounds;

        public ImageProcessor(ReferenceBackgrounds referenceBackgrounds)
        {
            this.referenceBackgrounds = referenceBackgrounds;
        }

        public string GetNearestColor(Uri image)
        {
            Color imageColor = ImageUtils.CalculateAverageColorFor(image);
            double max = double.MaxValue;
            IDictionary<string,Color> dictionary = this.referenceBackgrounds.GetAverageColors();
            string result = null;
            foreach (var referenceColor in dictionary.Keys)
            {
                double distance = ImageUtils.DistanceBetween(imageColor, dictionary[referenceColor]);
                if (distance < max)
                {
                    max = distance;
                    result = referenceColor;
                }
            }

            return result;
        }
    }
}