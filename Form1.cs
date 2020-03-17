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
        

        int RedColor, BlueColor, GreenColor;

        private void btn_PaintColor_Click_Click(object sender, EventArgs e)
        {
            if (ColorSelect.ShowDialog() == DialogResult.OK)
            {
                btn_PaintColor_Click.BackColor = ColorSelect.Color;
                Color RGB = btn_BackgroundColor_Click.BackColor;
                RedColor = RGB.R;
                BlueColor = RGB.B;
                GreenColor = RGB.G;
            }
        }
        

        private void btn_Square_Click_Click(object sender, EventArgs e)
        {
            //panel2.Invalidate();
        }

        private void btn_Square_Click_Paint(object sender, PaintEventArgs e)
        {
            panel2.Invalidate();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen drawPen = new Pen(Color.FromArgb(RedColor, BlueColor, GreenColor));
            drawPen.Width = 8;
            int size = int.Parse(TxtBox_SizeInput_Type.Text);
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            g.DrawRectangle(drawPen, x, y, size, size);
        }

        private void btn_BackgroundColor_Click_Click(object sender, EventArgs e)
        {
            if (ColorSelect.ShowDialog() == DialogResult.OK)
            {
                panel2.BackColor = ColorSelect.Color;
                btn_BackgroundColor_Click.BackColor = ColorSelect.Color;
            }
        }

        //added trying to figure stuff out, have to keep it. probably wont use it
        private void btn_Rectangle_Click_Paint(object sender, PaintEventArgs e)
        {
            
        }

        
    }
}
