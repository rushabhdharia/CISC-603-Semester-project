//Author - Rushabh Dharia

using FluentAssertions;
using Xunit;

namespace CISC603Project.PDA
{
    public class PDATests
    {
        //Arrange
        private readonly Automata automata;

        public PDATests()
        {
            var pda = new PDA();
            automata = pda.GetAutomata();
        }

        [Fact]
        public void Test1Accepting()
        {
            //Act
            var result = automata.IsAccepting("aab");

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Test2Accepting()
        {
            //Act
            var result = automata.IsAccepting("aaaabb");

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Test3Accepting()
        {
            //Act
            var result = automata.IsAccepting("aaaaaabbb");

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public void Test1NotAccepting()
        {
            //Act
            var result = automata.IsAccepting("ab");

            //Assert
            result.Should().NotBe(true);
        }
        [Fact]
        public void Test2NotAccepting()
        {
            var result = automata.IsAccepting("aabbb");

            //Assert
            result.Should().NotBe(true);
        }
        [Fact]
        public void Test3NotAccepting()
        {
            //Act
            var result = automata.IsAccepting("aaaaaabb");

            //Assert
            result.Should().NotBe(true);
        }
    }
}
