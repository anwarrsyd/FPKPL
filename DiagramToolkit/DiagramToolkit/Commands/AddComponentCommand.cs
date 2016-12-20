using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using DiagramToolkit.Api;
using DiagramToolkit.Api.Shapes;

namespace DiagramToolkit.Commands
{
    class AddComponentCommand: ICommand
    {
        private Rectangle targetRectangle;
        private DrawingObject componentRectangle;

        public AddComponentCommand(Rectangle content, Rectangle frame)
        {
            this.targetRectangle = frame;
            this.componentRectangle = content;
        }

        public void Execute()
        {
            this.targetRectangle.addComponent(this.componentRectangle);
        }
        public void UnExecute()
        {
            this.targetRectangle.removeComponent(this.componentRectangle);
        }
    }
}
