using AdventOfCode2019.IO;
using AdventOfCode2019.Models;
using AdventOfCode2019.Processors;
using AdventOfCode2019.Utilities;
using System.Collections.Generic;

namespace AdventOfCode2019.Systems
{
    public class FuelManager
    {

        private readonly WireManager wireManager;
        private readonly IOutputWriter outputWriter;

        public FuelManager(IOutputWriter outputWriter)
        {
            this.outputWriter = outputWriter;
            wireManager = new WireManager();
        }

        public void Initialize()
        {
            IList<string> wirePaths = FileUtil.ReadAllLines("day_3_wire_paths.txt");
            IList<string> wirePathOne = wirePaths[0].Split(",");
            IList<string> wirePathTwo = wirePaths[1].Split(",");

            IDictionary<int, HashSet<int>> coordinates = wireManager.MapPoints(wirePathOne);
            IList<Point> intersectionPoints = wireManager.LocateIntersectionPoints(coordinates, wirePathTwo);
            wireManager.SetFirstWireStepsToIntersectionPoints(intersectionPoints, wirePathOne);

            int closestDistance = wireManager.ClosestManhattanDistance(intersectionPoints);
            int fewestSteps = wireManager.FewestTotalSteps(intersectionPoints);

            WriteClosestDistanceAndFewestSteps(closestDistance, fewestSteps);
        }

        private void WriteClosestDistanceAndFewestSteps(int closestDistance, int fewestSteps)
        {
            outputWriter.WriteLine($"Manhattan distance from central port to closest intersection: {closestDistance}");
            outputWriter.WriteLine($"Fewest combined steps for wires to reach an intersection: {fewestSteps}");
        }
    }
}