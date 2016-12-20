using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Api
{
    public abstract class Edge : DrawingObject, IObserver
    {
        private Vertex vertex1, vertex2;

        public abstract void Update(IObservable vertex, int deltaX, int deltaY);
    }
}
