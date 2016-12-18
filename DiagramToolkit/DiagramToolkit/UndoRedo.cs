using DiagramToolkit.Commands;
using DiagramToolkit.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiagramToolkit
{
    public class UndoRedo
    {
        private Stack<ICommand> undoCommands = new Stack<ICommand>();
        private Stack<ICommand> redoCommands = new Stack<ICommand>();

        private DefaultCanvas _Container;
        public event EventHandler EnableDisableUndoRedoFeature;

        public DefaultCanvas Container
        {
            get { return _Container; }
            set { _Container = value; }
        }
        public void Redo(int levels)
        {
            for(int i = 1; i <= levels; i++)
            {
                if(redoCommands.Count != 0)
                {
                    ICommand command = redoCommands.Pop();
                    command.UnExecute();
                    undoCommands.Push(command);
                }
            }
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }
        public void Undo(int levels)
        {
            for(int i = 1; i <= levels; i++)
            {
                if(undoCommands.Count != 0)
                {
                    ICommand command = undoCommands.Pop();
                    command.Execute();
                    redoCommands.Push(command);
                }
            }
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public void InsertInUnDoRedoForTranslate(int xAmmount, int yAmmount, Rectangle rectangle)
        {
            ICommand iCommand = new TranslateCommand(xAmmount, yAmmount, rectangle);
            undoCommands.Push(iCommand);
            redoCommands.Clear();
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public void InsertInUnDoRedoForInsert(Rectangle rectangle, ICanvas canvas)
        {
            ICommand cmd = new InsertCommand(rectangle, canvas);
            undoCommands.Push(cmd); redoCommands.Clear();
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }
        

        public void InsertInUnDoRedoForDelete(Rectangle rectangle, ICanvas canvas)
        {
            ICommand cmd = new DeleteCommand(rectangle, canvas);
            undoCommands.Push(cmd); redoCommands.Clear();
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

            /*

        public void InsertInUnDoRedoForMove(Point margin, FrameworkElement UIelement)
        {
            ICommand cmd = new MoveCommand(new Thickness(margin.X, margin.Y, 0, 0), UIelement);
            undoCommands.Push(cmd); redoCommands.Clear();
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public void InsertInUnDoRedoForResize(Point margin, double width, double height, FrameworkElement UIelement)
        {
            ICommand cmd = new ResizeCommand(new Thickness(margin.X, margin.Y, 0, 0), width, height, UIelement);
            undoCommands.Push(cmd); redoCommands.Clear();
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }
        #endregion
        */
        public bool IsUndoPossible()
        {
            if (undoCommands.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsRedoPossible()
        {

            if (redoCommands.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
