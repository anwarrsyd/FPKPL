using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opulos.Core.UI;

namespace DiagramToolkit
{
    public partial class MainWindow : Form
    {
        IEditor editor;
        IToolbox tlp;
        ICanvas canvas1;

        //size form
        int tinggi = 600;
        int lebar = 1350;

        public MainWindow()
        {
            InitUI();
        }

        private void InitUI()
        {
            editor = new DefaultEditor();
            MenuStrip MenuBar = new MenuStrip(); //genereate menu bar
            ToolStripMenuItem file = new ToolStripMenuItem("File"); //generate menu tool
            ToolStripMenuItem edit = new ToolStripMenuItem("Edit");
            ToolStripMenuItem newFile = new ToolStripMenuItem("New");
            ToolStripMenuItem undo = new ToolStripMenuItem("Undo");
            ToolStripMenuItem redo = new ToolStripMenuItem("Redo");
            ToolStripContainer toolContainer = new ToolStripContainer();
            toolContainer.ContentPanel.Controls.Add((Control)editor);
            canvas1 = new DefaultCanvas();
            canvas1.Name = "Main";
            editor.AddCanvas(canvas1);

            MenuBar.Items.Add(file);
            MenuBar.Items.Add(edit);
            edit.DropDown.Items.Add(undo);
            edit.DropDown.Items.Add(redo);
            file.DropDown.Items.Add(newFile);
            MenuBar.Dock = DockStyle.Top;

            //set size form
            this.Height = this.tinggi;
            this.Width = this.lebar;

            //deklarasi accordion form
            Accordion acc = new Accordion();
            acc.CheckBoxMargin = new Padding(2);
            acc.ContentMargin = new Padding(5, 5, 5, 5);
            acc.ContentPadding = new Padding(1);
            acc.Insets = new Padding(5);
            acc.ControlBackColor = Color.White;
            acc.Width = 200;

            //deklarasi panel pertama
            //deklarasi size button
            int tinggi = 100;
            int lebar = 100;
            tlp = new DefaultToolbox();
            tlp.TabStop = true;
            tlp.MaximumSize = new Size(new Point(300));

            //deklrasi button baru
            //tools.rectangletool phone = new tools.rectangletool();
            //phone.backgroundimage = new bitmap(resources.assets.phone);
            //phone.height = tinggi;
            //phone.width = lebar;
            //phone.backgroundimagelayout = imagelayout.zoom;
            newSVGTool("phone-line.svg");
            newSVGTool("chatting.svg");
            newSVGTool("image-feed.svg");
            newSVGTool("insta-feed.svg");
            newSVGTool("list.svg");
            newSVGTool("login.svg");
            newSVGTool("modal-popup.svg");
            newSVGTool("product-detail.svg");
            newSVGTool("user-feed.svg");
            newSVGTool("video-detail.svg");
            newSVGTool("post-with-image.svg");

            Tools.LineTool lain = new Tools.LineTool();
            lain.BackgroundImage = Resources.Assets.vector_diagonal_line_with_box_edges;
            lain.Height = tinggi;
            lain.Width = lebar;
            lain.BackgroundImageLayout = ImageLayout.Zoom;
            tlp.AddTool(lain);

            Tools.SelectionTool pilih = new Tools.SelectionTool();
            pilih.Height = tinggi;
            pilih.Width = lebar;
            pilih.Image = null;
            pilih.BackgroundImage = Resources.Assets.cursor;
            pilih.BackgroundImageLayout = ImageLayout.Zoom;
            tlp.AddTool(pilih);

            acc.Add((Control)tlp, "Android", "Enter the client's information.", 0, true);//memasukkan panel pertama

            acc.Add(new TextBox { Dock = DockStyle.Fill, Multiline = true, BackColor = Color.White }, "Memo", "Additional Client Info", 1, true, contentBackColor: Color.Transparent);//menambahkan panel kedua

            acc.Dock = DockStyle.Fill;
            SplitContainer mainPanel = new SplitContainer();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Panel1.Controls.Add(acc);
            mainPanel.FixedPanel = FixedPanel.Panel1;
            mainPanel.MinimumSize = new Size(300, 200);
            mainPanel.Panel2.BackColor = Color.White;
            toolContainer.Dock = DockStyle.Fill;
            mainPanel.Panel2.Controls.Add(toolContainer);
            mainPanel.SplitterWidth = 15;
            mainPanel.SplitterDistance = 300;
            
            Controls.Add(mainPanel);
            Controls.Add(MenuBar);
            this.tlp.ToolSelected += Toolbox_ToolSelected;
        }

        private void newSVGTool(String selectedSvg) {
            string selectedSVG = selectedSvg;
            Tools.RectangleTool svgTool = new Tools.RectangleTool(selectedSVG);
            svgTool.BackgroundImage = Svg.SVGParser.GetBitmapFromSVG(selectedSVG);
            svgTool.Height = 100;
            svgTool.Width = 100;
            svgTool.BackgroundImageLayout = ImageLayout.Zoom;
            tlp.AddTool(svgTool);
        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.editor != null)
            {
                System.Diagnostics.Debug.WriteLine("Listener is working");
                ICanvas canvas = this.editor.GetSelectedCanvas();
                canvas.SetActiveTool(tool);
                tool.TargetCanvas = canvas;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MainWindow";
            this.ResumeLayout(false);
        }
    }
}