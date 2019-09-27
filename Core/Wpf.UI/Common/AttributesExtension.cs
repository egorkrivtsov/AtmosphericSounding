using System;
using System.ComponentModel.DataAnnotations;

namespace WpfUI.Common
{
    public static class AttributesExtension
    {
        public static double[] GetRange<TModel, TProperty>(this Func<TModel, TProperty> property)
        {
            return  (Attribute.GetCustomAttribute(property.Method,
                typeof(RangeAttribute)) as RangeAttribute).GetRange();
        }

        public static double[] GetRange(this RangeAttribute rangeAttribute)
        {
            if (rangeAttribute == null)
                return null;
            return new[] { double.Parse(rangeAttribute.Minimum.ToString()), double.Parse(rangeAttribute.Maximum.ToString()) };
        }
    }
}
