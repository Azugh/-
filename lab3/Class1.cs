using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    abstract class Figure
    {
        protected List<Figure> figures = new List<Figure>();

        protected Point previousPoint = Point.Empty;

        bool isDown = false;

        public Point point1 { get; set; }
        public Point point2 { get; set; }

        public Figure(Point point1, Point point2)
        {

            this.point1 = point1;
            this.point2 = point2;
        }

        abstract public void MouseMove(Graphics g, Point point2);

        abstract public void drawFigure(Graphics g, Pen pen, Point point1, Point point2);
        abstract public void NikitasMoms(Graphics g, Pen pen, Point p1, Point p2);
        abstract public void Draw(Graphics g);
        abstract public void DrawDash(Graphics g, Point point2);
        abstract public void Hide(Graphics g, Figure fig);
    }


    class Rect : Figure
    {

        private Pen black = new Pen(Color.Black);
        private Pen white = new Pen(Color.White);
        private Pen red = new Pen(Color.Red);

        public Rect(Point point1, Point point2) : base(point1, point2) { }


        public override void drawFigure(Graphics g, Pen pen, Point point1, Point point2)
        {

            RectangleF rectf = new RectangleF(Math.Min(point1.X, point2.X),
                  Math.Min(point1.Y, point2.Y),
                  Math.Abs(point1.X - point2.X),
                  Math.Abs(point1.Y - point2.Y));

            g.DrawRectangles(black, new[] { rectf });
        }

        public override void NikitasMoms(Graphics g, Pen pen, Point p1, Point p2)
        {

            g.DrawLine(pen, p1.X, p1.Y, p1.X, p2.Y);
            g.DrawLine(pen, p1.X, p1.Y, p2.X, p1.Y);
            g.DrawLine(pen, p2.X, p2.Y, p2.X, p1.Y);
            g.DrawLine(pen, p2.X, p2.Y, p1.X, p2.Y);
        }

        public override void Draw(Graphics g)
        {
            previousPoint = Point.Empty;


            Figure fig = new Rect(point1, point2);

            figures.Add(fig);

            //NikitasMoms(g, black, point1, point2);
            

        }

        public override void DrawDash(Graphics g, Point point2)
        {

            this.point2 = point2;

            float[] dashValues = { 4, 2 };
            Pen dashPen = new Pen(Color.Black, 1);
            dashPen.DashPattern = dashValues;

            foreach (Figure figure in figures)
            {
                drawFigure(g, black, figure.point1, figure.point2);
            }

            NikitasMoms(g, white, point1, previousPoint);


            previousPoint = point2;

            NikitasMoms(g, dashPen, point1, point2);

           

        }

        public override void Hide(Graphics g, Figure fig)
        {

            //   Console.WriteLine(fig.point2.ToString() + " " + fig.point1.ToString());
            NikitasMoms(g, black, fig.point1, fig.point2);
        }

        public override void MouseMove(Graphics g, Point point2)
        {

            DrawDash(g, point2);

        }

        
    }
}
