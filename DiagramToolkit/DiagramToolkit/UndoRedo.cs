using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiagramToolkit
{
    public class UndoRedo
    {
        private Stack<ICommand> _Undocommands = new Stack<ICommand>();
        private Stack<ICommand> _Redocommands = new Stack<ICommand>();

        private DefaultCanvas _Container;

        public DefaultCanvas Container
        {
            get { return _Container; }
            set { _Container = value; }
        }
        public void Redo(int levels)
        {
            for(int i = 1; i <= levels; i++)
            {
                if(_Redocommands.Count != 0)
                {
                    ICommand command = _Redocommands.Pop();
                    command.Execute();
                    _Undocommands.Push(command);
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
                if(_Undocommands.Count != 0)
                {
                    ICommand command = _Undocommands.Pop();
                    command.Execute();
                    _Redocommands.Push(command);
                }
            }
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }
        
        public void InsertInUnDoRedoForInsert(FrameworkElement ApbOrDevice)
        {
            ICommand cmd = new InsertCommand(ApbOrDevice, Container);
            _Undocommands.Push(cmd); _Redocommands.Clear();
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public void InsertInUnDoRedoForDelete(FrameworkElement ApbOrDevice)
        {
            ICommand cmd = new DeleteCommand(ApbOrDevice, Container);
            _Undocommands.Push(cmd); _Redocommands.Clear();
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public void InsertInUnDoRedoForMove(Point margin, FrameworkElement UIelement)
        {
            ICommand cmd = new MoveCommand(new Thickness(margin.X, margin.Y, 0, 0), UIelement);
            _Undocommands.Push(cmd); _Redocommands.Clear();
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public void InsertInUnDoRedoForResize(Point margin, double width, double height, FrameworkElement UIelement)
        {
            ICommand cmd = new ResizeCommand(new Thickness(margin.X, margin.Y, 0, 0), width, height, UIelement);
            _Undocommands.Push(cmd); _Redocommands.Clear();
            if (EnableDisableUndoRedoFeature != null)
            {
                EnableDisableUndoRedoFeature(null, null);
            }
        }

        public bool IsUndoPossible()
        {
            if (_Undocommands.Count != 0)
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

            if (_Redocommands.Count != 0)
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
