﻿
using DiagramToolkit.Api;
using DiagramToolkit.Api.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiagramToolkit.Commands
{
    public class InsertCommand : ICommand

    {
        private Rectangle rectangle;
        private ICanvas canvas;

        public InsertCommand(Rectangle rectangle, ICanvas canvas)
        {
            this.rectangle = rectangle;
            this.canvas = canvas;
        }

        public void Execute()
        {
            canvas.RemoveDrawingObject(rectangle);
        }

        public void UnExecute()
        {
            canvas.AddDrawingObject(rectangle);
        }
    }
}