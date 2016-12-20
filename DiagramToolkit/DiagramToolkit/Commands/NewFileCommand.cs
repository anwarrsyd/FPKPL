using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagramToolkit.Api;

namespace DiagramToolkit.Commands
{
    class NewFileCommand : ICommand
    {
        private DefaultEditor editor;
        private ICanvas canvas;

        public NewFileCommand(IEditor DefaultEditor)
        {
            this.canvas = new DefaultCanvas();
            this.editor = (DefaultEditor)DefaultEditor;
        }

        public void Execute()
        {
            canvas.Name = "Main" + editor.canvas_count;
            editor.AddCanvas(canvas);
        }

        public void UnExecute()
        {
            editor.RemoveCanvas(editor.GetSelectedCanvas());
        }
    }
}
