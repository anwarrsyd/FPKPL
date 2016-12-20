using DiagramToolkit.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;


namespace DiagramToolkit
{
    public class DefaultCanvas : Control, ICanvas
    {
        private ITool activeTool;
        private DrawingObject activeObject;
        private DrawingObject prevactiveObject;
        private List<DrawingObject> drawingObjects;
        private UndoRedo _undoRedo;
        public UndoRedo undoRedo
        {
            get { return _undoRedo; }
            set
            {
                _undoRedo = value;
            }
        }
        public DefaultCanvas()
        {
            Init();
        }

        public DefaultCanvas(UndoRedo undoRedo)
        {
            Init();
            this._undoRedo = undoRedo;
        }
        public DrawingObject getprevActiveObject()
        {
            return this.prevactiveObject;
        }
        public DrawingObject getActiveObject()
        {
            return this.activeObject;
        }
        public void setActiveObject(DrawingObject obj)
        {
            this.prevactiveObject = this.activeObject;
            this.activeObject = obj;
            if (this.prevactiveObject != null)
            {
                System.Diagnostics.Debug.WriteLine(this.prevactiveObject.ID.ToString() + " ini aktif obyek yang tadi");
            }
            if (this.activeObject != null)
            {
                System.Diagnostics.Debug.WriteLine(this.activeObject.ID.ToString() + " ini aktif obyek");
            }
        }
        private void Init()
        {
            this.drawingObjects = new List<DrawingObject>();
            this.DoubleBuffered = true;

            this.BackColor = Color.FromArgb(240, 242, 243);
            this.Dock = DockStyle.Fill;

            this.Paint += DefaultCanvas_Paint;
            this.MouseDown += DefaultCanvas_MouseDown;
            this.MouseUp += DefaultCanvas_MouseUp;
            this.MouseMove += DefaultCanvas_MouseMove;
            this.MouseDoubleClick += DefaultCanvas_MouseDoubleClick;
        }

        private void DefaultCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {

            }
        }

        private void DefaultCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseMove(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseUp(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDown(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (DrawingObject obj in drawingObjects)
            {
                obj.Graphics = e.Graphics;
                obj.Draw();
            }
        }

        public void Repaint()
        {
            this.Invalidate();
            this.Update();
        }

        public void SetActiveTool(ITool tool)
        {
            this.activeTool = tool;
        }

        public ITool GetActiveTool()
        {
            return this.activeTool;
        }

        public void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        public void AddDrawingObject(DrawingObject drawingObject)
        {
            this.drawingObjects.Add(drawingObject);
        }

        public void RemoveDrawingObject(DrawingObject drawingObject)
        {
            this.drawingObjects.Remove(drawingObject);
        }

        public DrawingObject GetObjectAt(int x, int y)
        {
            for(int i =drawingObjects.Count-1; i>=0; i--)
            {
                if(drawingObjects[i].Intersect(x, y))
                {
                    return drawingObjects[i];
                }
            }
            return null;
        }

        public DrawingObject SelectObjectAt(int x, int y)
        {
            DrawingObject obj = GetObjectAt(x, y);
            if (obj != null)
            {
                obj.iniSelect();
            }

            return obj;
        }

        public void DeselectAllObjects()
        {
            foreach (DrawingObject drawObj in drawingObjects)
            {
                drawObj.Deselect();
            }
        }
        public void SendToBack(DrawingObject obj)
        {
            this.drawingObjects.Remove(obj);
            this.drawingObjects.Insert(0, obj);
        }
        public void SendToFront(DrawingObject obj)
        {
            this.drawingObjects.Remove(obj);
            this.drawingObjects.Add(obj);
        }
    }
}
