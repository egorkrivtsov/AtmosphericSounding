using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data.Interfaces
{
    public class SharedList<T>
    {
        private List<T> items = new List<T>();

        private object syncRoot = new object();


        public void Add(T item)
        {
            lock (syncRoot)
            {
                items.Add(item);
            }
        }

        public T Get(int index)
        {
            lock (syncRoot)
            {
                return items[index];
            }
        }

        public T[] GetLast(int number)
        {
            T[] copyItems = new T[number];
            lock (syncRoot)
            {
                if (items.Count > number)
                    items.CopyTo(copyItems, items.Count - number);
                else
                    items.CopyTo(copyItems, 0);
            }
            return copyItems;
        }
    }
}
