using System;

namespace MyPhotoshop
{
    public struct Pixel
    {
        private double r;
        public double R
        {
            get { return r; }
            set
            {
                r = Check(value);
            }
        }
        private double g;
        public double G
        {
            get { return g; }
            set
            {
                g = Check(value);
            }
        }
        private double b;

        public Pixel(double r, double g, double b) : this()
        {
            R = r;
            G = g;
            B = b;
        }

        public double B
        {
            get { return b; }
            set
            {
                b = Check(value);
            }
        }

        private static double Check(double value)
        {
            if (value < 0 || value > 1) throw new ArgumentException();
            return value;
        }
        public static double Trim(double value)
        {
            if (value < 0) return 0;
            if (value > 1) return 1;
            return value;
        }

        public static Pixel operator *(Pixel p, double c)
        {
            return new Pixel(
                Pixel.Trim(p.R * c),
                Pixel.Trim(p.G * c),
                Pixel.Trim(p.B * c));
        }
        public static Pixel operator *(double c, Pixel p)
        {
            return new Pixel(
                Pixel.Trim(p.R * c),
                Pixel.Trim(p.G * c),
                Pixel.Trim(p.B * c));
        }
        
    }
}