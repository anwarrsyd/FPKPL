using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DiagramToolkit
{
    public class DefaultToolbox : FlowLayoutPanel, IToolbox
    {
        private ITool activeTool;
        public ITool ActiveTool
        {
            get
            {
                return this.activeTool;
            }

            set
            {
                this.activeTool = value;
            }
        }

        public event buttonClicked ToolSelected;

        public void AddTool(ITool tool)
        {
            Debug.WriteLine(tool.Name + " is added into toolbox.");

            if (tool is Button)
            {
                Button toolButton = (Button)tool;
                toolButton.Click += toggleButton_CheckedChanged;
                this.Controls.Add(toolButton);
            }
        }

        public void RemoveTool(ITool tool)
        {
            foreach (Button i in this.Controls)
            {
                if (i is ITool)
                {
                    if (i.Equals(tool))
                    {
                        this.Controls.Remove(i);
                    }
                }
            }
        }
        
        private void toggleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                    if (button is ITool)
                    {
                        this.activeTool = (ITool)button;
                        Debug.WriteLine(this.activeTool.Name + " is activated.");

                        if (ToolSelected != null)
                        {
                            ToolSelected(this.activeTool);
                        }
                    }
                    else
                    {
                        throw new InvalidCastException("The tool is not an instance of ITool.");
                    }
                }
            }
        }
    }
