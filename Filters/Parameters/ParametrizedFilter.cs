namespace MyPhotoshop
{
    public abstract class ParametrizedFilter<TParameters> : IFilter
    where TParameters : IParameters, new()
    {
        IParametersHandler<TParameters> handler= new ExpressionsParametersHandler<TParameters>();
        public ParameterInfo[] GetParameters()
        {
            return handler.GetDescription();
        }

        public Photo Process(Photo original, double[] value)
        {
            var parameters = handler.CreateParameters(value);
            return Process(original, parameters);
        }

        public abstract Photo Process(Photo original, TParameters parameters);
    }
}