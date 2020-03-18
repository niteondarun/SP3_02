using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SP3_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ColorDialog ColorSelect = new ColorDialog();
        ColorDialog BackgroundColorSelect = new ColorDialog();
        Pen drawPen = new Pen(Color.Red);
        new Color RGB;
        
        int shape = 0;

        int RedColor, BlueColor, GreenColor;

        private void btn_PaintColor_Click_Click(object sender, EventArgs e)
        {
            if (ColorSelect.ShowDialog() == DialogResult.OK)
            {
                btn_PaintColor_Click.BackColor = ColorSelect.Color;
                RGB = ColorSelect.Color;
                RedColor = RGB.R;
                BlueColor = RGB.B;
                GreenColor = RGB.G;
            }
        }
        



        private void panel2_Paint(object sender, PaintEventArgs e)  //Does the actual painting
        {
            Graphics g = e.Graphics;
            drawPen.Color = RGB;
            drawPen.Width = 3;

            SolidBrush brush = new SolidBrush(RGB);

            int size = int.Parse(TxtBox_SizeInput_Type.Text);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            if (shape == 1) //When the suqare button is clicked
            {
                g.DrawRectangle(drawPen, x, y, size, size);
                g.FillRectangle(brush, x, y, size, size);
            }
            if(shape == 2)  //When the circle button is clicked
            {
                Rectangle r = new Rectangle(x, y, size, size);
                g.DrawEllipse(drawPen, r);
                g.FillEllipse(brush, r);
            }
            if(shape == 3)
            {
                int x1 = int.Parse(textBox1.Text);
                int y1 = int.Parse(textBox2.Text);
                Point p1 = new Point(x1 - (size/2), y1);
                Point p2 = new Point(x1 + (size / 2), y1);
                Point p3 = new Point(x1, y1 + size);
                Point[] pArray = new Point[3] { p1, p2, p3 };

                g.DrawPolygon(drawPen, pArray);
                g.FillPolygon(brush, pArray);
            }
            if(shape == 4)
            {

            }
        }

        private void btn_Trapezoid_Click_Click(object sender, EventArgs e)      //Actually just circle
        {
            shape = 2;      //Tells paint to draw a circle
            int size = int.Parse(TxtBox_SizeInput_Type.Text);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            Rectangle z = new Rectangle(x, y, size, size);
            panel2.Invalidate(z);
        }

        private void btn_Triangle_Click_Click(object sender, EventArgs e)
        {
            shape = 3;
            int size = int.Parse(TxtBox_SizeInput_Type.Text);
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            Point p1 = new Point(x1 - (size / 2), y1);
            Point p2 = new Point(x1 + (size / 2), y1);
            Point p3 = new Point(x1, y1 + size);
            Point[] pArray = new Point[3] { p1, p2, p3 };

            byte[] bArray = new byte[3] { 1, 1, 1 };

            GraphicsPath test = new GraphicsPath(pArray, bArray);

            Region r = new Region(test);
            panel2.Invalidate(r);
        }

        private void btn_Square_Click_Click(object sender, EventArgs e)
        {
            shape = 1;      //Tells paint to draw a square
            int size = int.Parse(TxtBox_SizeInput_Type.Text);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            Rectangle z = new Rectangle(x, y, size, size);
            panel2.Invalidate(z);
        }

        private void btn_BackgroundColor_Click_Click(object sender, EventArgs e)
        {
            if (BackgroundColorSelect.ShowDialog() == DialogResult.OK)
            {
                panel2.BackColor = BackgroundColorSelect.Color;
                btn_BackgroundColor_Click.BackColor = BackgroundColorSelect.Color;
            }
        }
    }
}
