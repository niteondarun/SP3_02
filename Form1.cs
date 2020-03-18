using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        

        private void btn_Square_Click_Click(object sender, EventArgs e)
        {
            shape = 1;      //Tells paint to draw a square
            int size = int.Parse(TxtBox_SizeInput_Type.Text);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            Rectangle z = new Rectangle(x, y, size, size);
            panel2.Invalidate(z);
        }

        private void btn_Square_Click_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            drawPen.Color = RGB;
            drawPen.Width = 8;
            int size = int.Parse(TxtBox_SizeInput_Type.Text);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            if (shape == 1)
            {
                g.DrawRectangle(drawPen, x, y, size, size);
            }

        }

        private void btn_BackgroundColor_Click_Click(object sender, EventArgs e)
        {
            if (BackgroundColorSelect.ShowDialog() == DialogResult.OK)
            {
                panel2.BackColor = BackgroundColorSelect.Color;
                btn_BackgroundColor_Click.BackColor = BackgroundColorSelect.Color;
            }
        }


        /// ////////////////////////////////////////////////////////////////////////////////////////
        //added trying to figure stuff out, have to keep it. probably wont use it
        private void btn_Rectangle_Click_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
