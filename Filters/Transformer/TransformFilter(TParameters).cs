using System;
using System.Drawing;

namespace MyPhotoshop
{
    public class TransformFilter<TParameters> : ParametrizedFilter<TParameters> 
        where TParameters : IParameters, new()
    {
        public ITransformer<TParameters> transformer;
        string name;
        public TransformFilter(string name, ITransformer<TParameters> transformer)
        {
            this.transformer = transformer;
            this.name = name;
        }
        public override Photo Process(Photo original, TParameters parameters)
        {
            var oldSize = new Size(original.width, original.height);
            transformer.Prepare(oldSize,parameters);
            var result = new Photo(transformer.ResultSize.Width, transformer.ResultSize.Height);
            for(int x = 0; x < result.width; x++)
                for (int y = 0; y < result.height; y++)
                {
                    var point = new Point(x, y);
                    var oldPoint = transformer.MapPoint(point);
                    if(oldPoint.HasValue)
                        result[x, y] = original[oldPoint.Value.X, oldPoint.Value.Y];
                }

            return result;
        }
        
        public override string ToString()
        {
            return name;
        }
    
    }
}