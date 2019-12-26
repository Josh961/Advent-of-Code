using AdventOfCode2019.IO;
using System;

namespace AdventOfCode2019
{
    public class StoryWriter
    {
        public const int TotalDaysInCalendar = 25;

        private readonly IOutputWriter writer;
        private readonly string[] days = new string[TotalDaysInCalendar];

        public StoryWriter(IOutputWriter writer)
        {
            this.writer = writer;
            days[0] = "The Tyranny of the Rocket Equation";
            days[1] = "1202 Program Alarm";
        }

        public void Title()
        {
            writer.WriteLine("\n-------------------------");
            writer.WriteLine("-  Advent of Code 2019  -");
            writer.WriteLine("-------------------------\n");
        }

        public void AllDays()
        {
            for (int i = 0; i < days.Length; i++)
            {
                writer.WriteLine($"{i + 1}) {days[i]}");
            }
            writer.WriteLine($"{days.Length + 1}) Exit");
        }

        public int GetMaxNumberOfDays()
        {
            return days.Length;
        }
    }
}
