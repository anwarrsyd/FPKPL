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
            foreach (DrawingObject obj in allChild)
            {
                if (allChild.Count > 0)
                {
                    UnGroupCommand cmd = new UnGroupCommand((Rectangle)obj);
                    cmd.Execute();
                }
                obj.parentRectangle = this.ParentObject;
                ParentObject.addComponent(obj);
            }
        }
        public void UnExecute()//ungroup
        {
            foreach(DrawingObject obj in this.allChild)
            {
                if (allChild.Count > 0)
                {
                    UnGroupCommand cmd = new UnGroupCommand((Rectangle)obj);
                    cmd.UnExecute();
                }
                obj.parentRectangle = null;
                ParentObject.removeComponent(obj);
            }
        }
    }
}
