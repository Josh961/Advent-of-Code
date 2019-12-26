using AdventOfCode2019.IO;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2019
{
    public class IntcodeComputer
    {
        private readonly IntcodeCPU intcodeCPU;
        private readonly IOutputWriter outputWriter;

        public IntcodeComputer(IOutputWriter outputWriter)
        {
            intcodeCPU = new IntcodeCPU();
            this.outputWriter = outputWriter;
        }

        public void Initialize()
        {
            IList<int> initialMemory = InitializeMemory();

            int finalValue = RestoreGravityAssist(initialMemory);
            int finalValueWithNounAndVerb = FindNounAndVerb(initialMemory);

            WriteFinalValues(finalValue, finalValueWithNounAndVerb);
        }

        private IList<int> InitializeMemory()
        {
            IList<int> memory = new List<int>();

            string currentDirectory = Directory
                .GetParent(Environment.CurrentDirectory).Parent.FullName
                .ToString().Replace("\\bin", "");

            IEnumerable<string> linesOfIntegers = File.ReadLines($"{currentDirectory}/FlatFiles/day_2_intcode_inputs.txt");
            foreach(string line in linesOfIntegers)
            {
                string[] commaDelimitedLine = line.Split(",");
                for (int i = 0; i < commaDelimitedLine.Length; i++)
                {
                    memory.Add(int.Parse(commaDelimitedLine[i]));
                }
            }

            return memory;
        }

        private int RestoreGravityAssist(IList<int> initialMemory)
        {
            IList<int> memory = ListExtensionMethods.DeepCopy(initialMemory);
            int noun = 12;
            int verb = 2;
            memory[1] = noun;
            memory[2] = verb;
            IList<int> finalMemory = intcodeCPU.ApplyOperations(memory);

            return finalMemory[0];
        }

        private int FindNounAndVerb(IList<int> initialMemory)
        {
            IList<int> memory = ListExtensionMethods.DeepCopy(initialMemory);
            int noun = 0;
            int verb = 0;

            bool validNounAndVerb = false;
            while (!validNounAndVerb)
            {
                for (int i = 0; i < 100 && !validNounAndVerb; i++) {
                    for (int j = 0; j < 100 && !validNounAndVerb; j++)
                    {
                        noun = i;
                        verb = j;
                        memory[1] = noun;
                        memory[2] = verb;
                        IList<int> finalMemory = intcodeCPU.ApplyOperations(memory);
                        if (finalMemory[0] == 19690720)
                        {
                            validNounAndVerb = true;
                        }
                    }
                }
            }

            return 100 * noun + verb;
        }

        private void WriteFinalValues(int finalValue, int finalValueWithNounAndVerb)
        {
            outputWriter.WriteLine($"Value at position zero: {finalValue}");
            outputWriter.WriteLine($"Value at position zero with valid noun and verb: {finalValueWithNounAndVerb}");
        }
    }
}
