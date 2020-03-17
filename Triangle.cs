using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP3_02
{
    class Triangle
    {

		private int x1;     //Bottom left, bottom right, top
		private int x2;
		private int x3;


		private int y1;
		private int y2;
		private int y3;


		private int size;

		private int r;
		private int g;
		private int b;



		public Triangle()
		{
			x1 = x2 = x3 = y1 = y2 = y3 = size = r = g = b = 0;       //Sets all vars to 0
		}


		public Triangle(int SIZE, int X, int Y, int R, int G, int B)
		{
			if (SIZE > 0)
			{
				size = SIZE;
			}
			SetColors(R, G, B);
			SetPoints(X, Y);

		}

		private void SetColors(int red, int blue, int green)    //Check to see if color vals are valid and if not, set them to 0
		{
			if (red > 255 || red < 0)
			{
				r = 0;          //Default to 0 for now
			}
			else
			{
				r = red;
			}
			if (blue > 255 || blue < 0)
			{
				b = 0;
			}
			else
			{
				b = blue;
			}
			if (green > 255 || green < 0)
			{
				g = 0;
			}
			else
			{
				g = green;
			}
		}



		public void SetPoints(int x, int y)         //Takes in inputted x and y vals with size to set up the corners of the shape
		{
			x1 = x;	//Starts at bottom left corner, size is the height and base
			y1 = y;

			x2 = x + size;
			y2 = y1;

			x3 = x + (size / 2);
			y3 = y + size;

		}

		public int GetXVal(int num) //gets an x val
		{
			switch (num)
			{
				case (1):
					return x1;
				case (2):
					return x2;
				case (3):
					return x3;
				default:
					break;
			}
			return 0;
		}
		public int GetYVal(int num) //gets y val
		{
			switch (num)
			{
				case (1):
					return y1;
				case (2):
					return y2;
				case (3):
					return y3;
				default:
					break;

			}
			return 0;
		}

		public int GetRed()
		{
			return r;
		}
		public int GetGreen()
		{
			return g;
		}
		public int GetBlue()
		{
			return b;
		}

	}






}

