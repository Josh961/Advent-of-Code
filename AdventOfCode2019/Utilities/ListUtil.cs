using System.Collections.Generic;

namespace AdventOfCode2019.Utilities
{
    public static class ListUtil
    {
        public static IList<T> DeepCopy<T>(IList<T> arr)
        {
            IList<T> copy = new List<T>();

            for(int i = 0; i < arr.Count; i++)
            {
                copy.Add(arr[i]);
            }

            return copy;
        }
    }
}
