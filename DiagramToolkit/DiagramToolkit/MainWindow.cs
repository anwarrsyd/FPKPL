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
        //size form
        int tinggi = 600;
        int lebar = 1350;
        public MainWindow()
        {
            InitUI();
        }
        private void InitUI()
        {
            MenuStrip MenuBar = new MenuStrip(); //genereate menu bar
            ToolStripMenuItem file = new ToolStripMenuItem("File"); //generate menu tool
            ToolStripMenuItem edit = new ToolStripMenuItem("Edit");
            ToolStripMenuItem newFile = new ToolStripMenuItem("New");
            ToolStripMenuItem undo = new ToolStripMenuItem("Undo");
            ToolStripMenuItem redo = new ToolStripMenuItem("Redo");
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
            FlowLayoutPanel tlp = new FlowLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(5) };
            tlp.TabStop = true;
            Button iniTombol = new Button { Text = "", Image = Image.FromFile("D:/Documents/Kuliah/Kuliah smt 7/Konstruksi Perangkat Lunak/fpfp/FPKPL/DiagramToolkit/DiagramToolkit/Resources/Mobile/checkbox.png"), FlatStyle = FlatStyle.Flat };
            iniTombol.FlatAppearance.BorderSize = 0;
            tlp.Controls.Add(iniTombol);
            Button iniTombol2 = new Button { Text = "", Image = Image.FromFile("D:/Documents/Kuliah/Kuliah smt 7/Konstruksi Perangkat Lunak/fpfp/FPKPL/DiagramToolkit/DiagramToolkit/Resources/Mobile/checkbox.png"), FlatStyle = FlatStyle.Flat };
            iniTombol2.FlatAppearance.BorderSize = 0;
            tlp.Controls.Add(iniTombol2);
            Button iniTombol3 = new Button { Text = "", Image = Image.FromFile("D:/Documents/Kuliah/Kuliah smt 7/Konstruksi Perangkat Lunak/fpfp/FPKPL/DiagramToolkit/DiagramToolkit/Resources/Mobile/checkbox.png"), FlatStyle = FlatStyle.Flat };//deklarasi tombol pake gambar dari drag solution explorer
            iniTombol3.FlatAppearance.BorderSize = 0;
            tlp.Dock = DockStyle.Fill;

            acc.Add(tlp, "General", "Enter the client's information.", 0, true);//memasukkan panel pertama

            acc.Add(new TextBox { Dock = DockStyle.Fill, Multiline = true, BackColor = Color.White }, "Memo", "Additional Client Info", 1, true, contentBackColor: Color.Transparent);//menambahkan panel kedua

            acc.Dock = DockStyle.Fill;
            SplitContainer mainPanel = new SplitContainer();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Panel1.Controls.Add(acc);
            mainPanel.FixedPanel = FixedPanel.Panel1;
            mainPanel.MinimumSize = new Size(300,200);
            mainPanel.Panel2.BackColor = Color.White;
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


