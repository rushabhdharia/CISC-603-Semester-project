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

    public class Automata(State initialState, List<State> internalStates, List<State> finalStates)
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

    public class DFA
    {
        private Automata? automata;

        public Automata GetAutomata()
        {
            if (automata != null)
            {
                return automata;
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
            automata = new Automata(initialState, internalStates, finalStates);

            return automata;
        }
    }
}
