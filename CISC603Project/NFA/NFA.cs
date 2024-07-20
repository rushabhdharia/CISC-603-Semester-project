//Author - Rushabh Dharia

namespace CISC603Project.NFA
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
            if (int.TryParse(inputString[0].ToString(), out _)|| inputString[0] == '.')
            {
                inputString = "l" + inputString;
            }
            for (int i = 0; i < inputString.Length; i++)
            {
                var inputCharacter = inputString[i];
                if (int.TryParse(inputCharacter.ToString(), out _))
                {
                    inputCharacter = 'n';
                }

                currentState = GetNextState(currentState, inputCharacter);
                if (currentState == null)
                {
                    return false;
                }
            }
            return FinalStates.Contains(currentState);
        }
    }

    public class NFA
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
            internalStates.Add(q3);

            List<State> finalStates = new List<State>();
            finalStates.Add(q4);

            //Links
            Link link01plus = new Link(initialState, '+', q1);
            Link link01minus = new Link(initialState, '-', q1);
            Link link01lambda = new Link(initialState, 'l', q1); // l represents lambda 
            Link link11 = new Link(q1, 'n', q1); //n represents number
            Link link12 = new Link(q1, '.', q2); //. represents decimal
            Link link23 = new Link(q2, 'n', q3);
            Link link34 = new Link(q3, 'n', q4);
            Link link44 = new Link(q4, 'n', q4);

            initialState.Links.Add(link01plus);
            initialState.Links.Add(link01minus);
            initialState.Links.Add(link01lambda);
            q1.Links.Add(link11);
            q1.Links.Add(link12);
            q2.Links.Add(link23);
            q3.Links.Add(link34);
            q4.Links.Add(link44);

            //DFA
            automata = new Automata(initialState, internalStates, finalStates);

            return automata;
        }


    }
}
