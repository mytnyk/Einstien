using System;
using System.Collections.Generic;
using System.Linq;

namespace Einstien
{
    class Permutations
    {
        private IEnumerable<List<T>> GetLists<T>(List<T> list, T value)
        {
            for (int i = 0; i < list.Count + 1; i++)
            {
                var copy = list.ToList();
                copy.Insert(i, value);
                yield return copy;
            }
        }

        public IEnumerable<List<T>> Create<T>()
        {
            return Create(Enum.GetValues(typeof(T)).Cast<T>());
        }
        public IEnumerable<List<T>> Create<T>(IEnumerable<T> array)
        {
            List<List<T>> lists = new List<List<T>>() { new List<T>() };
            
            foreach (var e in array)
            {
                lists = lists.SelectMany(list => GetLists(list, e)).ToList();
            }
            return lists;
        }
    }
}
