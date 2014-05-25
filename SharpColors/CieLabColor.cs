using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpColors
{
    public struct CieLabColor : IColor<CieLabColor>
    {
        public float A { get; private set; }

        public float B { get; private set; }

        public float L { get; private set; }

        public CieLabColor(float l, float a, float b)
            : this()
        {
            L = l;
            A = a;
            B = b;
        }
    }
}