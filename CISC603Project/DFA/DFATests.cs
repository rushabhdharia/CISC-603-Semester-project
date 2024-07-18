using FluentAssertions;
using Xunit;

namespace CISC603Project.DFA
{
    public class DFATests
    {
        private DFA? dFA;

        private DFA getDFA()
        {
            if (dFA != null)
            {
                return dFA;
            }
            //States
            State initialState = new State("q0");
            State q1 = new State("q1");
            State q2 = new State("q2");
            State q3 = new State("q3");
            State q4 = new State("q4");

            List<State> internalStates = new List<State>();
            internalStates.Add(q1);
            internalStates.Add(q2);
            internalStates.Add(q4);

            List<State> finalStates = new List<State>();
            finalStates.Add(q3);

            //Links
            Link link01 = new Link(initialState, 'a', q1);
            Link link02 = new Link(initialState, 'b', q2);
            Link link13 = new Link(q1, 'b', q3);
            Link link23 = new Link(q2, 'a', q3);
            Link link34 = new Link(q3, 'c', q4);
            Link link43 = new Link(q4, 'c', q3);

            initialState.Links.Add(link01);
            initialState.Links.Add(link02);
            q1.Links.Add(link13);
            q2.Links.Add(link23);
            q3.Links.Add(link34);
            q4.Links.Add(link43);

            //DFA
            dFA = new DFA(initialState, internalStates, finalStates);

            return dFA;
        }

        [Fact]
        public void Test1Accepting()
        {
            //Arrange
            var DFA = getDFA();

            //Act
           var result = DFA.IsAccepting("bacc");

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Test2Accepting()
        {
            //Arrange
            var DFA = getDFA();

            //Act
            var result = DFA.IsAccepting("abcc");

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Test3Accepting()
        {
            //Arrange
            var DFA = getDFA();

            //Act
            var result = DFA.IsAccepting("bacccc");

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public void Test1NotAccepting()
        {
            //Arrange
            var DFA = getDFA();

            //Act
            var result = DFA.IsAccepting("cab");

            //Assert
            result.Should().NotBe(true);
        }
        [Fact]
        public void Test2NotAccepting()
        {
            //Arrange
            var DFA = getDFA();

            //Act
            var result = DFA.IsAccepting("cba");

            //Assert
            result.Should().NotBe(true);
        }
        [Fact]
        public void Test3NotAccepting()
        {
            //Arrange
            var DFA = getDFA();

            //Act
            var result = DFA.IsAccepting("abca");

            //Assert
            result.Should().NotBe(true);
        }

    }
}
