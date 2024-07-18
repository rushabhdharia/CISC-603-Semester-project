using FluentAssertions;
using Xunit;

namespace CISC603Project.DFA
{
    public class DFATests
    {
        //Arrange
        private readonly Automata automata;

        public DFATests()
        {
            var DFA = new DFA();
            automata = DFA.GetAutomata();
        }


        [Fact]
        public void Test1Accepting()
        {
            //Act
           var result = automata.IsAccepting("bacc");

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Test2Accepting()
        {
            //Act
            var result = automata.IsAccepting("abcc");

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Test3Accepting()
        {
            //Act
            var result = automata.IsAccepting("bacccc");

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public void Test1NotAccepting()
        {
            //Act
            var result = automata.IsAccepting("cab");

            //Assert
            result.Should().NotBe(true);
        }
        [Fact]
        public void Test2NotAccepting()
        {
            var result = automata.IsAccepting("cba");

            //Assert
            result.Should().NotBe(true);
        }
        [Fact]
        public void Test3NotAccepting()
        {
            //Act
            var result = automata.IsAccepting("abca");

            //Assert
            result.Should().NotBe(true);
        }

    }
}
