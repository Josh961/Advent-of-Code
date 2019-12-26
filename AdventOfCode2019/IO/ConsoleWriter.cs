using System;

namespace AdventOfCode2019.IO
{
    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
        public void Write(string msg) {
            Console.Write(msg);
        }
    }
}
