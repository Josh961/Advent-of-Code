using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2019
{
    public class FuelCounterUpper
    {
        private FuelCounter fuelCounter;

        public FuelCounterUpper()
        {
            fuelCounter = new FuelCounter();
        }

        public void Initialize()
        {
            IEnumerable<Module> modules = InitializeModulesWithFuelRequirements();

            double totalFuelRequired = fuelCounter.CalculateTotalFuelRequirement(modules);
            Console.WriteLine(totalFuelRequired);

            double totalFuelForFuelRequired = fuelCounter.CalculateTotalFuelForFuelRequirement(modules);
            Console.WriteLine(totalFuelForFuelRequired);
        }

        private List<Module> InitializeModulesWithFuelRequirements()
        {
            List<Module> modules = new List<Module>();

            string currentDirectory = Directory
                .GetParent(Environment.CurrentDirectory).Parent.FullName
                .ToString().Replace("\\bin", "");

            IEnumerable<string> masses = File.ReadLines($"{currentDirectory}/FlatFiles/module_masses.txt");
            foreach (string m in masses)
            {
                double mass = Convert.ToDouble(m);
                modules.Add(new Module
                {
                    FuelRequired = fuelCounter.CalculateFuelRequired(mass),
                    FuelForFuel = fuelCounter.CalculateFuelForFuel(mass)
                });
            }

            return modules;
        }
    }
}
