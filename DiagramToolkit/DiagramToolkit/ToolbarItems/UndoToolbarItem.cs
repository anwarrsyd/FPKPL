using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit.ToolbarItems
{
    public class UndoToolbarItem : ToolStripButton, IToolbarItem
    {
        private ICommand command;
        private UndoRedo undoRedo;
        private DefaultCanvas defaultCanvas;
        public UndoToolbarItem()
        {
            this.Name = "Undo";
            this.ToolTipText = "Undo Button";
            this.Image = IconSet.Undo;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;

            this.Click += UndoToolbarItem_Click;
        }

        public UndoToolbarItem(UndoRedo undoRedo, DefaultCanvas defaultCanvas)
        {
            this.Name = "Undo";
            this.ToolTipText = "Undo Button";
            this.Image = IconSet.Undo;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.undoRedo = undoRedo;
            this.defaultCanvas = defaultCanvas;
            this.Click += UndoToolbarItem_Click;
        }
        private void UndoToolbarItem_Click(object sender, EventArgs e)
        {
            undoRedo.Undo(1);
            defaultCanvas.Repaint();
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }
    }
}
