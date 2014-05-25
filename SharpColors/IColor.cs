using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpColors
{
    public interface IColor<TColor> where TColor : IColor<TColor>
    {
    }
}