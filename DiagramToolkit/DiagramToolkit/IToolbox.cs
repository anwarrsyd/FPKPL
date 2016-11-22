using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public delegate void buttonClicked(ITool tool);

    public interface IToolbox
    {
        event buttonClicked ToolSelected;
        void AddTool(ITool tool);
        void RemoveTool(ITool tool);
        ITool ActiveTool { get; set; }
    }
}
