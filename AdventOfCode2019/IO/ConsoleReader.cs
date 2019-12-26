using System;

namespace AdventOfCode2019.IO
{
    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
