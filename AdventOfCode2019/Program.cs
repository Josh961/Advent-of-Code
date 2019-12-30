using AdventOfCode2019.IO;
using AdventOfCode2019.Systems;

namespace AdventOfCode2019
{
    class Program
    {
        private const int MaxMenuOptions = 26;

        static void Main(string[] args)
        {
            IOutputWriter outputWriter = new ConsoleWriter();
            IInputReader inputReader = new ConsoleReader();


            StoryWriter storyWriter = new StoryWriter(outputWriter);
            UserInputReader userInputReader = new UserInputReader(inputReader, outputWriter);

            storyWriter.Title();
            storyWriter.AllDays();

            for (int input = userInputReader.GetNumericInputInclusive(MaxMenuOptions); input != MaxMenuOptions; input = userInputReader.GetNumericInputInclusive(MaxMenuOptions))
            {
                switch (input)
                {
                    case 1:
                        FuelCounterUpper fuelCounterUpper = new FuelCounterUpper(outputWriter);
                        fuelCounterUpper.Initialize();
                        break;
                    case 2:
                        IntcodeComputer intcodeComputer = new IntcodeComputer(outputWriter);
                        intcodeComputer.Initialize();
                        break;
                    case 3:
                        FuelManager fuelManager = new FuelManager(outputWriter);
                        fuelManager.Initialize();
                        break;
                }

                inputReader.ReadLine();
                storyWriter.AllDays();
            }

        }
    }
}
