using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace DiagramToolkit.Api.Shapes
{
    public class Rectangle : Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        //untuk composite pattern
        public List<DrawingObject> listChildObject;

        private Pen pen;
        private String selectedSvg;
        public Rectangle()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            listChildObject = new List<DrawingObject>();
        }

        public Rectangle(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
            listChildObject = new List<DrawingObject>();
        }

        public Rectangle(int x, int y, String selectedSvg) : this()
        {
            this.X = x;
            this.Y = y;
            this.selectedSvg = selectedSvg;
            listChildObject = new List<DrawingObject>();
        }

        public Rectangle(int x, int y, int width, int height) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
            listChildObject = new List<DrawingObject>();
        }

        public Rectangle(int x, int y, int width, int height, String selectedSvg) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
            this.selectedSvg = selectedSvg;
            listChildObject = new List<DrawingObject>();
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X + Width) && (yTest >= Y && yTest <= Y + Height))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override Point GetIntersectionPoint(Point p1, Point p2)
        {
            Point P = new Point();
            //kiri atas sampe kanan atas
            int A1 = p2.Y - p1.Y;
            int B1 = p1.X - p2.X;
            int A2 = 0;
            int B2 = -this.Width;
            int C1 = A1 * p1.X + B1 * p1.Y;
            int C2 = A2 * this.X + B2 * this.Y;
            double det = A1 * B2 - A2 * B1;
            if (det != 0)
            {
                double x = (B2 * C1 - B1 * C2) / det;
                double y = (A1 * C2 - A2 * C1) / det;
                if ( Math.Min(p1.X, p2.X) <= x && x <= Math.Max(p1.X, p2.X) )
                {
                    P.X = (int)x;
                    P.Y = (int)y;
                    return P;
                }

            }
            //kanan atas sampe kanan bawah
            A2 = -this.Height;
            B2 = 0;
            C1 = A1 * p1.X + B1 * p1.Y;
            C2 = A2 * (this.X+this.Width) + B2 * this.Y;
            det = A1 * B2 - A2 * B1;
            if (det != 0)
            {
                double x = (B2 * C1 - B1 * C2) / det;
                double y = (A1 * C2 - A2 * C1) / det;
                if (Math.Min(p1.X, p2.X) <= x && x <= Math.Max(p1.X, p2.X))
                {
                    P.X = (int)x;
                    P.Y = (int)y;
                    return P;
                }

            }

            //kanan bawah sampe kiri bawah
            A2 = 0;
            B2 = this.Width;
            C1 = A1 * p1.X + B1 * p1.Y;
            C2 = A2 * (this.X + this.Width) + B2 * (this.Y + this.Height);
            det = A1 * B2 - A2 * B1;
            if (det != 0)
            {
                double x = (B2 * C1 - B1 * C2) / det;
                double y = (A1 * C2 - A2 * C1) / det;
                if (Math.Min(p1.X, p2.X) <= x && x <= Math.Max(p1.X, p2.X))
                {
                    P.X = (int)x;
                    P.Y = (int)y;
                    return P;
                }

            }

            //kiri bawah sampe kiri atas
            A2 = this.Height;
            B2 = 0;
            C1 = A1 * p1.X + B1 * p1.Y;
            C2 = A2 * this.X + B2 * (this.Y + this.Height);
            det = A1 * B2 - A2 * B1;
            if (det != 0)
            {
                double x = (B2 * C1 - B1 * C2) / det;
                double y = (A1 * C2 - A2 * C1) / det;
                if (Math.Min(p1.X, p2.X) <= x && x <= Math.Max(p1.X, p2.X))
                {
                    P.X = (int)x;
                    P.Y = (int)y;
                    return P;
                }

            }
            return P;
        }

        public override void RenderOnStaticView()
        {
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;
            var img = Svg.SVGParser.GetBitmapFromSVG(selectedSvg);
            Graphics.DrawImage(img, X, Y, Width, Height);
        }

        public override void RenderOnEditingView()
        {
            this.pen.Color = Color.FromArgb(50,250,10);
            this.pen.DashStyle = DashStyle.Solid;
            var img = Svg.SVGParser.GetBitmapFromSVG(selectedSvg);
            Graphics.DrawImage(img, X, Y, Width, Height);
            Graphics.DrawRectangle(this.pen, X, Y, Width, Height);
        }

        public override void RenderOnPreview()
        {
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;
            var img = Svg.SVGParser.GetBitmapFromSVG(selectedSvg);
            Graphics.DrawImage(img, X, Y, Width, Height);
        }

        public override void Translate(int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;
            if (listChildObject.Count > 0)
            {
                foreach(DrawingObject obj in listChildObject)
                {
                    obj.Translate(xAmount, yAmount);
                    Debug.WriteLine("child geser " + xAmount.ToString() + " " + yAmount.ToString());
                }
            }
            else
            {
                Debug.WriteLine("parent geser "+xAmount.ToString()+" "+yAmount.ToString());
            }
            BroadcastUpdate(xAmount, yAmount);
        }
        public void addComponent(DrawingObject child)
        {
            this.listChildObject.Add(child);
            child.parentRectangle = this;
        }
        public void removeComponent(DrawingObject child)
        {
            this.listChildObject.Remove(child);
            child.parentRectangle = null;
        }
    }
}
