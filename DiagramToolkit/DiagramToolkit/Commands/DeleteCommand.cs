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
        private ICanvas canvas;

        public DeleteCommand(Rectangle rectangle, ICanvas canvas)
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
