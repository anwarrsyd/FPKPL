using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Api
{
    public delegate void buttonClicked(ITool tool);

    public interface IToolbox : IPluginHost
    {
        event buttonClicked ToolSelected;
        void AddTool(ITool tool);
        void RemoveTool(ITool tool);
        ITool ActiveTool { get; set; }
        Size MaximumSize { get; set; }
        bool TabStop { get; set; }
    }
}
