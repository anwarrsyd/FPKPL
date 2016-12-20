using System;
using System.Drawing;
using System.Collections.Generic;

namespace DiagramToolkit.Api.Shapes
{
    public class Text : DrawingObject
    {
        public string Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private Brush brush;
        private Font font;
        private SizeF textSize;
        public List<DrawingObject> listChildObject;

        public Text()
        {
            this.brush = new SolidBrush(Color.Black);

            FontFamily fontFamily = new FontFamily("Roboto");
            font = new Font(
               fontFamily,
               17,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            listChildObject = new List<DrawingObject>();
        }

        public Text(int x, int y)
        {
            this.brush = new SolidBrush(Color.Black);

            FontFamily fontFamily = new FontFamily("Roboto");
            font = new Font(
               fontFamily,
               17,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            listChildObject = new List<DrawingObject>();

            this.X = x;
            this.Y = y;
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

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X + textSize.Width) && (yTest >= Y && yTest <= Y + textSize.Height))
            {
                //System.Diagnostics.Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override void RenderOnEditingView()
        {
            Graphics.DrawString(Value, font, brush, new PointF(X, Y));
            textSize = Graphics.MeasureString(Value, font);
        }

        public override void RenderOnPreview()
        {
            Graphics.DrawString(Value, font, brush, new PointF(X, Y));
            textSize = Graphics.MeasureString(Value, font);
        }

        public override void RenderOnStaticView()
        {
            Graphics.DrawString(Value, font, brush, new PointF(X, Y));
            textSize = Graphics.MeasureString(Value, font);
        }

        public override void Translate(int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;
        }

        public override Point GetIntersectionPoint(Point p1, Point p2)
        {
            throw new NotImplementedException();
        }

    }
}
