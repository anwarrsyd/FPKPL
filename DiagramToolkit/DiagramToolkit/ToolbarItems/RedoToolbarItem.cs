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

        public RedoToolbarItem()
        {
            this.Name = "Redo";
            this.ToolTipText = "Redo Button";
            this.Image = IconSet.Redo;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;

            this.Click += RedoToolbarItem_Click;
        }

        private void RedoToolbarItem_Click(object sender, EventArgs e)
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
