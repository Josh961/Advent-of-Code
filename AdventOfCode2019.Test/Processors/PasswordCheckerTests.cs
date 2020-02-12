using AdventOfCode2019.Processors;
using NUnit.Framework;

namespace AdventOfCode2019.Test.Processors
{
    [TestFixture]
    public class PasswordCheckerTests
    {
        private PasswordChecker cut;

        [SetUp]
        public void Setup()
        {
            cut = new PasswordChecker();
        }

        [TestCase(112233, ExpectedResult = true)]
        [TestCase(111122, ExpectedResult = true)]
        [TestCase(1233, ExpectedResult = true)]
        [TestCase(11, ExpectedResult = true)]
        public bool CheckPassword_ValidInput_ReturnsTrue(int number)
        {
            return cut.CheckPassword(number);
        }

        [TestCase(1234567, ExpectedResult = false)]
        [TestCase(123789, ExpectedResult = false)]
        [TestCase(1, ExpectedResult = false)]
        public bool CheckPassword_NoAdjacentDigits_ReturnsFalse(int number)
        {
            return cut.CheckPassword(number);
        }

        [TestCase(123444, ExpectedResult = false)]
        [TestCase(111111, ExpectedResult = false)]
        public bool CheckPassword_TooManyAdjacentDigits_ReturnsFalse(int number)
        {
            return cut.CheckPassword(number);
        }

        [TestCase(223450, ExpectedResult = false)]
        [TestCase(123445676, ExpectedResult = false)]
        [TestCase(12145677, ExpectedResult = false)]
        public bool CheckPassword_DecreasingDigits_ReturnsFalse(int number)
        {
            return cut.CheckPassword(number);
        }

        [TestCase(7, ExpectedResult = false)]
        public bool CheckPassword_LengthOfOne_ReturnsFalse(int number)
        {
            return cut.CheckPassword(number);
        }
    }
}
