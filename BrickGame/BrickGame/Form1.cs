using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BrickGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(300,300);
            
        }
       

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            //Graphics g = CreateGraphics();
            //Pen pen = new Pen(Color.Black);
            //Point startPoint = new Point(45, 45);
            //Point endPoint = new Point(150, 150);

            //pen.Width = 5.0f;

            //g.DrawLine(pen, startPoint, endPoint);
            //g.DrawLine(pen, 150, 45, 45, 150);

            //Graphics g = CreateGraphics();
            //Rectangle r = new Rectangle(50, 50, 150, 100);
            //g.FillRectangle(Brushes.Salmon, r);
            //g.DrawRectangle(new Pen(Color.AliceBlue), r);

            Image img = new Bitmap(Properties.Resources.Image1);
            e.Graphics.DrawImage(img, 0, 0);


        
        }
    }
}
