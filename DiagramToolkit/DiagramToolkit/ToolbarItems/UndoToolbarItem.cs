using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit.ToolbarItems
{
    public class UndoToolbarItem : ToolStripButton, IToolbarItem
    {
        private ICommand command;

        public UndoToolbarItem()
        {
            this.Name = "Undo";
            this.ToolTipText = "Undo Button";
            this.Image = IconSet.Undo;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;

            this.Click += UndoToolbarItem_Click;
        }

        private void UndoToolbarItem_Click(object sender, EventArgs e)
        {
            if (command != null)
            {
                this.command.Execute();
            }
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }
    }
}
