using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagramToolkit.Api;
using DiagramToolkit.Api.Shapes;

namespace DiagramToolkit.Commands
{
    class DeleteCommand : ICommand
    {
        private Rectangle rectangle;
        private List<DrawingObject> listChild;
        private ICanvas canvas;

        public DeleteCommand(Rectangle rectangle, ICanvas canvas)
        {
            this.rectangle = rectangle;
            this.canvas = canvas;
            this.listChild = new List<DrawingObject>(rectangle.listChildObject);
        }

        public void Execute()
        {
            canvas.AddDrawingObject(rectangle);
            if (this.listChild.Count > 0)
            {
                foreach(DrawingObject obj in this.listChild)
                {
                    DeleteCommand cmd = new DeleteCommand((Rectangle)obj, this.canvas);
                    cmd.Execute();
                    obj.parentRectangle = this.rectangle;
                    rectangle.listChildObject.Add(obj);
                }
            }
        }

        public void UnExecute()
        {
            if (this.rectangle.listChildObject.Count > 0)
            {
                foreach(DrawingObject obj in this.rectangle.listChildObject)
                {
                    DeleteCommand cmd = new DeleteCommand((Rectangle)obj, this.canvas);
                    cmd.UnExecute();
                }
                this.rectangle.listChildObject.Clear();
            }
            this.canvas.RemoveDrawingObject(this.rectangle);
        }
    }
}
