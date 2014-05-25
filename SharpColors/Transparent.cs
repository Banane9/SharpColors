using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpColors
{
    public struct Transparent<TColor> : IColor<Transparent<TColor>> where TColor : IColor<TColor>
    {
        public byte Alpha { get; private set; }

        public TColor Color { get; private set; }

        public Transparent(TColor color, byte alpha)
            : this()
        {
            Color = color;
            Alpha = alpha;
        }
    }
}