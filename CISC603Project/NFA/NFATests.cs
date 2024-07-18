using FluentAssertions;
using Xunit;

namespace CISC603Project.NFA
{
    public class NFATests
    {
        //Arrange
        private readonly Automata automata;

        public NFATests()
        {
            var NFA = new NFA();
            automata = NFA.GetAutomata();
        }

        [Fact]
        public void Test1Accepting()
        {
            //Act
            var result = automata.IsAccepting("+10.01");

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Test2Accepting()
        {
            //Act
            var result = automata.IsAccepting("-133.031");

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Test3Accepting()
        {
            //Act
            var result = automata.IsAccepting("0.0111");

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public void Test1NotAccepting()
        {
            //Act
            var result = automata.IsAccepting("1.1");

            //Assert
            result.Should().NotBe(true);
        }
        [Fact]
        public void Test2NotAccepting()
        {
            var result = automata.IsAccepting("+2");

            //Assert
            result.Should().NotBe(true);
        }
        [Fact]
        public void Test3NotAccepting()
        {
            //Act
            var result = automata.IsAccepting("-400");

            //Assert
            result.Should().NotBe(true);
        }
    }
}
