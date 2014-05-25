using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpColors
{
    public struct XyzColor : IColor<XyzColor>
    {
        /// <summary>
        /// Contains the maximum value for the X component. 95.047
        /// </summary>
        public const float MaxX = 95.047f;

        /// <summary>
        /// Contains the maximum value for the Y component. 100.000
        /// </summary>
        public const float MaxY = 100f;

        /// <summary>
        /// Contains the maximum value for the Z component. 108.883
        /// </summary>
        public const float MaxZ = 108.883f;

        /// <summary>
        /// Gets the X component of the color. Range from 0 to MaxX
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the color. Range from 0 to MaxY
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the color. Range from 0 to MaxZ
        /// </summary>
        public float Z { get; private set; }

        public XyzColor(float x, float y, float z)
            : this()
        {
            if (x < 0 || x > MaxX)
                throw new ArgumentOutOfRangeException("x", "Component has to be greater than or equal to 0 and less than " + MaxX);

            if (y < 0 || y > MaxY)
                throw new ArgumentOutOfRangeException("y", "Component has to be greater than or equal to 0 and less than " + MaxY);

            if (z < 0 || z > MaxZ)
                throw new ArgumentOutOfRangeException("z", "Component has to be greater than or equal to 0 and less than " + MaxZ);

            X = x;
            Y = y;
            Z = z;
        }
    }
}