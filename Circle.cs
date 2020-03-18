using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP3_02
{
    class Circle : Shape
    {
        private string shapeType;

        public Circle(int size, int rColor, int gColor, int bColor) : base(size, rColor, gColor, bColor)
        {
            SetShapeType();
        }

        public string GetShapeType()
        {
            return shapeType;
        }

        public void SetShapeType()
        {
            shapeType = "Circle";
        }
    }
}
