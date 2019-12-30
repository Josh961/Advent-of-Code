using AdventOfCode2019.Processors;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2019.Test.Processors
{
    [TestFixture]
    public class IntcodeCPUTests
    {
        private IntcodeCPU cut;

        [SetUp]
        public void Setup()
        {
            cut = new IntcodeCPU();
        }

        [Test]
        public void ApplyOperations_IntegerValues_ReturnsModifiedArrayOne()
        {
            IList<int> initialMemory = new List<int> { 1, 0, 0, 0, 99 };
            IList<int> expectedMemory = new List<int> { 2, 0, 0, 0, 99 };

            IList<int> finalMemory = cut.ApplyOperations(initialMemory);

            Assert.AreEqual(expectedMemory, finalMemory);
        }

        [Test]
        public void ApplyOperations_IntegerValues_ReturnsModifiedArrayTwo()
        {
            IList<int> initialMemory = new List<int> { 2, 3, 0, 3, 99 };
            IList<int> expectedMemory = new List<int> { 2, 3, 0, 6, 99 };

            IList<int> finalMemory = cut.ApplyOperations(initialMemory);

            Assert.AreEqual(expectedMemory, finalMemory);
        }

        [Test]
        public void ApplyOperations_IntegerValues_ReturnsModifiedArrayThree()
        {
            IList<int> initialMemory = new List<int> { 2, 4, 4, 5, 99, 0 };
            IList<int> expectedMemory = new List<int> { 2, 4, 4, 5, 99, 9801 };

            IList<int> finalMemory = cut.ApplyOperations(initialMemory);

            Assert.AreEqual(expectedMemory, finalMemory);
        }

        [Test]
        public void ApplyOperations_IntegerValues_ReturnsModifiedArrayFour()
        {
            IList<int> initialMemory = new List<int> { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            IList<int> expectedMemory = new List<int> { 30, 1, 1, 4, 2, 5, 6, 0, 99 };

            IList<int> finalMemory = cut.ApplyOperations(initialMemory);

            Assert.AreEqual(expectedMemory, finalMemory);
        }
    }
}
