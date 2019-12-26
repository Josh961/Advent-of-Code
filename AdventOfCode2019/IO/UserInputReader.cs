using System;

namespace AdventOfCode2019.IO
{
    public class UserInputReader
    {
        private readonly IInputReader inputReader;
        private readonly IOutputWriter outputWriter;

        public UserInputReader(IInputReader inputReader, IOutputWriter outputWriter)
        {
            this.inputReader = inputReader;
            this.outputWriter = outputWriter;
        }

        public int GetNumericInputInclusive(int upperBound)
        {
            int input = 0;
            bool validInput = false;

            while (!validInput)
            {
                outputWriter.Write("> ");
                string userInput = inputReader.ReadLine();
                if (int.TryParse(userInput, out int numericInput) && InputInBounds(numericInput, upperBound))
                {
                    input = numericInput;
                    validInput = true;
                }
                else
                {
                    outputWriter.WriteLine($"Input must be between 1 and {upperBound}");
                }
            }

            return input;
        }

        private bool InputInBounds(int input, int upperBound)
        {
            if (input > 0 && input <= upperBound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
