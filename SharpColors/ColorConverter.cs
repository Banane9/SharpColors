using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpColors
{
    public static class ColorConverter
    {
        public static RgbColor ToRgb(this XyzColor xyzColor)
        {
            double x = (double)xyzColor.X / 100;
            double y = (double)xyzColor.Y / 100;
            double z = (double)xyzColor.Z / 100;

            double r = (x * 3.2406) + (y * -1.5372) + (z * -0.4986);
            double g = (x * -0.9689) + (y * 1.8758) + (z * 0.0415);
            double b = (x * 0.0557) + (y * -0.2040) + (z * 1.0570);

            if (r > 0.0031308)
                r = (1.055 * Math.Pow(r, 1d / 2.4)) - 0.055;
            else
                r *= 12.92;

            if (g > 0.0031308)
                g = (1.055 * Math.Pow(g, 1d / 2.4)) - 0.055;
            else
                g *= 12.92;

            if (b > 0.0031308)
                b = (1.055 * Math.Pow(b, 1d / 2.4)) - 0.055;
            else
                b *= 12.92;

            return new RgbColor((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }

        public static XyzColor ToXyz(this RgbColor rgbColor)
        {
            double r = (double)rgbColor.R / 255d;
            double g = (double)rgbColor.G / 255d;
            double b = (double)rgbColor.B / 255d;

            if (r > 0.04045)
                r = Math.Pow((r + 0.055) / 1.055, 2.4);
            else
                r /= 12.92;

            if (g > 0.04045)
                g = Math.Pow((g + 0.055) / 1.055, 2.4);
            else
                g /= 12.92;

            if (b > 0.04045)
                b = Math.Pow((b + 0.055) / 1.055, 2.4);
            else
                b /= 12.92;

            r *= 100;
            g *= 100;
            b *= 100;

            float x = (float)((r * 0.4124) + (g * 0.3576) + (b * 0.1805));
            float y = (float)((r * 0.2126) + (g * 0.7152) + (b * 0.0722));
            float z = (float)((r * 0.0193) + (g * 0.1192) + (b * 0.9505));

            return new XyzColor(x, y, z);
        }
    }
}