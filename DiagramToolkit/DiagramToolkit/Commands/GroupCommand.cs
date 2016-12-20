using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagramToolkit.Api;
using DiagramToolkit.Api.Shapes;
using DiagramToolkit;

namespace DiagramToolkit.Commands
{
    class GroupCommand : ICommand
    {
        DrawingObject childObject;
        Rectangle parentObject;
        public GroupCommand(Rectangle parent, DrawingObject child)
        {
            this.parentObject = parent;
            this.childObject = child;
        }
        public void Execute()
        {
            this.parentObject.listChildObject.Remove(this.childObject);
        }
        public void UnExecute()
        {
            this.parentObject.listChildObject.Add(this.childObject);
        }
    }
}
