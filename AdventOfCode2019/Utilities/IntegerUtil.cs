using System.Collections.Generic;

namespace AdventOfCode2019.Utilities
{
    public static class IntegerUtil
    {
        public static IList<int> ParseInts(string line)
        {
            IList<int> intArray = new List<int>();

            string[] commaDelimitedLine = line.Split(",");
            for (int i = 0; i < commaDelimitedLine.Length; i++)
            {
                intArray.Add(int.Parse(commaDelimitedLine[i]));
            }

            return intArray;
        }
    }
}
