using AdventOfCode2019.Models;
using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Processors
{
    public class FuelCounter
    {
        public double CalculateFuelRequired(double mass)
        {
            double fuelRequired = Math.Floor(mass / 3) - 2;

            if (fuelRequired < 0)
            {
                return 0;
            }
            else
            {
                return fuelRequired;
            }
        }

        public double CalculateFuelForFuel(double mass)
        {
            double fuelRequired = CalculateFuelRequired(mass);

            if (fuelRequired == 0)
            {
                return 0;
            }

            return fuelRequired += CalculateFuelForFuel(fuelRequired);
        }

        public double CalculateTotalFuelRequirement(IEnumerable<Module> modules)
        {
            double totalFuelRequired = 0;

            foreach (Module module in modules)
            {
                totalFuelRequired += module.FuelRequired;
            }

            return totalFuelRequired;
        }

        public double CalculateTotalFuelForFuelRequirement(IEnumerable<Module> modules)
        {
            double totalFuelRequired = 0;

            foreach (Module module in modules)
            {
                totalFuelRequired += module.FuelForFuel;
            }

            return totalFuelRequired;
        }
    }
}