using System.Linq;
using System.Reflection;

namespace MyPhotoshop
{
    public class StaticParametersHandler<TParameters> : IParametersHandler<TParameters>
    where TParameters : IParameters, new()
    {
        static PropertyInfo[] properties;
        static ParameterInfo[] description;
        static StaticParametersHandler()
        {
            properties = typeof(TParameters)
                .GetType()
                .GetProperties()
                .Where(z => z.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
            description = typeof(TParameters)
                .GetType()
                .GetProperties()
                .Select(z => z.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(z => z.Length > 0)
                .Select(z => z[0])
                .Cast<ParameterInfo>()
                .ToArray();
        }
        public ParameterInfo[] GetDescription()
        {
            return description;
        }

        public TParameters CreateParameters(double[] values)
        {
            var parameters = new TParameters();
            for(int i = 0; i < values.Length;++i)
                properties[i].SetValue(parameters,values[i], new object[0]);
            return parameters;
        }
    }
}