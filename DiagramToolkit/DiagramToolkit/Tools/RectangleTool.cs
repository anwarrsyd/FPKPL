using DiagramToolkit.Shapes;
using System;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public class RectangleTool : Button, ITool
    {
        private ICanvas canvas;
        private Rectangle rectangle;
        private String selectedSvg;
        private int width, height;
        private UndoRedo undoredo;
        private bool mousedown;

        public Cursor iniCursor
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

        public RectangleTool(String selectedSvg)
        {
            this.Name = "Rectangle tool";
            this.selectedSvg = selectedSvg;
        }

        public RectangleTool(int width, int height, String selectedSvg, UndoRedo undoredo)
        {
            Name = "Rectangle tool";
            this.selectedSvg = selectedSvg;
            this.width = width;
            this.height = height;
            this.undoredo = undoredo;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mousedown = true;
                this.rectangle = new Rectangle((int)e.X-width/2, (int)e.Y-height/2, width, height, selectedSvg);
                this.canvas.AddDrawingObject(this.rectangle);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e) {
            //default
        }

        //public void ToolMouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        if (this.rectangle != null)
        //        {
        //            int width = e.X - this.rectangle.X;
        //            int height = e.Y - this.rectangle.Y;

        //            if (width > 0 && height > 0)
        //            {
        //                this.rectangle.Width = width;
        //                this.rectangle.Height = height;
        //            }
        //        }
        //    }
        //}

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (rectangle != null)
            {
                if (e.Button == MouseButtons.Left)
                {

                    this.rectangle.Select();
                    if (mousedown)
                    {
                        undoredo.InsertInUnDoRedoForInsert(rectangle, canvas);
                        mousedown = false;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.rectangle);
                }
            }
        }
    }
}
