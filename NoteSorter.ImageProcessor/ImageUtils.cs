namespace NoteSorter.ImageProcessor
{
    using System;
    using System.Drawing;
    using System.Windows.Media.Imaging;

    public class ImageUtils
    {
        public static Color CalculateAverageColorFor(Uri image)
        {
            var jpgImage = new JpegBitmapDecoder(image, BitmapCreateOptions.DelayCreation, BitmapCacheOption.OnLoad);
            int width = jpgImage.Frames[0].PixelWidth;
            int height = jpgImage.Frames[0].PixelHeight;
            var imgBytes = new byte[width * 4 * height];
            jpgImage.Frames[0].CopyPixels(imgBytes, width * 4, 0);
            long sumB = 0, sumG = 0, sumR = 0;
            for (int x = 0; x < height * width; x++)
            {

                int p = x * 4;
                byte b = imgBytes[p + 0];
                byte g = imgBytes[p + 1];
                byte r = imgBytes[p + 2];
                sumB += b;
                sumG += g;
                sumR += r;

            }

            long avgb = sumB / (width * height);
            long avgg = sumG / (width * height);
            long avgr = sumR / (width * height);
            return Color.FromArgb(0, (int)avgr, (int)avgg, (int)avgb);
        }

        public static double DistanceBetween(Color c1, Color c2)
        {
            return Math.Sqrt((c2.R - c1.R) * (c2.R - c1.R) + (c2.G - c1.G) * (c2.G - c1.G) + (c2.B - c1.B) * (c2.B - c1.B));
        }
    }
}