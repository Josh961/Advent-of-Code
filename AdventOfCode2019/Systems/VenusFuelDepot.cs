using AdventOfCode2019.IO;
using AdventOfCode2019.Processors;
using AdventOfCode2019.Utilities;
using System.Collections.Generic;

namespace AdventOfCode2019.Systems
{
    public class VenusFuelDepot
    {
        private readonly IOutputWriter outputWriter;
        private readonly PasswordChecker passwordChecker;

        public VenusFuelDepot(IOutputWriter outputWriter)
        {
            this.outputWriter = outputWriter;
            passwordChecker = new PasswordChecker();
        }

        public void Initialize()
        {
            IList<string> inputRange = FileUtil.ReadAllLines("day_4_password_range.txt");
            IList<int> inputs = IntegerUtil.ParseInts(inputRange[0]);
            int lowerBound = inputs[0];
            int upperBound = inputs[1];

            int validPasswords = 0;
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (passwordChecker.CheckPassword(i))
                {
                    validPasswords++;
                }
            }

            outputWriter.WriteLine($"{validPasswords}");
        }
    }
}