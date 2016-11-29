using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit.ToolbarItems
{
    class SendToBackToolbarItem : ToolStripButton, IToolbarItem
    {
        private ICommand command;
        private UndoRedo undoRedo;
        private DefaultCanvas defaultCanvas;

        public SendToBackToolbarItem(UndoRedo undoRedo, DefaultCanvas defaultCanvas)
        {
            this.Name = "Send to Back";
            this.ToolTipText = "Send to Back Button";
            this.Image = IconSet.SendToBack;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.undoRedo = undoRedo;
            this.defaultCanvas = defaultCanvas;

            this.Click += SendToBackToolbarItem_Click;
        }

        private void SendToBackToolbarItem_Click(object sender, EventArgs e)
        {
            //undoRedo.Redo(1);
            //defaultCanvas.Repaint();
        }
    }
}
