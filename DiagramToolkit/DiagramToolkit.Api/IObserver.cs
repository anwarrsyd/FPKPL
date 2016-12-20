using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit.Api
{
    public interface IObserver
    {
        void Update(IObservable vertex, int deltaX, int deltaY);
    }
}
