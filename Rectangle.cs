//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SP3_02
//{
//    class Rectangle
//    {
//		private int x1;     //Goes top left corner, bottom left, bottom right, then top right
//		private int x2;
//		private int x3;
//		private int x4;

//		private int y1;
//		private int y2;
//		private int y3;
//		private int y4;

//		private int size;

//		private int r;
//		private int g;
//		private int b;



//		public Rectangle()
//		{
//			x1 = x2 = x3 = x4 = y1 = y2 = y3 = y4 = size = r = g = b = 0;       //Sets all vars to 0
//		}


//		public Rectangle(int SIZE, int X, int Y, int R, int G, int B)
//		{

//			size = SIZE;
//			SetColors(R, G, B);
//			SetPoints(X, Y);

//		}

//		private void SetColors(int red, int blue, int green)    //Check to see if color vals are valid and if not, set them to 0
//		{
//			if (red > 255 || red < 0)
//			{
//				r = 0;          //Default to 0 for now
//			}
//			else
//			{
//				r = red;
//			}
//			if (blue > 255 || blue < 0)
//			{
//				b = 0;
//			}
//			else
//			{
//				b = blue;
//			}
//			if (green > 255 || green < 0)
//			{
//				g = 0;
//			}
//			else
//			{
//				g = green;
//			}
//		}



//		public void SetPoints(int x, int y)         //Takes in inputted x and y vals with size to set up the corners of the shape
//		{
//			int b = size;		//Base + height of rectangle, decided to use a ratio of base will be double height
//			int h = size / 2;

//			x1 = x;
//			y1 = y;

//			x2 = x;
//			y2 = y - h;

//			x3 = x + b;
//			y3 = y - h;

//			x4 = x + b;
//			y4 = y;

//		}

//		public int GetXVal(int num) //gets an x val
//		{
//			switch (num)
//			{
//				case (1):
//					return x1;
//				case (2):
//					return x2;
//				case (3):
//					return x3;
//				case (4):
//					return x4;
//				default:
//					break;
//			}
//			return 0;
//		}
//		public int GetYVal(int num) //gets y val
//		{
//			switch (num)
//			{
//				case (1):
//					return y1;
//				case (2):
//					return y2;
//				case (3):
//					return y3;
//				case (4):
//					return y4;

//			}
//			return 0;
//		}

//		public int GetRed()
//		{
//			return r;
//		}
//		public int GetGreen()
//		{
//			return g;
//		}
//		public int GetBlue()
//		{
//			return b;
//		}
//	}
//}
