using System;
using System.Windows.Forms;

namespace DiagramToolkit.Tools
{
    public partial class TextPrompt : Form
    {
        private Button btnOK;
        private Button btnCancel;
        private TextBox txtInput;

        public TextPrompt()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Input Text";
            this.txtInput = new TextBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(13, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(259, 20);
            this.txtInput.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(196, 39);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(115, 38);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // TextPrompt
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 74);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtInput);
            this.Name = "Input Text";
            this.Load += new System.EventHandler(this.TextPrompt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TextPrompt_Load(object sender, System.EventArgs e)
        {

        }

        public String getTxtInput() {
            return txtInput.Text;
        }

        public void setTxtInput(String input)
        {
            this.txtInput.Text = input;
        }

    }
}