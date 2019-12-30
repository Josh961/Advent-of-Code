using AdventOfCode2019.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Processors
{
    public class WireManager
    {
        public IDictionary<int, HashSet<int>> MapPoints(IList<string> wirePath)
        {
            IDictionary<int, HashSet<int>> coordinates = new Dictionary<int, HashSet<int>>();

            int x = 0;
            int y = 0;
            foreach (string instruction in wirePath)
            {
                string direction = instruction.Substring(0, 1);
                int distance = int.Parse(instruction.Substring(1));

                switch (direction)
                {
                    case "U":
                        for (int i = 0; i < distance; i++)
                        {
                            y += 1;
                            AddCoordinate(coordinates, x, y);
                        }
                        break;
                    case "R":
                        for (int i = 0; i < distance; i++)
                        {
                            x += 1;
                            AddCoordinate(coordinates, x, y);
                        }
                        break;
                    case "D":
                        for (int i = 0; i < distance; i++)
                        {
                            y += -1;
                            AddCoordinate(coordinates, x, y);
                        }
                        break;
                    case "L":
                        for (int i = 0; i < distance; i++)
                        {
                            x += -1;
                            AddCoordinate(coordinates, x, y);
                        }
                        break;
                }
            }

            return coordinates;
        }


        private void AddCoordinate(IDictionary<int, HashSet<int>> coordinates, int x, int y)
        {
            if (!coordinates.ContainsKey(x))
            {
                coordinates.Add(x, new HashSet<int> { y });
            }
            else
            {
                coordinates[x].Add(y);
            }
        }

        public IList<Point> LocateIntersectionPoints(IDictionary<int, HashSet<int>> coordinates, IList<string> wirePath)
        {
            IList<Point> intersectionPoints = new List<Point>();

            int steps = 0;
            int x = 0;
            int y = 0;
            foreach (string instruction in wirePath)
            {
                string direction = instruction.Substring(0, 1);
                int distance = int.Parse(instruction.Substring(1));

                switch (direction)
                {
                    case "U":
                        for (int i = 0; i < distance; i++)
                        {
                            y += 1;
                            PushToListIfIntersectionPoint(intersectionPoints, coordinates, x, y, ++steps);
                        }
                        break;
                    case "R":
                        for (int i = 0; i < distance; i++)
                        {
                            x += 1;
                            PushToListIfIntersectionPoint(intersectionPoints, coordinates, x, y, ++steps);
                        }
                        break;
                    case "D":
                        for (int i = 0; i < distance; i++)
                        {
                            y += -1;
                            PushToListIfIntersectionPoint(intersectionPoints, coordinates, x, y, ++steps);
                        }
                        break;
                    case "L":
                        for (int i = 0; i < distance; i++)
                        {
                            x += -1;
                            PushToListIfIntersectionPoint(intersectionPoints, coordinates, x, y, ++steps);
                        }
                        break;
                }
            }


            return intersectionPoints;
        }

        private void PushToListIfIntersectionPoint(IList<Point> intersectionPoints, IDictionary<int, HashSet<int>> coordinates, int x, int y, int steps)
        {
            if (coordinates.ContainsKey(x) && coordinates[x].Contains(y))
            {
                intersectionPoints.Add(new Point(x, y, steps));
            }
        }

        public void SetFirstWireStepsToIntersectionPoints(IList<Point> intersectionPoints, IList<string> wirePath)
        {
            int steps = 0;
            int x = 0;
            int y = 0;
            foreach (string instruction in wirePath)
            {
                string direction = instruction.Substring(0, 1);
                int distance = int.Parse(instruction.Substring(1));

                switch (direction)
                {
                    case "U":
                        for (int i = 0; i < distance; i++)
                        {
                            y += 1;
                            SetStepsIfIntersectionPoint(intersectionPoints, x, y, ++steps);
                        }
                        break;
                    case "R":
                        for (int i = 0; i < distance; i++)
                        {
                            x += 1;
                            SetStepsIfIntersectionPoint(intersectionPoints, x, y, ++steps);
                        }
                        break;
                    case "D":
                        for (int i = 0; i < distance; i++)
                        {
                            y += -1;
                            SetStepsIfIntersectionPoint(intersectionPoints, x, y, ++steps);
                        }
                        break;
                    case "L":
                        for (int i = 0; i < distance; i++)
                        {
                            x += -1;
                            SetStepsIfIntersectionPoint(intersectionPoints, x, y, ++steps);
                        }
                        break;
                }
            }
        }

        private void SetStepsIfIntersectionPoint(IList<Point> intersectionPoints, int x, int y, int steps)
        {
            Point p = intersectionPoints.FirstOrDefault(p => p.X == x && p.Y == y);
            if (p != null)
            {
                p.FirstWireSteps = steps;
            }
        }

        public int ClosestManhattanDistance(IList<Point> intersectionPoints)
        {
            return intersectionPoints.Min(p => p.ManhattanDistance);
        }

        public int FewestTotalSteps(IList<Point> intersectionPoints)
        {
            return intersectionPoints.Min(p => p.TotalSteps);
        }
    }
}
