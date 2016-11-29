using DiagramToolkit.Shapes;
using System.Windows.Forms;

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
        private bool mouseDown;
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
            mouseDown = false;
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
                mouseDown = true;
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
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
            if (mouseDown) { 
                if (selectedObject is Rectangle) undoRedo.InsertInUnDoRedoForTranslate(-cumulativeMoveX, -cumulativeMoveY, (Rectangle)selectedObject);
                mouseDown = false;
            }
            cumulativeMoveX = 0;
            cumulativeMoveY = 0;
        }
    }
}
