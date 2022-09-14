using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRC_App.Controls
{
    public class Collection<T> : IEnumerable<T>
    {
        private T[] vector = new T[1000];
        private int count = 0;

        public void Add(T element)
        {
            vector[count++] = element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vector.Take(count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerator enumerator = vector.GetEnumerator();
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
    }
}