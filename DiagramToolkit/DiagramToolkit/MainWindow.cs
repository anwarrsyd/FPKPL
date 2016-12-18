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
using DiagramToolkit.ToolbarItems;
using DiagramToolkit.Api;
using DiagramToolkit.Api.Svg;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace DiagramToolkit
{
    public partial class MainWindow : Form
    {
        SplitContainer mainPanel = new SplitContainer();
        IEditor editor;
        IToolbar toolbar;
        IToolbox tlp;
        ICanvas canvas1;
        IPlugin[] plugins;
        UndoRedo undoRedo;

        //size form
        int tinggi = 600;
        int lebar = 1350;

        public MainWindow()
        {
            undoRedo = new UndoRedo();
            LoadPlugin();
            InitUI();
        }

        private void LoadPlugin()
        {
            string path = Application.StartupPath;

            string[] pluginFiles = Directory.GetFiles(path, "*.DLL");
            plugins = new IPlugin[pluginFiles.Length];

            for (int i = 0; i < pluginFiles.Length; i++)
            {
                string args = pluginFiles[i].Substring(
                    pluginFiles[i].LastIndexOf("\\") + 1,
                    pluginFiles[i].IndexOf(".dll") -
                    pluginFiles[i].LastIndexOf("\\") - 1);

                Type type = null;

                try
                {
                    Assembly asm = Assembly.Load(args);

                    if (asm != null)
                    {
                        var pluginInterface = typeof(IPlugin);

                        Type[] types = asm.GetTypes();

                        foreach (Type t in types)
                        {
                            if (pluginInterface.IsAssignableFrom(t))
                                type = t;
                        }

                    }

                    if (type != null)
                    {
                        plugins[i] = (IPlugin)Activator.CreateInstance(type);
                        //plugins[i].Host = this;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private void InitUI()
        {
            editor = new DefaultEditor();
            MenuStrip MenuBar = new MenuStrip(); //genereate menu bar
            //MenuBar.BackColor = Color.FromArgb(52, 60, 70);
            //MenuBar.ForeColor = Color.White;
            ToolStripMenuItem file = new ToolStripMenuItem("File"); //generate menu tool
            ToolStripMenuItem edit = new ToolStripMenuItem("Edit");
            ToolStripMenuItem arrange = new ToolStripMenuItem("Arrange");
            ToolStripMenuItem sendToBack = new ToolStripMenuItem("Send to back");
            sendToBack.Click += SendToBack_Click;
            ToolStripMenuItem sendToFront = new ToolStripMenuItem("Send to front");
            sendToFront.Click += SendToFront_Click;
            ToolStripMenuItem newFile = new ToolStripMenuItem("New");
            ToolStripMenuItem newplugin = new ToolStripMenuItem("Add Plugin");
            newFile.Click += NewFile_Click; 
            ToolStripMenuItem exit = new ToolStripMenuItem("Exit");
            exit.Click += Exit_Click;
            ToolStripMenuItem undo = new ToolStripMenuItem("Undo");
            ToolStripMenuItem redo = new ToolStripMenuItem("Redo");
            ToolStripMenuItem resizecanvas = new ToolStripMenuItem("Resize Canvas");
            ToolStripContainer toolContainer = new ToolStripContainer();
            toolContainer.ContentPanel.Controls.Add((Control)editor);
            canvas1 = new DefaultCanvas(undoRedo);
            canvas1.Name = "Main";
            editor.AddCanvas(canvas1);

            // Generate Toolbar
            // Initializing toolbar
            toolbar = new DefaultToolbar();
            ToolStripContainer toolStripContainer = new ToolStripContainer();
            toolStripContainer.Height = 32;
            toolStripContainer.TopToolStripPanel.Controls.Add((Control)this.toolbar);
            UndoToolbarItem undoItem = new UndoToolbarItem(undoRedo, (DefaultCanvas)canvas1);
            RedoToolbarItem redoItem = new RedoToolbarItem(undoRedo, (DefaultCanvas)canvas1);
            toolbar.AddToolbarItem(undoItem);
            toolbar.AddToolbarItem(redoItem);
            toolbar.AddSeparator();

            toolStripContainer.Dock = DockStyle.Top;

            MenuBar.Items.Add(file);
            MenuBar.Items.Add(edit);
            MenuBar.Items.Add(arrange);
            edit.DropDown.Items.Add(undo);
            edit.DropDown.Items.Add(redo);
            edit.DropDown.Items.Add(resizecanvas);
            resizecanvas.Click += Resizecanvas_Click;
            file.DropDown.Items.Add(newFile);
            file.DropDown.Items.Add(newplugin);
            file.DropDown.Items.Add(exit);
            arrange.DropDown.Items.Add(sendToBack);
            arrange.DropDown.Items.Add(sendToFront);
            MenuBar.Dock = DockStyle.Top;
            newplugin.Click += Newplugin_Click;
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

            Tools.SelectionTool pilih = new Tools.SelectionTool(undoRedo);
            pilih.Height = tinggi;
            pilih.Width = lebar;
            pilih.Image = null;
            pilih.BackgroundImage = Resources.Assets.cursor;
            pilih.BackgroundImageLayout = ImageLayout.Zoom;
            tlp.AddTool(pilih);
            if (plugins != null)
            {
                for (int i = 0; i < this.plugins.Length; i++)
                {
                    this.tlp.Register(plugins[i]);
                }
            }
            acc.Add((Control)tlp, "Wireframes", "Enter the client's information.", 0, true);//memasukkan panel pertama

            acc.Add(new TextBox { Dock = DockStyle.Fill, Multiline = true, BackColor = Color.White }, "Memo", "Additional Client Info", 1, true, contentBackColor: Color.Transparent);//menambahkan panel kedua

            acc.Dock = DockStyle.Fill;
          
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
            Controls.Add(toolStripContainer);
            Controls.Add(MenuBar);
            this.tlp.ToolSelected += Toolbox_ToolSelected;

            newSVGToolPhone("phone-line.svg");
            newSVGToolWireframe("chatting.svg");
            newSVGToolWireframe("image-feed.svg");
            newSVGToolWireframe("insta-feed.svg");
            newSVGToolWireframe("list.svg");
            newSVGToolWireframe("login.svg");
            newSVGToolWireframe("modal-popup.svg");
            newSVGToolWireframe("product-detail.svg");
            newSVGToolWireframe("user-feed.svg");
            newSVGToolWireframe("video-detail.svg");
            newSVGToolWireframe("post-with-image.svg");
        }

        private void SendToFront_Click(object sender, EventArgs e)
        {
            canvas1.SendToFront(canvas1.getActiveObject());
        }

        private void SendToBack_Click(object sender, EventArgs e)
        {
            DrawingObject obj;
            obj = canvas1.getActiveObject();
            canvas1.SendToBack(obj);
            canvas1.Repaint();
        }

        private void Newplugin_Click(object sender, EventArgs e)
        {

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Plugin File(*.dll)|*.dll;";
            openDialog.ShowDialog();
            
            var namaFile = Path.GetFileName(openDialog.FileName);
            try {
                string targetPath = Application.StartupPath;
                string destFile = System.IO.Path.Combine(targetPath, namaFile);
                System.IO.File.Copy(openDialog.FileName, destFile, true);
                MessageBox.Show("Add Plugin Success Application Will Restart!");
                this.Controls.Clear();
                ProcessStartInfo Info = new ProcessStartInfo();
                Info.Arguments = "/C ping 127.0.0.1 -n 2 && \"" + Application.ExecutablePath + "\"";
                Info.WindowStyle = ProcessWindowStyle.Hidden;
                Info.CreateNoWindow = true;
                Info.FileName = "cmd.exe";
                Process.Start(Info);
                Application.Exit();
            }
            catch
            {
                MessageBox.Show("ERROR");
            }



        }

        private void UndoItem_Click(object sender, EventArgs e)
        {
            undoRedo.Undo(1);
        }

        private void NewFile_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            //this.InitUI();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
                        this.Close();
        }

        private void Resizecanvas_Click(object sender, EventArgs e)
        {
            dialogresizecanvas rubahukuran = new dialogresizecanvas();
            rubahukuran.ShowDialog();
            int lebarr= rubahukuran.lebar;
            int tinggii = rubahukuran.tinggi;
            //MessageBox.Show(lebarr.ToString() + " " + tinggii.ToString());
            mainPanel.Panel2.AutoScrollMinSize = new Size(tinggii,lebarr);
        }

        private void newSVGToolPhone(String selectedSvg) {
            string selectedSVG = selectedSvg;
            Tools.RectangleTool svgTool = new Tools.RectangleTool(190, 400, selectedSVG,undoRedo);
            svgTool.BackgroundImage = SVGParser.GetBitmapFromSVG(selectedSVG);
            svgTool.Height = 100;
            svgTool.Width = 100;
            svgTool.BackgroundImageLayout = ImageLayout.Zoom;
            tlp.AddTool(svgTool);
        }

        private void newSVGToolWireframe(String selectedSvg)
        {
            string selectedSVG = selectedSvg;
            Tools.RectangleTool svgTool = new Tools.RectangleTool(164, 290, selectedSVG, undoRedo);
            svgTool.BackgroundImage = SVGParser.GetBitmapFromSVG(selectedSVG);
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
    }
}