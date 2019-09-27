using System;
using System.Collections.Generic;
using System.Linq;
using Data.Reader.Interfaces;

namespace Data.Reader.Mapping
{
    public class ListValuesMapping<TValue> : ITxtLinesMapping<IEnumerable<TValue[]>>
        where TValue : struct, IConvertible
    {
        public IEnumerable<TValue[]> Map(IEnumerable<string[]> source, IEnumerable<TValue[]> destination)
        {
            List<TValue[]> dataValues = new List<TValue[]>();
            if (destination!=null)
                dataValues = new List<TValue[]>(destination);

            foreach (var stringValues in source)
            {
                TValue[] dataValue = new TValue[stringValues.Length];
                for (int i = 0; i < stringValues.Length; i++)
                    dataValue[i] = (TValue)Convert.ChangeType(stringValues[i], typeof(TValue));

                dataValues.Add(dataValue);
            }

            return dataValues;
        }

        public IEnumerable<string[]> Map(IEnumerable<TValue[]> source, IEnumerable<string[]> destination)
        {
            throw new NotImplementedException();
        }
    }
}