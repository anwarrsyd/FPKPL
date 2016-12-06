using DiagramToolkit.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Commands
{
    class TranslateCommand : ICommand
    {
        private int xAmmount, yAmmount;
        private Rectangle rectangle;

        public TranslateCommand(int xAmmount, int yAmmount, Rectangle rectangle)
        {
            this.xAmmount = xAmmount;
            this.yAmmount = yAmmount;
            this.rectangle = rectangle;
        }
        public void Execute()
        {
            rectangle.Translate(xAmmount, yAmmount);
            if (rectangle.listChildObject.Count > 0)
            {
                foreach(DrawingObject obj in rectangle.listChildObject)
                {
                    obj.Translate(xAmmount, yAmmount);
                }
            }
        }

        public void UnExecute()
        {
            rectangle.Translate(-xAmmount, -yAmmount);
            if (rectangle.listChildObject.Count > 0)
            {
                foreach (DrawingObject obj in rectangle.listChildObject)
                {
                    obj.Translate(-xAmmount, -yAmmount);
                }
            }
        }
    }
}
