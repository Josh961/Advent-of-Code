using System;

namespace AdventOfCode2019.Models
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        public int ManhattanDistance { get => Math.Abs(X) + Math.Abs(Y); }
        public int FirstWireSteps { get; set; }
        public int SecondWireSteps { get; set; }
        public int TotalSteps { get => FirstWireSteps + SecondWireSteps; }

        public Point(int x, int y, int secondWireSteps)
        {
            X = x;
            Y = y;
            SecondWireSteps = secondWireSteps;
        }
    }
}
