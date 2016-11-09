//using DiagramToolkit.Commands;
//using DiagramToolkit.MenuItems;
//using DiagramToolkit.ToolbarItems;
//using DiagramToolkit.Tools;
//using System.Diagnostics;
//using System.Windows.Forms;

//namespace DiagramToolkit
//{
//    public partial class MainWindow : Form
//    {
//        private IToolbox toolbox;
//        private IEditor editor;
//        private IToolbar toolbar;
//        private IMenubar menubar;

//        public MainWindow()
//        {
//            InitializeComponent();
//            InitUI();
//        }

//        private void InitUI()
//        {
//            Debug.WriteLine("Initializing UI objects.");

//            #region Editor and Canvas

//            Debug.WriteLine("Loading canvas...");
//            this.editor = new DefaultEditor();
//            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.editor);

//            ICanvas canvas1 = new DefaultCanvas();
//            canvas1.Name = "Untitled-1";
//            this.editor.AddCanvas(canvas1);

//            ICanvas canvas2 = new DefaultCanvas();
//            canvas2.Name = "Untitled-2";
//            this.editor.AddCanvas(canvas2);

//            #endregion

//            #region Commands

//            //BlackCanvasBgCommand blackCanvasBgCmd = new BlackCanvasBgCommand(this.canvas);
//            //WhiteCanvasBgCommand whiteCanvasBgCmd = new WhiteCanvasBgCommand(this.canvas);

//            #endregion

//            #region Menubar

//            Debug.WriteLine("Loading menubar...");
//            this.menubar = new DefaultMenubar();
//            this.Controls.Add((Control)this.menubar);

//            DefaultMenuItem fileMenuItem = new DefaultMenuItem("File");
//            this.menubar.AddMenuItem(fileMenuItem);

//            DefaultMenuItem newMenuItem = new DefaultMenuItem("New");
//            fileMenuItem.AddMenuItem(newMenuItem);
//            fileMenuItem.AddSeparator();
//            DefaultMenuItem exitMenuItem = new DefaultMenuItem("Exit");
//            fileMenuItem.AddMenuItem(exitMenuItem);

//            DefaultMenuItem editMenuItem = new DefaultMenuItem("Edit");
//            this.menubar.AddMenuItem(editMenuItem);

//            DefaultMenuItem undoMenuItem = new DefaultMenuItem("Undo");
//            editMenuItem.AddMenuItem(undoMenuItem);
//            DefaultMenuItem redoMenuItem = new DefaultMenuItem("Redo");
//            editMenuItem.AddMenuItem(redoMenuItem);

//            DefaultMenuItem viewMenuItem = new DefaultMenuItem("View");
//            this.menubar.AddMenuItem(viewMenuItem);

//            DefaultMenuItem helpMenuItem = new DefaultMenuItem("Help");
//            this.menubar.AddMenuItem(helpMenuItem);

//            DefaultMenuItem aboutMenuItem = new DefaultMenuItem("About");
//            helpMenuItem.AddMenuItem(aboutMenuItem);

//            #endregion

//            #region Toolbox

//            // Initializing toolbox
//            Debug.WriteLine("Loading toolbox...");
//            this.toolbox = new DefaultToolbox();
//            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);
//            this.editor.Toolbox = toolbox;

//            #endregion

//            #region Tools

//            // Initializing tools
//            Debug.WriteLine("Loading tools...");
//            this.toolbox.AddTool(new SelectionTool());
//            this.toolbox.AddSeparator();
//            this.toolbox.AddTool(new LineTool());
//            this.toolbox.AddTool(new RectangleTool());
//            this.toolbox.ToolSelected += Toolbox_ToolSelected;

//            #endregion

//            #region Toolbar

//            // Initializing toolbar
//            Debug.WriteLine("Loading toolbar...");
//            this.toolbar = new DefaultToolbar();
//            this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control)this.toolbar);

//            ExampleToolbarItem toolItem1 = new ExampleToolbarItem();
//            //toolItem1.SetCommand(whiteCanvasBgCmd);
//            ExampleToolbarItem toolItem2 = new ExampleToolbarItem();
//            //toolItem2.SetCommand(blackCanvasBgCmd);

//            this.toolbar.AddToolbarItem(toolItem1);
//            this.toolbar.AddSeparator();
//            this.toolbar.AddToolbarItem(toolItem2);

//            #endregion

//        }

//        private void Toolbox_ToolSelected(ITool tool)
//        {
//            if (this.editor != null)
//            {
//                Debug.WriteLine("Tool " + tool.Name + " is selected");
//                ICanvas canvas = this.editor.GetSelectedCanvas();
//                canvas.SetActiveTool(tool);
//                tool.TargetCanvas = canvas;
//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            //InitializeComponent();
            InitUi();
        }
        TreeView tools;
        int width = 900;
        int height = 500;
        private ToolStripMenuItem File_Menu;
        private ToolStripMenuItem Edit_Menu;
        private ToolStripMenuItem Exit_Menu;
        private MenuStrip Menu_Bar;
        private SplitContainer Split_Container;
        private TableLayoutPanel General_ToolBox;
        private void InitUi()
        {
            //deklarasi
            tools = new TreeView();
            File_Menu = new ToolStripMenuItem("File");
            Edit_Menu = new ToolStripMenuItem("Edit");
            Exit_Menu = new ToolStripMenuItem("Exit");
            Menu_Bar = new MenuStrip();
            Split_Container = new SplitContainer();
            General_ToolBox = new TableLayoutPanel();


            Menu_Bar.Items.AddRange(new ToolStripItem[] { File_Menu, Edit_Menu });
            File_Menu.DropDownItems.Add(Exit_Menu);

            Split_Container.Dock = DockStyle.Fill;
            Split_Container.Location = new Point(0, 24);
            Split_Container.Size = new Size(this.width - 24, this.height);
            Split_Container.SplitterDistance = 120;
            Split_Container.SplitterWidth = 10;
            Split_Container.Panel2.BackColor = Color.White;
            Split_Container.Panel1.Controls.Add(tools);
            Menu_Bar.Location = new Point(0, 0);
            Menu_Bar.Size = new Size(200, 24);

            tools.Location = new Point(0, 24);
            tools.Height = this.height - 24;
            tools.Width = this.Split_Container.SplitterDistance;
            TreeNode umum = new TreeNode("General");
            umum.Nodes.Add("a");
            umum.Nodes.Add("b");
            umum.Nodes.Add("c");
            umum.Nodes.Add("d");
            tools.Nodes.Add(umum);
            umum = new TreeNode("Mobile");
            umum.Nodes.Add("a");
            umum.Nodes.Add("b");
            umum.Nodes.Add("c");
            umum.Nodes.Add("d");
            tools.Nodes.Add(umum);
            umum = new TreeNode("Connector");
            umum.Nodes.Add("a");
            umum.Nodes.Add("b");
            umum.Nodes.Add("c");
            umum.Nodes.Add("d");
            tools.Nodes.Add(umum);
            umum = new TreeNode("Other");
            tools.Nodes.Add(umum);

            this.Size = new Size(this.width, this.height);
            this.Controls.Add(Menu_Bar);
            this.Controls.Add(Split_Container);
        }
    }
}


