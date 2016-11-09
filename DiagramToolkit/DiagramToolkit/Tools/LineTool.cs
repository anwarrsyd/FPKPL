using DiagramToolkit.Shapes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class LineTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private LineSegment lineSegment;
        private DrawingObject startingObject, endingObject;
        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public LineTool()
        {
            this.Name = "Stateful Line tool";
            this.ToolTipText = "Stateful Line tool";
            this.Image = IconSet.diagonal_line;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lineSegment = new LineSegment(new System.Drawing.Point(e.X, e.Y));
                lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                canvas.AddDrawingObject(lineSegment);
                Debug.WriteLine(e.X + " " + e.Y);
                startingObject = canvas.GetObjectAt(e.X, e.Y);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.lineSegment != null)
                {
                    lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.lineSegment != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point P = new Point();
                    lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                    lineSegment.Select();
                    endingObject = canvas.GetObjectAt(e.X, e.Y);
                    if (startingObject != null)
                    {
                        P = startingObject.GetIntersectionPoint(lineSegment.Startpoint, lineSegment.Endpoint);
                    }
                    lineSegment.Startpoint = new System.Drawing.Point(P.X, P.Y);
                    if (endingObject!= null)
                    {
                        P = endingObject.GetIntersectionPoint(lineSegment.Startpoint, lineSegment.Endpoint);
                    }
                    lineSegment.Endpoint = new System.Drawing.Point(P.X, P.Y);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.lineSegment);
                }
            }
        }
    }
}
