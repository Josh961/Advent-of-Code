using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2019.Test
{
    [TestFixture]
    public class FuelCounterTests
    {
        private FuelCounter cut;

        [SetUp]
        public void Setup()
        {
            cut = new FuelCounter();
        }

        [TestCase(12, ExpectedResult = 2)]
        [TestCase(14, ExpectedResult = 2)]
        [TestCase(1969, ExpectedResult = 654)]
        [TestCase(100756, ExpectedResult = 33583)]
        public double CalculateFuelRequired_WholeNumbers_ReturnsExpectedFuel(double mass)
        {
            return cut.CalculateFuelRequired(mass);
        }

        [TestCase(12.1, ExpectedResult = 2)]
        [TestCase(14.2, ExpectedResult = 2)]
        [TestCase(1969.3, ExpectedResult = 654)]
        [TestCase(100756.4, ExpectedResult = 33583)]
        public double CalculateFuelRequired_DecimalValues_ReturnsExpectedFuel(double mass)
        {
            return cut.CalculateFuelRequired(mass);
        }

        [TestCase(-12.1, ExpectedResult = 0)]
        [TestCase(-14.2, ExpectedResult = 0)]
        [TestCase(-1969.3, ExpectedResult = 0)]
        [TestCase(-100756.4, ExpectedResult = 0)]
        public double CalculateFuelRequired_NegativeValues_ReturnsZero(double mass)
        {
            return cut.CalculateFuelRequired(mass);
        }

        [TestCase(-1, ExpectedResult = 0)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 0)]
        public double CalculateFuelRequired_BoundaryValues_ReturnsZero(double mass)
        {
            return cut.CalculateFuelRequired(mass);
        }

        [TestCase(2, ExpectedResult = 0)]
        [TestCase(3, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 0)]
        [TestCase(5, ExpectedResult = 0)]
        [TestCase(6, ExpectedResult = 0)]
        [TestCase(7, ExpectedResult = 0)]
        [TestCase(8, ExpectedResult = 0)]
        public double CalculateFuelRequired_SmallBoundaryWholeNumbers_ReturnsZero(double mass)
        {
            return cut.CalculateFuelRequired(mass);
        }

        [TestCase(9, ExpectedResult = 1)]
        [TestCase(10, ExpectedResult = 1)]
        public double CalculateFuelRequired_SmallWholeNumbers_ReturnsExpectedFuel(double mass)
        {
            return cut.CalculateFuelRequired(mass);
        }

        [TestCase(1969, ExpectedResult = 966)]
        [TestCase(100756, ExpectedResult = 50346)]
        public double CalculateFuelForFuel_WholeNumbers_ReturnsExpectedFuel(double mass)
        {
            return cut.CalculateFuelForFuel(mass);
        }

        [Test]
        public void CalculateTotalFuelRequirement_ListOfModules_ReturnsExpectedTotalFuel()
        {
            List<Module> modules = new List<Module>();

            string currentDirectory = Directory
                .GetParent(Environment.CurrentDirectory).Parent.FullName
                .ToString().Replace(".Test\\bin", "");

            IEnumerable<string> masses = File.ReadLines($"{currentDirectory}/FlatFiles/module_masses.txt");
            foreach (string mass in masses)
            {
                modules.Add(new Module
                {
                    FuelRequired = cut.CalculateFuelRequired(Convert.ToDouble(mass))
                });
            }

            double actualTotalFuelRequired = cut.CalculateTotalFuelRequirement(modules);

            Assert.AreEqual(3239503, actualTotalFuelRequired);
        }

        [Test]
        public void CalculateTotalFuelForFuelRequirement_ListOfModules_ReturnsExpectedTotalFuel()
        {
            List<Module> modules = new List<Module>();

            string currentDirectory = Directory
                .GetParent(Environment.CurrentDirectory).Parent.FullName
                .ToString().Replace(".Test\\bin", "");

            IEnumerable<string> masses = File.ReadLines($"{currentDirectory}/FlatFiles/module_masses.txt");
            foreach (string mass in masses)
            {
                modules.Add(new Module
                {
                    FuelForFuel= cut.CalculateFuelForFuel(Convert.ToDouble(mass))
                });
            }

            double actualTotalFuelRequired = cut.CalculateTotalFuelForFuelRequirement(modules);

            Assert.AreEqual(4856390, actualTotalFuelRequired);
        }
    }
}