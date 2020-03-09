using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP3_02
{
    class Shape
    {
        public Shape(int size, int rColor, int gColor, int bColor)
        {
            SizeOfShape = size;
            RedColor = rColor;
            GreenColor = gColor;
            BlueColor = bColor;
        }

        public int SizeOfShape { get; set; }
        public int RedColor { get; set; }
        public int GreenColor { get; set; }
        public int BlueColor { get; set; }
    }
}
