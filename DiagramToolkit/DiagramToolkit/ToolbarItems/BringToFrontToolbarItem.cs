using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit.ToolbarItems
{
    public class BringToFrontToolbarItem : ToolStripButton, IToolbarItem
    {
        private ICommand command;
        private UndoRedo undoRedo;
        private DefaultCanvas defaultCanvas;

        public BringToFrontToolbarItem(UndoRedo undoRedo, DefaultCanvas defaultCanvas)
        {
            this.Name = "Bring to Front";
            this.ToolTipText = "Bring to Front Button";
            this.Image = IconSet.BringToFront;
            this.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.undoRedo = undoRedo;
            this.defaultCanvas = defaultCanvas;

            this.Click += BringToFrontToolbarItem_Click;            
        }

        private void BringToFrontToolbarItem_Click(object sender, EventArgs e)
        {
            //undoRedo.Redo(1);
            //defaultCanvas.Repaint();
        }
    }
}
