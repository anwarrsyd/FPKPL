
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagramToolkit.Api.Shapes;
using DiagramToolkit.Api;

namespace DiagramToolkit.Commands
{
    class TranslateCommand : ICommand
    {
        private int xAmmount, yAmmount;
        private DrawingObject rectangle;

        public TranslateCommand(int xAmmount, int yAmmount, DrawingObject rectangle)
        {
            this.xAmmount = xAmmount;
            this.yAmmount = yAmmount;
            this.rectangle = rectangle;
        }



        public void Execute()
        {
            rectangle.Translate(xAmmount, yAmmount);
        }

        public void UnExecute()
        {
            rectangle.Translate(-xAmmount, -yAmmount);
        }
    }
}
