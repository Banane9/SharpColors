using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpColors
{
    public static class ColorConverter
    {
        private static XyzColor xyzWhite = XyzColor.White;

        public static CieLabColor ToCieLab(this RgbColor rgbColor)
        {
            return rgbColor.ToXyz().ToCieLab();
        }

        public static CieLabColor ToCieLab(this XyzColor xyzColor)
        {
            double x = xyzColor.X / xyzWhite.X;
            double y = xyzColor.Y / xyzWhite.Y;
            double z = xyzColor.Z / xyzWhite.Z;

            x = xyzToCieLab(x);
            y = xyzToCieLab(y);
            z = xyzToCieLab(z);

            float l = (float)((116 * y) - 16);
            float a = (float)(500 * (x - y));
            float b = (float)(200 * (y - z));

            return new CieLabColor(l, a, b);
        }

        public static RgbColor ToRgb(this XyzColor xyzColor)
        {
            double x = (double)xyzColor.X / 100d;
            double y = (double)xyzColor.Y / 100d;
            double z = (double)xyzColor.Z / 100d;

            double r = (x * 3.2406) + (y * -1.5372) + (z * -0.4986);
            double g = (x * -0.9689) + (y * 1.8758) + (z * 0.0415);
            double b = (x * 0.0557) + (y * -0.2040) + (z * 1.0570);

            r = xyzToRgb(r);
            g = xyzToRgb(g);
            b = xyzToRgb(b);

            r = r > 1 ? 1 : (r < 0 ? 0 : r);
            g = g > 1 ? 1 : (g < 0 ? 0 : g);
            b = b > 1 ? 1 : (b < 0 ? 0 : b);

            return new RgbColor((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }

        public static RgbColor ToRgb(this CieLabColor cieLabColor)
        {
            return cieLabColor.ToXyz().ToRgb();
        }

        public static XyzColor ToXyz(this CieLabColor cieLabColor)
        {
            double y = (cieLabColor.L + 16) / 116d;
            double x = (cieLabColor.A / 500d) + y;
            double z = y - (cieLabColor.B / 200d);

            x = cieLabToXyz(x);
            y = cieLabToXyz(y);
            z = cieLabToXyz(z);

            return new XyzColor((float)(x * xyzWhite.X), (float)(y * xyzWhite.Y), (float)(z * xyzWhite.Z));
        }

        private static double cieLabToXyz(double component)
        {
            double cubed = Math.Pow(component, 3);

            if (cubed > 0.008856)
                return cubed;
            else
                return (component - (16d / 116d)) / 7.787;
        }

        private static double rgbToXyz(double component)
        {
            if (component > 0.04045)
                return Math.Pow((component + 0.055) / 1.055, 2.4);
            else
                return component / 12.92;
        }

        private static XyzColor ToXyz(this RgbColor rgbColor)
        {
            double r = (double)rgbColor.R / 255d;
            double g = (double)rgbColor.G / 255d;
            double b = (double)rgbColor.B / 255d;

            r = rgbToXyz(r);
            g = rgbToXyz(g);
            b = rgbToXyz(b);

            r *= 100;
            g *= 100;
            b *= 100;

            float x = (float)((r * 0.4124) + (g * 0.3576) + (b * 0.1805));
            float y = (float)((r * 0.2126) + (g * 0.7152) + (b * 0.0722));
            float z = (float)((r * 0.0193) + (g * 0.1192) + (b * 0.9505));

            return new XyzColor(x, y, z);
        }

        private static double xyzToCieLab(double component)
        {
            if (component > 0.008856)
                return Math.Pow(component, 1d / 3d);
            else
                return (7.787 * component) + (16d / 116d);
        }

        private static double xyzToRgb(double component)
        {
            if (component > 0.0031308)
                return (1.055 * Math.Pow(component, 1d / 2.4)) - 0.055;
            else
                return component * 12.92;
        }
    }
}