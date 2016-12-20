using DiagramToolkit.Api;
using System.Collections.Generic;
using DiagramToolkit.Api.Shapes;

namespace DiagramToolkit.Commands
{
    class UnGroupCommand:ICommand
    {
        Rectangle ParentObject;
        List<DrawingObject> allChild;
        public UnGroupCommand(Rectangle Obj)
        {
            this.ParentObject = Obj;
            this.allChild = new List<DrawingObject>(Obj.listChildObject);
        }
        public void Execute()//regroup
        {
            foreach(DrawingObject obj in this.allChild)
            {
                obj.parentRectangle = this.ParentObject;
                this.ParentObject.addComponent(obj);
            }
        }
        public void UnExecute()//ungroup
        {
            foreach(DrawingObject obj in this.allChild)
            {
                obj.parentRectangle = null;
                ParentObject.listChildObject.Remove(obj);
            }
        }
    }
}
