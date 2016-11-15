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
            FlowLayoutPanel tlp = new FlowLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(5) };
            tlp.TabStop = true;
            tlp.MaximumSize = new Size(new Point(300));
            //deklrasi button baru
            Tools.RectangleTool phone = new Tools.RectangleTool();
            phone.BackgroundImage = new Bitmap(Resources.Assets.phone);
            phone.Height = tinggi;
            phone.Width = lebar;
            phone.BackgroundImageLayout = ImageLayout.Zoom;
            //Button Phone    = new Button { Height = tinggi, Width = lebar, Text = "", BackgroundImage = new Bitmap(Resources.Assets.phone), BackgroundImageLayout = ImageLayout.Zoom, FlatStyle = FlatStyle.Flat };
            Button Keyboard = new Button { Height = tinggi, Width = lebar, Text = "", BackgroundImage = new Bitmap(Resources.Assets.keyboard), BackgroundImageLayout = ImageLayout.Zoom, FlatStyle = FlatStyle.Flat };
            Button Tablet = new Button { Height = tinggi, Width = lebar, Text = "", BackgroundImage = new Bitmap(Resources.Assets.tablet), BackgroundImageLayout = ImageLayout.Zoom, FlatStyle = FlatStyle.Flat };
            Button StatusBar = new Button { Height = tinggi, Width = lebar, Text = "", BackgroundImage = new Bitmap(Resources.Assets.statusbar), BackgroundImageLayout = ImageLayout.Zoom, FlatStyle = FlatStyle.Flat };
            Button NavBar = new Button { Height = tinggi, Width = lebar, Text = "", BackgroundImage = new Bitmap(Resources.Assets.navigationBar), BackgroundImageLayout = ImageLayout.Zoom, FlatStyle = FlatStyle.Flat };
            Button checkbox = new Button { Height = tinggi, Width = lebar, Text = "", BackgroundImage = new Bitmap(Resources.Assets.checkbox), BackgroundImageLayout = ImageLayout.Zoom, FlatStyle = FlatStyle.Flat };

            //penambahan button ke canvas
            tlp.Controls.Add(phone);
            tlp.Controls.Add(Keyboard);
            tlp.Controls.Add(Tablet);
            tlp.Controls.Add(checkbox);
            tlp.Controls.Add(StatusBar);
            tlp.Controls.Add(NavBar);

            tlp.Dock = DockStyle.Fill;

            acc.Add(tlp, "Android", "Enter the client's information.", 0, true);//memasukkan panel pertama

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