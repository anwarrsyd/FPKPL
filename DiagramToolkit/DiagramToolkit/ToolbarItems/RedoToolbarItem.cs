using DiagramToolkit.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit.ToolbarItems
{
    public class RedoToolbarItem : ToolStripButton, IToolbarItem 
    {
        private ICommand command;
        private UndoRedo undoRedo;
        private DefaultCanvas defaultCanvas;

        public RedoToolbarItem(UndoRedo undoRedo, DefaultCanvas defaultCanvas)
        {
            this.Name = "Redo";
            this.ToolTipText = "Redo Button";
            this.Image = IconSet.Redo;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.undoRedo = undoRedo;
            this.defaultCanvas = defaultCanvas;
            this.Click += RedoToolbarItem_Click;
        }

        private void RedoToolbarItem_Click(object sender, EventArgs e)
        {
            undoRedo.Redo(1);
            defaultCanvas.Repaint();
        }
    }
}
