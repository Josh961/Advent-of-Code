using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class IntcodeCPU
    {
        public IList<int> ApplyOperations(IList<int> initialMemory)
        {
            IList<int> memory = ListExtensionMethods.DeepCopy(initialMemory);

            int instructionPointer = 0;
            for (int i = 0; memory[i] != 99; i += instructionPointer)
            {
                int instruction = memory[i];
                int parameterOne = memory[i + 1];
                int parameterTwo = memory[i + 2];
                int parameterThree = memory[i + 3];

                switch (instruction)
                {
                    case 1:
                        int additionResult = memory[parameterOne] + memory[parameterTwo];
                        memory[parameterThree] = additionResult;
                        instructionPointer = 4;
                        break;
                    case 2:
                        int multiplicationResult = memory[parameterOne] * memory[parameterTwo];
                        memory[parameterThree] = multiplicationResult;
                        instructionPointer = 4;
                        break;
                }
            }

            return memory;
        }
    }
}
