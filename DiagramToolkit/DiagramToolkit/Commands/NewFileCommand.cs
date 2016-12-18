using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Commands
{
    class NewFileCommand : ICommand
    {
        private DefaultEditor editor;
        private ICanvas canvas;

        public NewFileCommand (IEditor DefaultEditor)
        {
            this.canvas = new DefaultCanvas();
            this.editor = (DefaultEditor)DefaultEditor;
            
        }

        public void Execute()
        {
            //throw new NotImplementedException();
            //DefaultEditor editor2 = (DefaultEditor)editor;
            canvas.Name = "Main" + editor.canvas_count;
            editor.AddCanvas(canvas);
        }

        public void UnExecute()
        {
            //throw new NotImplementedException();
            editor.RemoveCanvas(editor.GetSelectedCanvas());
            
        }
    }
}
