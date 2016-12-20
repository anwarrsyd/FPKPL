using DiagramToolkit.Api;
using DiagramToolkit.Api.Shapes;

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
            this.childObject.parentRectangle = null;
        }
        public void UnExecute()
        {
            this.parentObject.listChildObject.Add(this.childObject);
            this.childObject.parentRectangle = parentObject;
        }
    }
}
