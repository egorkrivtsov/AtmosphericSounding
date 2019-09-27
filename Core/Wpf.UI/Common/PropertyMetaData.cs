using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace WpfUI.Common
{
    [Serializable]
    public class PropertyMetaData 
    {
        public Guid Id { get; }

        public string DisplayName { get; }

        public string PropertyFullName { get; set; }

        public double? MinimumValue { get; }

        public double? MaximumValue { get; }

        public PropertyMetaData()
        {
        }

        public PropertyMetaData(PropertyInfo propertyInfo, PropertyInfo[] propertyPath = null)
        {
            Id = Guid.NewGuid();
            PropertyFullName = string.Empty;
            if (propertyPath != null)
            {
                for (int i = 0; i < propertyPath.Length; i++)
                {
                    PropertyFullName += $"{propertyPath[i].Name}.";
                }
            }

            PropertyFullName += propertyInfo.Name;

            object[] attrs = propertyInfo.GetCustomAttributes(true);
            foreach (object attr in attrs)
            {
                switch (attr)
                {
                    case DisplayNameAttribute displayAttr:
                        DisplayName = displayAttr.DisplayName;
                        break;
                    case RangeAttribute rangeAttr:
                    {
                        if (double.TryParse(rangeAttr.Minimum.ToString(), out var val))
                            MinimumValue = val;

                        if (double.TryParse(rangeAttr.Maximum.ToString(), out val))
                            MaximumValue = val;
                        break;
                    }
                }
            }

        }
    }
}