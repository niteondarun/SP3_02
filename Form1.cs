/*
 * This program allows the user to print filled shapes on a panel. 
 * The user can specify the size, location, and color of four different shapes.
 * The user can also change the background color.
 * 
 * Authors: Sean Derba, Cody Peretti, Paul Wood
 */




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

        ColorDialog ColorSelect = new ColorDialog(); //for user to select pen color
        ColorDialog BackgroundColorSelect = new ColorDialog(); //for user to select background color
        Pen drawPen = new Pen(Color.Red); //initialize pen
        new Color RGB; //declare color to pull from input later
        string promptValue = ""; //used to gather width and height from user
        int shape = 0; //determines button press
        int RedColor, BlueColor, GreenColor; //integer values for {Color RGB} defined above


        //click Paint button to choose your pen color
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

        //click Background button to choose background color
        private void btn_BackgroundColor_Click_Click(object sender, EventArgs e)
        {
            if (BackgroundColorSelect.ShowDialog() == DialogResult.OK)
            {
                panel2.BackColor = BackgroundColorSelect.Color;
                btn_BackgroundColor_Click.BackColor = BackgroundColorSelect.Color;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)  //Does the actual painting
        {
            Graphics g = e.Graphics;
            drawPen.Color = RGB;
            drawPen.Width = 3;

            SolidBrush brush = new SolidBrush(RGB);

            int size = int.Parse(TxtBox_SizeInput_Type.Text); //get size from size user text box
            int x = int.Parse(textBox1.Text); //get x location
            int y = int.Parse(textBox2.Text); //get y location

            if (shape == 1) //when the square button is clicked
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
            if(shape == 3) //when triangle button is clicked
            {
                int x1 = int.Parse(textBox1.Text);
                int y1 = int.Parse(textBox2.Text);
                Point p1 = new Point(x1 - (size / 2), y1);
                Point p2 = new Point(x1 + (size / 2), y1);
                Point p3 = new Point(x1, y1 + size);
                Point[] pArray = new Point[3] { p1, p2, p3 };

                g.DrawPolygon(drawPen, pArray);
                g.FillPolygon(brush, pArray);
            }
            if(shape == 4) //when rectangle button is clicked
            {
                int width = int.Parse(promptValue.Split().ElementAt<string>(0)); //value called from class promptValue
                int height = int.Parse(promptValue.Split().ElementAt<string>(1)); //value called from class promptValue
                g.DrawRectangle(drawPen, x, y, width, height);
                g.FillRectangle(brush, x, y, width, height);
            }
        }

        private void btn_Trapezoid_Click_Click(object sender, EventArgs e)  //Actually circle_click
        {
            shape = 2;      //Tells paint to draw a circle
            int size = int.Parse(TxtBox_SizeInput_Type.Text);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            Rectangle z = new Rectangle(x, y, size, size);
            panel2.Invalidate(z);
        }

        private void btn_Triangle_Click_Click(object sender, EventArgs e) //triangle_click
        {
            shape = 3; //tells paint to draw triangle
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

        private void btn_Rectangle_Click_Click(object sender, EventArgs e) //rectangle click
        {
            promptValue = Prompt.ShowDialog("Width", "Height", "Rectangle"); //calls for c=values from class promptValue
            shape = 4; //tells paint to draw rectangle
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            int width = int.Parse(promptValue.Split().ElementAt<string>(0));
            int height = int.Parse(promptValue.Split().ElementAt<string>(1));
            Rectangle rec = new Rectangle(x, y, width, height);
            panel2.Invalidate(rec);
        }

        private void btn_Square_Click_Click(object sender, EventArgs e) //square_click
        {
            shape = 1;      //Tells paint to draw a square
            int size = int.Parse(TxtBox_SizeInput_Type.Text);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            Rectangle z = new Rectangle(x, y, size, size);
            panel2.Invalidate(z);
        }

        public static class Prompt //class that opens another form to get addition inputs needed to draw rectangle
        {
            public static string ShowDialog(string width, string height, string caption) //these strings for display purposes only
            {
                string WidthAndHeight = ""; //for storing user input
                Form prompt = new Form() //defines user input prompt form
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };

                //the following are declared components
                Label WidthLabel = new Label() { Left = 50, Top = 20, Text = width };
                Label HeightLabel = new Label() { Left = 200, Top = 20, Text = height };
                TextBox widthBox = new TextBox() { Left = 50, Top = 50, Width = 100 };
                TextBox heightBox = new TextBox() { Left = 200, Top = 50, Width = 100 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };

                //declared components are initialized (utilized) here
                prompt.Controls.Add(widthBox);
                prompt.Controls.Add(heightBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(WidthLabel);
                prompt.Controls.Add(HeightLabel);
                prompt.AcceptButton = confirmation;

                //when user clicks okay
                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    WidthAndHeight = widthBox.Text + " " + heightBox.Text; //puts both text strings to one string
                }

                return WidthAndHeight; //returns single string to split later for rectangle width and height
            }
        }
    }
}
