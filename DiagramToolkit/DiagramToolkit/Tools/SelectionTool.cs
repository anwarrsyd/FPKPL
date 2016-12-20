using DiagramToolkit.Api.Shapes;
using System.Windows.Forms;
using System;
using DiagramToolkit.Api;

namespace DiagramToolkit.Tools
{
    public class SelectionTool : Button, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;
        private int xInitial;
        private int yInitial;
        private int cumulativeMoveX;
        private int cumulativeMoveY;
        private UndoRedo undoRedo;
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

        public SelectionTool()
        {
            cumulativeMoveX = 0;
            cumulativeMoveY = 0;
            this.Name = "Selection tool";
            this.Image = IconSet.cursor;
        }

        public SelectionTool(UndoRedo undoRedo)
        {
            cumulativeMoveX = 0;
            cumulativeMoveY = 0;
            this.undoRedo = undoRedo;
            this.Name = "Selection tool";
            this.Image = IconSet.cursor;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);

                if (selectedObject != null)
                {
                    System.Diagnostics.Debug.WriteLine("hampir ini kena parent");
                    if (selectedObject.parentRectangle != null)
                    {
                        while (selectedObject.parentRectangle != null)
                        {
                            selectedObject = selectedObject.parentRectangle;
                        }
                        System.Diagnostics.Debug.WriteLine("ini kena parent");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("gak punya parent");
                    }
                }
                canvas.setActiveObject(selectedObject);
            }
           
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                if (selectedObject != null)
                {
                    int xAmount = e.X - xInitial;
                    int yAmount = e.Y - yInitial;
                    xInitial = e.X;
                    yInitial = e.Y;
                    cumulativeMoveX += xAmount;
                    cumulativeMoveY += yAmount;
                    selectedObject.Translate(xAmount, yAmount);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (selectedObject != null)
            {
                if (selectedObject is Rectangle) undoRedo.InsertInUnDoRedoForTranslate(-cumulativeMoveX, -cumulativeMoveY, (Rectangle)selectedObject);
            }
            cumulativeMoveX = 0;
            cumulativeMoveY = 0;
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
