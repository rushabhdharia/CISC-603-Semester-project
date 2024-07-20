## How to compile and run the code
1. Install Visual Studio Community Edition 2022 and .NET 8 SDK
2. Open Visual Studio
3. Click on 'Open a Project or solution'
4. Navigate to the 'CISC-603-Semester-Project' folder
5. Select the 'CISC 603 Semester Project.sln' and click on 'Open'
6. Click on the run arrow to Build and Run the solution
7. A console will pop up and you will be able to select DFA, NFA, and/or PDA implementation and test the appropriate input strings

## Testing the Automata
1. You can also modify or add your own unit tests in the following files - DFATests.cs, NFATests.cs, and PDATests.cs.
2. Then on the MenuBar, navigate to Test, and select 'Run all Tests'
3. The TestExplorer will pop up displaying all the test results.

### References
1. Python code used for reference - https://stackoverflow.com/a/53771902

### Top-level Nuget packages used for testing 
1. FluentAssertions
2. Microsoft.NET.Test.Sdk
3. xunit
4. xunit.runner.visualstudio



## Future Improvements
1. Add verbose mode to show state transitions
2. Allow user to edit a json file to dynamically build automata  
e.g.  
[  
    {  
        "DFA": {  
            "InternalStates": [ "q1",  "q2",  "q4"],  
            "InputAlphabets": ["a", "b", "c"],  
            "Transitions": [["fromState","inputAlphabet","toState"], ["fromState","inputAlphabet","toState"], ...],  
            "InitialState": "q0",  
            "FinalStates": ["q3"]  
        },  
        "NFA": {  
            "InternalStates": ["q1",  "q2",  "q3"],  
            "InputAlphabets": ["+", "-", "lambda", "0", "1",  .., "9"],  
            "Transitions": [["fromState","inputAlphabet","toState"], ["fromState","inputAlphabet","toState"], ...],  
            "InitialState": "q0",  
            "FinalStates": ["q4"]  
        },  
        "PDA": {  
            "InternalStates": ["q1", "q2"],  
            "InputAlphabets": ["a", "b", "lambda"],  
            "StackAlphabets": ["a", "b"],  
            "Transitions": [["fromState","inputAlphabet", "stackTop", "replacementString" ,"toState"], ["fromState","inputAlphabet", "stackTop", "replacementString" ,"toState"], ..],  
            "InitialState": "q0",  
            "StackStartSymbol": "z",  
            "FinalStates": ["q3"]  
        }  
    }  
]

