using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace lab3
{
    public partial class Form1 : Form
    {

        bool isDown = false;
        public Point point1;
        public Point point2;

        List<Figure> arr = new List<Figure>();

        Rect rect = new Rect(Point.Empty, Point.Empty);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left) { return; }
            isDown = true;

            rect.point1 = new Point(e.X, e.Y);    
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDown) return;

            Graphics g = CreateGraphics();

            rect.MouseMove(g, new Point(e.X, e.Y));


        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            isDown = false;

            Graphics g = CreateGraphics();

            rect.Draw(g);

            arr.Add(rect);
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (Figure f in arr)
            {
                rect.Hide(g, f);
            }
        }
    }
}
