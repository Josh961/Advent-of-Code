using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2019.Utilities
{
    public static class FileUtil
    {
        public static IEnumerable<string> ReadLines(string fileName)
        {
            string currentDirectory = Directory
                .GetParent(Environment.CurrentDirectory).Parent.FullName
                .ToString().Replace("\\bin", "");

            return File.ReadLines($"{currentDirectory}/FlatFiles/{fileName}");
        }

        public static string[] ReadAllLines(string fileName)
        {
            string currentDirectory = Directory
                .GetParent(Environment.CurrentDirectory).Parent.FullName
                .ToString().Replace("\\bin", "");

            return File.ReadAllLines($"{currentDirectory}/FlatFiles/{fileName}");
        }
    }
}
