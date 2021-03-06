﻿using AdventOfCode2019.IO;
using AdventOfCode2019.Models;
using AdventOfCode2019.Processors;
using AdventOfCode2019.Utilities;
using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Systems
{
    public class FuelCounterUpper
    {
        private readonly FuelCounter fuelCounter;
        private readonly IOutputWriter outputWriter;

        public FuelCounterUpper(IOutputWriter outputWriter)
        {
            fuelCounter = new FuelCounter();
            this.outputWriter = outputWriter;
        }

        public void Initialize()
        {
            IEnumerable<Module> modules = InitializeModulesWithFuelRequirements();

            double totalFuelRequired = fuelCounter.CalculateTotalFuelRequirement(modules);
            double totalFuelForFuelRequired = fuelCounter.CalculateTotalFuelForFuelRequirement(modules);

            WriteFuelRequirements(totalFuelRequired, totalFuelForFuelRequired);
        }

        private List<Module> InitializeModulesWithFuelRequirements()
        {
            List<Module> modules = new List<Module>();

            IEnumerable<string> masses = FileUtil.ReadLines("day_1_module_masses.txt");
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

        private void WriteFuelRequirements(double totalFuelRequired, double totalFuelForFuelRequired)
        {
            outputWriter.WriteLine(string.Format("Total fuel requirement: {0:n0}", totalFuelRequired));
            outputWriter.WriteLine(string.Format("Total fuel for fuel requirement: {0:n0}", totalFuelForFuelRequired));
        }
    }
}
