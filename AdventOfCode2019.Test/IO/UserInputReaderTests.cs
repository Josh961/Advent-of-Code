using AdventOfCode2019.IO;
using Moq;
using NUnit.Framework;

namespace AdventOfCode2019.Test.IO
{
    [TestFixture]
    public class UserInputReaderTests
    {
        [Test]
        public void GetNumericInputInclusive_ValidInput_ReturnsInput()
        {
            Mock<IOutputWriter> mockOutputWriter = new Mock<IOutputWriter>();
            Mock<IInputReader> mockInputReader = new Mock<IInputReader>();
            mockInputReader.Setup(m => m.ReadLine()).Returns("1");
            UserInputReader cut = new UserInputReader(mockInputReader.Object, mockOutputWriter.Object);

            int input = cut.GetNumericInputInclusive(2);

            Assert.AreEqual(1, input);
        }

        [Test]
        public void GetNumericInputInclusive_UpperBoundInput_ReturnsInput()
        {
            Mock<IOutputWriter> mockOutputWriter = new Mock<IOutputWriter>();
            Mock<IInputReader> mockInputReader = new Mock<IInputReader>();
            mockInputReader.Setup(m => m.ReadLine()).Returns("2");
            UserInputReader cut = new UserInputReader(mockInputReader.Object, mockOutputWriter.Object);

            int input = cut.GetNumericInputInclusive(2);

            Assert.AreEqual(2, input);
        }

        [Test]
        public void GetNumericInputInclusive_TwoAttempts_ReturnsSecondValidInput()
        {
            Mock<IOutputWriter> mockOutputWriter = new Mock<IOutputWriter>();
            Mock<IInputReader> mockInputReader = new Mock<IInputReader>();
            mockInputReader.SetupSequence(m => m.ReadLine())
                .Returns("3")
                .Returns("2");
            UserInputReader cut = new UserInputReader(mockInputReader.Object, mockOutputWriter.Object);

            int input = cut.GetNumericInputInclusive(2);

            Assert.AreEqual(2, input);
        }

        [Test]
        public void GetNumericInputInclusive_NegativeAttempt_ReturnsSecondValidInput()
        {
            Mock<IOutputWriter> mockOutputWriter = new Mock<IOutputWriter>();
            Mock<IInputReader> mockInputReader = new Mock<IInputReader>();
            mockInputReader.SetupSequence(m => m.ReadLine())
                .Returns("-3")
                .Returns("2");
            UserInputReader cut = new UserInputReader(mockInputReader.Object, mockOutputWriter.Object);

            int input = cut.GetNumericInputInclusive(2);

            Assert.AreEqual(2, input);
        }
    }
}
