//Author - Rushabh Dharia

namespace CISC603Project.PDA
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

    public class Link(State fromState, char inputAlphabet, char stackTop, string replaceString ,State toState)
    {
        public State FromState = fromState;
        public char InputAlphabet = inputAlphabet;
        public char StackTop = stackTop;
        public string ReplaceString = replaceString;
        public State ToState = toState;

    }

    public class Automata(State initialState, List<State> internalStates, List<State> finalStates)
    {
        public State InitialState = initialState;

        public List<State> InternalStates = internalStates;

        public List<State> FinalStates = finalStates;

        public Stack<char> stack = new();

        private State? GetNextState(State currentState, char inputAlphabet)
        {

            foreach (Link link in currentState.Links)
            {
                if (link.InputAlphabet == inputAlphabet && stack.Count > 0 && link.StackTop == stack.Peek())
                {
                    stack.Pop();

                    if(!link.ReplaceString.Equals("l"))
                    {
                        for (int i = link.ReplaceString.Length - 1; i >= 0; i--)
                        {
                            stack.Push(link.ReplaceString[i]);
                        }
                    }

                    return link.ToState;
                }
            }

            return null;
        }

        public bool IsAccepting(String inputString)
        {
            State currentState = InitialState;
            inputString = inputString + 'l';
            
            for (int i = 0; i < inputString.Length; i++)
            {
                var inputCharacter = inputString[i];                

                currentState = GetNextState(currentState, inputCharacter);
                if (currentState == null)
                {
                    return false;
                }
            }

            return FinalStates.Contains(currentState) && stack.Count == 1 && stack.Peek() == 'z';
        }
    }

    public class PDA
    {
        private Automata? automata;

        public Automata GetAutomata()
        {
            if(automata != null)
            {
                return automata;

            }
            //States
            State initialState = new State("q0");
            State q1 = new State("q1");
            State q2 = new State("q2");
            State q3 = new State("q3");

            //Internal States
            List<State> internalStates = [q1, q2];

            //Final States
            List<State> finalStates = [q3];

            //Links
            Link l01z = new Link(initialState, 'a', 'z', "az", q1);
            Link l01a = new Link(initialState, 'a', 'a', "aa", q1);
            Link l10 = new Link(q1, 'a', 'a', "a", initialState);
            Link l02 = new Link(initialState, 'b', 'a', "l", q2);
            Link l22 = new Link(q2, 'b', 'a', "l", q2);
            Link l23 = new Link(q2, 'l', 'z', "z", q3);

            //Add Links
            initialState.Links.Add(l01z);
            initialState.Links.Add(l01a);
            q1.Links.Add(l10);
            initialState.Links.Add(l02);
            q2.Links.Add(l22);
            q2.Links.Add(l23);


            //Automata
            automata = new Automata(initialState, internalStates, finalStates);
            
            //initialize stack
            automata.stack.Push('z');

            return automata;
        }
    }
}