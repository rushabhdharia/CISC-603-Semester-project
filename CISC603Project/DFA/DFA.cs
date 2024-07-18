// Author - Rushabh Dharia
// Python Code used as Reference - https://stackoverflow.com/a/53771902

namespace CISC603Project.DFA
{
    public class State(string value)
    {
        public string Value = value;

        public List<Link> Links = [];

        public void AddLink(Link link)
        {
            Links.Add(link);
        }
    }

    public class Link(State fromState, char inputAlphabet, State toState)
    {
        public State FromState = fromState;
        public char InputAlphabet = inputAlphabet;
        public State ToState = toState;

    }

    public class DFA(State initialState, List<State> internalStates, List<State> finalStates)
    {
        public State InitialState = initialState;

        public List<State> InternalStates = internalStates;

        public List<State> FinalStates = finalStates;

        private static State? GetNextState(State currentState, char inputAlphabet)
        {

            foreach (Link link in currentState.Links)
            {
                if (link.InputAlphabet == inputAlphabet)
                {
                    return link.ToState;
                }
            }

            return null;
        }

        public bool IsAccepting(String inputString)
        {
            State currentState = InitialState;
            for (int i = 0; i < inputString.Length; i++)
            {
                currentState = GetNextState(currentState, inputString[i]);
                if (currentState == null)
                {
                    return false;
                }
            }
            return FinalStates.Contains(currentState);
        }
    }
}
