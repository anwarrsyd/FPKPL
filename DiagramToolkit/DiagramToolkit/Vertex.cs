using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    public abstract class Vertex: DrawingObject, IObservable
    {
        private List<Edge> edges;
        public Vertex()
        {
            edges = new List<Edge>();
        }

        public void Update(int x, int y)
        {
            foreach(var edge in edges)
            {
                edge.Update(this, x, y);
            }
        }
        public void Subscribe(IObserver O)
        {
            edges.Add((Edge)O);
        }

        public abstract void Unsubscribe(IObserver O);
    }
}
