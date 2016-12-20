using DiagramToolkit.Api.States;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DiagramToolkit.Api
{
    public abstract class DrawingObject: Control
    {
        public Guid ID { get; set; }
        public Graphics Graphics { get; set; }

        //untuk composite pattern
        public DrawingObject parentRectangle;

        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        private DrawingState state;

        public DrawingObject()
        {
            ID = Guid.NewGuid();
            this.ChangeState(PreviewState.GetInstance()); //default initial state
            this.parentRectangle = null;
        }
        
        public abstract bool Intersect(int xTest, int yTest);
        public abstract Point GetIntersectionPoint(Point p1, Point p2); 
        public abstract void Translate(int xAmount, int yAmount);

        public abstract void RenderOnPreview();
        public abstract void RenderOnEditingView();
        public abstract void RenderOnStaticView();

        public void ChangeState(DrawingState state)
        {
            this.state = state;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
        }

        public void iniSelect()
        {
            Debug.WriteLine("Object id=" + ID.ToString() + " is selected.");
            this.state.Select(this);
        }

        public void Deselect()
        {
            Debug.WriteLine("Object id=" + ID.ToString() + " is deselected.");
            this.state.Deselect(this);
        }

    }
}
