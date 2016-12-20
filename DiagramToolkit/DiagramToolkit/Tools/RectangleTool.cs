using DiagramToolkit.Api;
using DiagramToolkit.Api.Shapes;
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
                if (canvas.GetObjectAt(e.X, e.Y) == null)
                {
                    this.rectangle = new Rectangle((int)e.X - width / 2, (int)e.Y - height / 2, width, height, selectedSvg);
                    this.canvas.AddDrawingObject(this.rectangle);
                }
                else
                {
                    this.rectangle = new Rectangle((int)e.X - width / 2, (int)e.Y - height / 2, width, height, selectedSvg);
                    this.canvas.AddDrawingObject(this.rectangle);
                }
                mousedown = true;
                if (mousedown)
                {
                    undoredo.InsertInUnDoRedoForInsert(rectangle, canvas);
                    mousedown = false;
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e) {
            //default
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (rectangle != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.rectangle.iniSelect();
                    //if (mousedown)
                    //{
                    //    undoredo.InsertInUnDoRedoForInsert(rectangle, canvas);
                    //    mousedown = false;
                    //}
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.rectangle);
                    mousedown = true;
                    if (mousedown)
                    {
                        undoredo.InsertInUnDoRedoForDelete(rectangle, canvas);
                        mousedown = false;
                    }
                }
            }
        }
        
        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
