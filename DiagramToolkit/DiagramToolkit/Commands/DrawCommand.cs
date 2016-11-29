using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace DiagramToolkit.DrawCommand
{
    public class DrawCommand : ICommand
    {
        private Thickness _ChangeOfMargin;
        private FrameworkElement _UiElement;
        private DefaultCanvas _Container;

        public void Execute()
        {
            if (!_Container.Children.Contains(_UiElement))
            {
                _Container.Children.Add(_UiElement);
            }
        }

        public void UnExecute()
        {
            _Container.Children.Remove(_UiElement);
        }
    }
}
