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
            return GetMeanIntensity( GetGrayscale( GetGrayLikeParts(input))) > 10;

        }
        
    }
}
