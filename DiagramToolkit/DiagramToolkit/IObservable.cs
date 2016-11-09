﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramToolkit
{
    interface IObservable
    {
        void Subscribe(IObserver O);
        void Unsubscribe(IObserver O);
    }
}
