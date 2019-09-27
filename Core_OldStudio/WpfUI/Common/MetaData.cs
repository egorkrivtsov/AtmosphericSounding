using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WpfUI.Common
{
    public static class MetaData
    {
        public static void InitCache<T>()
        {
            CacheWrapper.Add(typeof(T).FullName,Parse<T>());
        }

        public static IEnumerable<PropertyMetaData> FromCache<T>()
        {
            return CacheWrapper
                .Get<IEnumerable<PropertyMetaData>>(typeof(T).FullName);
        }

        public static IEnumerable<PropertyMetaData> FromCache<T>(Func<PropertyMetaData,bool> whereCondition)
        {
            return FromCache<T>().Where(whereCondition);
        }

        private static List<PropertyMetaData> Parse<T>()
        {
            return Parse<T>(typeof(T), new PropertyInfo[]{});
        }

        private static List<PropertyMetaData> Parse<T>(Type type, PropertyInfo[] propertyPath)
        {
            var propertiesMetaData = new List<PropertyMetaData>();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.IsClass)
                    foreach (var propertyMetaData in Parse<T>(property.PropertyType, propertyPath.Add(property)))
                        propertiesMetaData.Add(propertyMetaData);

                propertiesMetaData.Add(new PropertyMetaData(property, propertyPath));
            }

            return propertiesMetaData;
        }
    }
}
