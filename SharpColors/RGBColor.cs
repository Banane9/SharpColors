using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpColors
{
    public struct RgbColor : IColor<RgbColor>
    {
        /// <summary>
        /// Gets the B component of the color. Range from 0 to 255
        /// </summary>
        public byte B { get; private set; }

        /// <summary>
        /// Gets the G component of the color. Range from 0 to 255
        /// </summary>
        public byte G { get; private set; }

        /// <summary>
        /// Gets the R component of the color. Range from 0 to 255
        /// </summary>
        public byte R { get; private set; }

        public RgbColor(byte r, byte g, byte b)
            : this()
        {
            //no need for range checks; is enforced by byte type.

            R = r;
            G = g;
            B = b;
        }
    }
}