using DiagramToolkit.Api;
using DiagramToolkit.Api.Shapes;
using System;
using System.Windows.Forms;
namespace DiagramToolkit.Tools
{
    public class TextTool : Button, ITool
    {
        private Text text;
        private ICanvas canvas;

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public TextTool()
        {
            this.Name = "Text tool";
            this.Image = IconSet.font;
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (canvas.GetObjectAt(e.X, e.Y) == null)
                {              
                    TextPrompt input = new TextPrompt();
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        text = new Text();
                        text.Value = input.getTxtInput();
                        text.X = e.X;
                        text.Y = e.Y;
                        canvas.AddDrawingObject(text);
                    }                   
                }
                else {

                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (canvas.GetObjectAt(e.X, e.Y) is Text)
                {
                    Text objectHere = (Text)canvas.GetObjectAt(e.X, e.Y);
                    System.Diagnostics.Debug.WriteLine("Right Click");
                    TextPrompt input = new TextPrompt();
                    input.setTxtInput(objectHere.Value);
                    if (input.ShowDialog() == DialogResult.OK)
                    {
                        canvas.RemoveDrawingObject(canvas.GetObjectAt(e.X, e.Y));
                        text = new Text();
                        text.Value = input.getTxtInput();
                        text.X = e.X;
                        text.Y = e.Y;
                        canvas.AddDrawingObject(text);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("TextBox: " + e.X + " - " + e.Y);
                    }
                }
            }
        }
        public void ToolMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
