//Author - Rushabh Dharia

namespace CISC603Project
{
    internal class Driver
    {
        private static void UseDFA()
        {
            Console.WriteLine("Enter a string to test DFA.");
            var inputString = Console.ReadLine();

            if(inputString == null)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            DFA.DFA dfa = new DFA.DFA();
            var automata = dfa.GetAutomata();

            if(automata.IsAccepting(inputString))
            {
                Console.WriteLine("Input Accepted by DFA");
            }
            else
            {
                Console.WriteLine("Input Not Accepted by DFA");
            }

        }

        private static void UseNFA()
        {
            Console.WriteLine("Enter a string to test NFA.");
            var inputString = Console.ReadLine();

            if (inputString == null)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            NFA.NFA nfa = new NFA.NFA();
            var automata = nfa.GetAutomata();

            if (automata.IsAccepting(inputString))
            {
                Console.WriteLine("Input Accepted by NFA");
            }
            else
            {
                Console.WriteLine("Input Not Accepted by NFA");
            }
        }

        private static void UsePDA()
        {
            Console.WriteLine("Enter a string to test PDA.");
            var inputString = Console.ReadLine();

            if (inputString == null)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            PDA.PDA pda = new PDA.PDA();
            var automata = pda.GetAutomata();

            if (automata.IsAccepting(inputString))
            {
                Console.WriteLine("Input Accepted by PDA");
            }
            else
            {
                Console.WriteLine("Input Not Accepted by PDA");
            }
        }

        static void Main()
        {
            string userInput = "";
            while(true)
            {
                Console.WriteLine("Enter 1 for DFA \nEnter 2 for NFA\nEnter 3 for PDA\nEnter 4 to Exit");
                userInput = Console.ReadLine();

                if (userInput.Equals("1"))
                {
                    UseDFA();
                }
                else if (userInput.Equals("2"))
                {
                    UseNFA();
                }
                else if (userInput.Equals("3"))
                {
                    UsePDA();
                }
                else if (userInput.Equals("4"))
                {
                    break;
                }
                else { 
                    Console.WriteLine("Invalid Input"); 
                }

            } 
            return;
        }
    }
}
