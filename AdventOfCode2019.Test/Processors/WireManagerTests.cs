using AdventOfCode2019.Models;
using AdventOfCode2019.Processors;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Test.Processors
{
    [TestFixture]
    public class WireManagerTests
    {
        private WireManager cut;

        [SetUp]
        public void Setup()
        {
            cut = new WireManager();
        }

        [Test]
        public void  MapPoints_ValidWirePath_ReturnsCoordinates()
        {
            IList<string> wirePath = new List<string> { "U2", "R3", "D2", "L1" };
            IDictionary<int, HashSet<int>> expectedCoordinates = new Dictionary<int, HashSet<int>>()
            {
                { 0, new HashSet<int> { 1, 2 } },
                { 1, new HashSet<int> { 2 } },
                { 2, new HashSet<int> { 0, 2 } },
                { 3, new HashSet<int> { 0, 1, 2 } },
            };

            IDictionary<int, HashSet<int>> coordinates = cut.MapPoints(wirePath);

            Assert.IsTrue(CheckCoordinateEquality(expectedCoordinates, coordinates));
        }

        [Test]
        public void LocateIntersectionPoints_CoordinatesAndWirePath_ReturnsIntersectionPoint()
        {
            IDictionary<int, HashSet<int>> coordinates = new Dictionary<int, HashSet<int>>()
            {
                { 0, new HashSet<int> { 1, 2 } },
                { 1, new HashSet<int> { 2 } },
                { 2, new HashSet<int> { 0, 2 } },
                { 3, new HashSet<int> { 0, 1, 2 } },
            };
            IList<string> wirePath = new List<string> { "R2" };

            IList<Point> intersectionPoints = cut.LocateIntersectionPoints(coordinates, wirePath);

            Point intersectionPoint = intersectionPoints[0];
            Assert.AreEqual(1, intersectionPoints.Count);
            Assert.IsTrue(intersectionPoints.Any(point => point.X == 2 && point.Y == 0));
        }

        [Test]
        public void LocateIntersectionPoints_CoordinatesAndWirePath_ReturnsMultipleIntersectionPoints()
        {
            IDictionary<int, HashSet<int>> coordinates = new Dictionary<int, HashSet<int>>()
            {
                { 0, new HashSet<int> { 1, 2 } },
                { 1, new HashSet<int> { 2 } },
                { 2, new HashSet<int> { 0, 2 } },
                { 3, new HashSet<int> { 0, 1, 2 } },
            };
            IList<string> wirePath = new List<string> { "R2", "U2" };

            IList<Point> intersectionPoints = cut.LocateIntersectionPoints(coordinates, wirePath);

            Point intersectionPointOne = intersectionPoints[0];
            Point intersectionPointTwo = intersectionPoints[1];
            Assert.AreEqual(2, intersectionPoints.Count);
            Assert.IsTrue(intersectionPoints.Any(point => point.X == 2 && point.Y == 0));
            Assert.IsTrue(intersectionPoints.Any(point => point.X == 2 && point.Y == 2));
        }

        [Test]
        public void ClosestManhattanDistance_ListOfIntersectionPoints_ReturnsClosestPoint()
        {
            IList<Point> intersectionPoints = new List<Point>()
            {
                new Point(10, 10, 0),
                new Point(20, 40, 0),
                new Point(15, 30, 0),
                new Point(2, 10, 0),
            };

            int closesDistance = cut.ClosestManhattanDistance(intersectionPoints);

            Assert.AreEqual(12, closesDistance);
        }

        [Test]
        public void WireManagerIntegrationTestOne_TwoWirePaths_ReturnsClosestDistance()
        {
            IList<string> wirePathOne = new List<string> { "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72" };
            IList<string> wirePathTwo = new List<string> { "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83" };

            IDictionary<int, HashSet<int>> coordinates = cut.MapPoints(wirePathOne);
            IList<Point> intersectionPoints = cut.LocateIntersectionPoints(coordinates, wirePathTwo);
            int closestDistance = cut.ClosestManhattanDistance(intersectionPoints);

            Assert.AreEqual(159, closestDistance);
        }

        [Test]
        public void WireManagerIntegrationTestTwo_TwoWirePaths_ReturnsClosestDistance()
        {
            IList<string> wirePathOne = new List<string> { "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51" };
            IList<string> wirePathTwo = new List<string> { "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7" };

            IDictionary<int, HashSet<int>> coordinates = cut.MapPoints(wirePathOne);
            IList<Point> intersectionPoints = cut.LocateIntersectionPoints(coordinates, wirePathTwo);
            int closestDistance = cut.ClosestManhattanDistance(intersectionPoints);

            Assert.AreEqual(135, closestDistance);
        }

        [Test]
        public void WireManagerIntegrationTestThree_TwoWirePaths_ReturnsFewestSteps()
        {
            IList<string> wirePathOne = new List<string> { "R75", "D30", "R83", "U83", "L12", "D49", "R71", "U7", "L72" };
            IList<string> wirePathTwo = new List<string> { "U62", "R66", "U55", "R34", "D71", "R55", "D58", "R83" };

            IDictionary<int, HashSet<int>> coordinates = cut.MapPoints(wirePathOne);
            IList<Point> intersectionPoints = cut.LocateIntersectionPoints(coordinates, wirePathTwo);
            cut.SetFirstWireStepsToIntersectionPoints(intersectionPoints, wirePathOne);
            int fewestSteps = cut.FewestTotalSteps(intersectionPoints);

            Assert.AreEqual(610, fewestSteps);
        }

        [Test]
        public void WireManagerIntegrationTestFour_TwoWirePaths_ReturnsFewestSteps()
        {
            IList<string> wirePathOne = new List<string> { "R98", "U47", "R26", "D63", "R33", "U87", "L62", "D20", "R33", "U53", "R51" };
            IList<string> wirePathTwo = new List<string> { "U98", "R91", "D20", "R16", "D67", "R40", "U7", "R15", "U6", "R7" };

            IDictionary<int, HashSet<int>> coordinates = cut.MapPoints(wirePathOne);
            IList<Point> intersectionPoints = cut.LocateIntersectionPoints(coordinates, wirePathTwo);
            cut.SetFirstWireStepsToIntersectionPoints(intersectionPoints, wirePathOne);
            int fewestSteps = cut.FewestTotalSteps(intersectionPoints);

            Assert.AreEqual(410, fewestSteps);
        }

        private bool CheckCoordinateEquality(IDictionary<int, HashSet<int>> coordinatesOne, IDictionary<int, HashSet<int>> coordinatesTwo)
        {
            IEnumerable<int> keys = coordinatesOne.Keys;
            foreach(int key in keys)
            {
                HashSet<int> valuesOne = coordinatesOne[key];
                HashSet<int> valuesTwo = coordinatesTwo[key];

                foreach(int value in valuesOne)
                {
                    if (!valuesTwo.Contains(value))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
