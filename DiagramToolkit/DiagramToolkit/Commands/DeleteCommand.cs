using DiagramToolkit.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiagramToolkit.Commands
{
    public class DeleteCommand : ICommand
    {
        private Rectangle rectangle;
        private ICanvas canvas;

        public DeleteCommand(Rectangle rectangle , ICanvas canvas)
        {
            this.rectangle = rectangle;
            this.canvas = canvas;
        }
        public void Execute()
        {
            //throw new NotImplementedException();
            canvas.AddDrawingObject(rectangle);
        }

        public void UnExecute()
        {
            //throw new NotImplementedException();
            canvas.RemoveDrawingObject(rectangle);
        }
    }
}