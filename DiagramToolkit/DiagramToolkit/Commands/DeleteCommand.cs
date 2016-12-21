using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagramToolkit.Api;
using DiagramToolkit.Api.Shapes;
using System.Diagnostics;

namespace DiagramToolkit.Commands
{
    class DeleteCommand : ICommand
    {
        private Rectangle rectangle;
        private DrawingObject drawObj;
        private List<DrawingObject> listChild;
        private ICanvas canvas;
        UndoRedo undoredo;
        public DeleteCommand(Rectangle rectangle, ICanvas canvas)
        {
            this.rectangle = rectangle;
            this.canvas = canvas;
            this.listChild = new List<DrawingObject>(rectangle.listChildObject);
            undoredo = new UndoRedo();
        }
        public DeleteCommand(DrawingObject obj, ICanvas canvas)
        {
            this.drawObj = obj;
            this.canvas = canvas;
            undoredo = new UndoRedo();
        }

        public void Execute()
        {
            if (rectangle != null)
            {
                canvas.AddDrawingObject(rectangle);
                if (this.listChild.Count > 0)
                {
                    undoredo.Undo(1);
                    foreach (DrawingObject obj in this.listChild)
                    {
                        obj.parentRectangle = this.rectangle;
                        rectangle.listChildObject.Add(obj);
                    }
                    
                }
            }
            else
            {
                canvas.AddDrawingObject(drawObj);
            }
        }

        public void UnExecute()
        {
            if (this.rectangle != null)
            {
                if (this.rectangle.listChildObject.Count > 0)
                {
                    foreach (DrawingObject obj in this.rectangle.listChildObject)
                    {
                        DeleteCommand cmd = new DeleteCommand((Rectangle)obj, this.canvas);
                        cmd.UnExecute();
                        undoredo.InsertCommand(cmd);
                    }
                    this.rectangle.listChildObject.Clear();
                }
                this.canvas.RemoveDrawingObject(this.rectangle);
            }
            else
            {
                this.canvas.RemoveDrawingObject(drawObj);
            }
        }
    }
}
