using System.Linq;

namespace MyPhotoshop
{
    public class SimpleParametersHandler<TParameters> : IParametersHandler<TParameters>
    where TParameters : IParameters, new()
    {
        public ParameterInfo[] GetDescription()
        {
            return typeof(TParameters)
                .GetType()
                .GetProperties()
                .Select(z => z.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(z => z.Length > 0)
                .Select(z => z[0])
                .Cast<ParameterInfo>()
                .ToArray();
        }

        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();
            var properties = parameters
                .GetType()
                .GetProperties()
                .Where(z => z.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
            for(int i = 0; i < values.Length;++i)
                properties[i].SetValue(parameters,values[i], new object[0]);
            return parameters;
        }
    }
}