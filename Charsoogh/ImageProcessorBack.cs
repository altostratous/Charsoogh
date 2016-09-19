using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Drawing;

namespace Charsoogh
{
    public partial class ImageProcessor
    {
        public static List<List<Image>> Output { get; set; }
        public class Image
        {
            public UnmanagedImage UnmanagedImage { get; set; }
        }
        private static Image ExtractBlueChannel(Image image)
        {
            return Apply(image, new ChannelFiltering(new AForge.IntRange(0, 0), new AForge.IntRange(0, 0), new AForge.IntRange(0, 255)));
        }
        private static Image ExtractRedChannel(Image image)
        {
            return Apply(image, new ChannelFiltering(new AForge.IntRange(0, 255), new AForge.IntRange(0, 0), new AForge.IntRange(0, 0)));
        }
        private static Image ExtractGreenChannel(Image image)
        {
            return Apply(image, new ChannelFiltering(new AForge.IntRange(0, 0), new AForge.IntRange(0, 255), new AForge.IntRange(0, 0)));
        }
        private static int GetMeanIntensity(Image image)
        {
            return (int)(new ImageStatistics(image.UnmanagedImage).Gray.Mean);
        }

        private static Image GetGrayLikeParts(Image image)
        {
            return ColorFilter(image, System.Drawing.Color.Gray, 40);
        }

        private static Image GetGrayscale(Image image)
        {
            return Apply(image, Grayscale.CommonAlgorithms.RMY);
        }
        private static int GetMinIntensity(Image image)
        {
            return (int)(new ImageStatistics(image.UnmanagedImage).Gray.Min);
        }

        private static Image ColorFilter(Image image, Color color, int range)
        {
            return Apply(image, new  ColorFiltering(new AForge.IntRange(color.R - range, color.R + range), new AForge.IntRange(color.G - range, color.G + range), new AForge.IntRange(color.G - range, color.G + range)));
        }

        private static int GetMaxIntensity(Image image)
        {
            return (int)(new ImageStatistics(image.UnmanagedImage).Gray.Max);
        }
        public static Image GetEdges(Image image)
        {
            return Apply(image, new HomogenityEdgeDetector());
        }

        public static Image GetEqualizedImage(Image image)
        {
            return Apply(image, new HistogramEqualization());
        }



        private static Image GetDownerSide(Image image)
        {
            Rectangle rect = new Rectangle(0, image.UnmanagedImage.Height / 2, image.UnmanagedImage.Width, image.UnmanagedImage.Height / 2);
            return Apply(image, new Crop(rect));
        }
        public static Image GetUpperSide(Image image)
        {
            Rectangle rect = new Rectangle(0, 0, image.UnmanagedImage.Width, image.UnmanagedImage.Height / 2);
            return Apply(image, new Crop(rect));
        }

        private  static Image Apply(Image image, IFilter filter)
        {
            Image output = new Image() { UnmanagedImage = filter.Apply(image.UnmanagedImage) };
            Output.Last().Add(output);
            return output;
        }


        public static List<bool> Process(List<Image> input, List<bool> answer)
        {
            List<bool> result = new List<bool>();
            foreach (Image image in input)
            {
                ImageProcessor.Output.Add(new List<Image>());
                ImageProcessor.Output.Last().Add(image);
                result.Add(Decide(image));
            }
            return result;
        }
    }
}
