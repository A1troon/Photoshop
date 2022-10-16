using System;
using System.Drawing;

namespace MyPhotoshop
{
    public class FreeTransformer : ITransformer<EmptyParameters>
    {
        public FreeTransformer(Func<Size, Size> sizeTransformer, Func<Point, Size, Point> pointTransformer)
        {
            this.sizeTransformer = sizeTransformer;
            this.pointTransformer = pointTransformer;
        }

        public Func<Size, Size> sizeTransformer;

        public Func<Point, Size, Point> pointTransformer;

        public Size oldSize;
        
        public void Prepare(Size size, EmptyParameters parameters)
        {
            oldSize = size;
            ResultSize = sizeTransformer(oldSize);
        }

        public Size ResultSize { get; private set; }
        public Point? MapPoint(Point newPoint)
        {
            return pointTransformer(newPoint, oldSize);
        }
    }
}