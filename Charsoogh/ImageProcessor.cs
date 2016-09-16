using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charsoogh
{
    public partial class ImageProcessor
    {
        public static bool Decide(Image input)
        {
            input = GetUpperSide(GetUpperSide(input));
            int red = GetMaxIntensity(GetGrayscale(ExtractRedChannel(input)));
            int blue = GetMaxIntensity(GetGrayscale(ExtractBlueChannel(input)));
            Console.WriteLine(red - blue);
            if (red - blue > 30)return true;
            return false;
        }
        
    }
}
