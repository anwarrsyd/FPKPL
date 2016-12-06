using DiagramToolkit.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiagramToolkit.Commands
{
    public class InsertCommand : ICommand

    {
        private Rectangle rectangle;
        private ICanvas canvas;

        public InsertCommand(Rectangle rectangle, ICanvas canvas)
        {
            this.rectangle = rectangle;
            this.canvas = canvas;
        }

        public void Execute()
        {

            canvas.AddDrawingObject(rectangle);

        }

        public void UnExecute()
        {

            canvas.RemoveDrawingObject(rectangle);
        }
    }
}