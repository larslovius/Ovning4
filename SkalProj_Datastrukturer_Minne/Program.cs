using System;
using System.Collections;
using System.Collections.Generic;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n5. Reverse text"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParenthesis2();
                        break;
                    case '5':
                        ReverseText();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /* Svar på fråor avs ExamineList:
             * 2-4 Listan kapacitet: verkar som capaciten fördubblas när den behöver ökas vilket verkar rimligt för en växande list
             * 5 Kapaciten minskar ej när element tas bort - ombesörjs av garbage collection när programmet kört färdigt
             * 6 Kan tänkbora mig att arrayer kräver mindre overhead än listor och att det då går att göra t ex beräkning snabbare
             * Om man definierar en array i en metod där elementen används för beräkningar av ett resultat och elementen sedan inte
             * används av anroparen kan jag tänka mig att det minnet kan frigörass sedan
             * 
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working
             * 
             * Lagt till ett val "q" för att hoppa ur examine list. Vore bättre med en specialtangent som ESC eller ngt ctrl tecken
            */

            List<string> theList = new List<string>();
            char nav = ' ';
            int inputLineCount = 0;
            int listCap, noDel = 0;
            int noAdd = 0;
            do
            {
                string input = Console.ReadLine();
                nav = input[0];
                string value = input[1..];

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        inputLineCount++;
                        noAdd++;
                        break;
                    case '-':
                        bool fanns = theList.Remove(value);
                        if (!fanns)
                        {
                            Console.WriteLine("Cannot find item to remove " + value + " please reenteer command");
                        }
                        else
                        {
                            inputLineCount++;
                            noDel++;
                        }
                        break;
                    case 'q':
                        return;
                        break;
                    default:
                        //Console.WriteLine("Unknown command " + nav.ToString + " please enter '+','-' or 'q' at beginning of line");
                        Console.WriteLine("Unknown command please enter '+','-' or 'q' at beginning of line");
                        break;
                }
                if (inputLineCount % 5 == 0)
                {
                    listCap = theList.Capacity;
                    Console.WriteLine("Capacity = {0} No of added = {1} No of deleted = {2}", listCap, noAdd, noDel);
                    Console.WriteLine("Capacity = {0} ", listCap);
                    Console.WriteLine($"listlength = {theList.Count}");
                }
            }
            while (nav != 'q');

        }


        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueue = new Queue<string>();
            char nav = ' ';
            /*           int inputLineCount = 0;
                       int listCap, noDel = 0;
                       int noAdd = 0;
            */
            do
            {
                string input = Console.ReadLine();
                nav = input[0];
                string value = input[1..];
                string dequed = null;

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        break;
                    case '-':
                        dequed = theQueue.Dequeue();
                        if (dequed is null)
                        {
                            Console.WriteLine("The queue is empty -> nothing can be removed");
                        }
                        else
                        {
                            Console.WriteLine("Removed from the queue: " + dequed);
                            dequed = null;
                        }
                        break;
                    case 'q':
                        if (theQueue.Count != 0)
                        {
                            foreach (Object obj in theQueue)
                                Console.Write("    {0}", obj);
                            Console.WriteLine();
                            theQueue.Clear();
                        }
                        return;
                        break;
                    default:
                        //Console.WriteLine("Unknown command " + nav.ToString + " please enter '+','-' or 'q' at beginning of line");
                        Console.WriteLine("Unknown command please enter '+','-' or 'q' at beginning of line");
                        break;
                }
                /*
                                if (inputLineCount % 5 == 0)
                                {
                                    listCap = theList.Capacity;
                                    Console.WriteLine("Capacity = {0} No of added = {1} No of deleted = {2}", listCap, noAdd, noDel);
                                    Console.WriteLine("Capacity = {0} ", listCap);
                                    Console.WriteLine($"listlength = {theList.Count}");
                                }
                */
            }
            while (nav != 'q');
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /* Att anända en stack för simulera en kö på Ica vore som att be de köande ställa sig i kö ett hörn och sedan 
             * vinka in dem till kassa med den siste först vilket nog inte skulle ses med blida ögon...
             * 
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Stack<String> theStack = new Stack<string>();
            char nav = ' ';
            string popped;
            /*
                        var stack = new Stack<string>();
                        stack.Push("Hej");
                        stack.Push("jag");
                        stack.Pop();

            */
            do
            {
                string input = Console.ReadLine();
                nav = input[0];
                string value = input[1..];


                switch (nav)
                {
                    case '+':
                        theStack.Push(value);
                        break;
                    case '-':


                        if (!theStack.TryPop(out popped))
                        {
                            Console.WriteLine("The stack is empty -> nothing to pop");
                        }
                        else
                        {
                            Console.WriteLine("Popped from the stack: " + popped);

                        }
                        break;
                    case 'q':
                        if (theStack.Count != 0)
                        {
                            foreach (Object obj in theStack)
                                Console.Write("    {0}", obj);
                            Console.WriteLine();
                            theStack.Clear();
                        }
                        return;
                        break;
                    default:
                        //Console.WriteLine("Unknown command " + nav.ToString + " please enter '+','-' or 'q' at beginning of line");
                        Console.WriteLine("Unknown command please enter '+','-' or 'q' at beginning of line");
                        break;
                }
                /*                if (inputLineCount % 5 == 0)
                                {
                                    listCap = theList.Capacity;
                                    Console.WriteLine("Capacity = {0} No of added = {1} No of deleted = {2}", listCap, noAdd, noDel);
                                    Console.WriteLine("Capacity = {0} ", listCap);
                                    Console.WriteLine($"listlength = {theList.Count}");
                                } */
            }
            while (nav != 'q');
        }

        static void CheckParenthesis2()
        {
            bool isCorrect = true;

            static char lpar(char letter)
            {
                if (letter == ')') return '(';
                if (letter == '}') return '{';
                if (letter == ']') return '[';
                Console.WriteLine("Jävulen; letter is {0} ",letter);
                return '\0';
            }    


            Console.WriteLine("Please enter a string: ");
            string input = Console.ReadLine();
            var stack = new Stack<char>();

            /*
            var leftpar = new Dictionary<char, char>(){
            {')' , '('},
            {'}' , '{'},
            {']' , '['}
            };
            */
             
            foreach (var letter in input)
            {
                if (letter == '(' || letter == '{' || letter == '[')
                {
                    stack.Push(letter);
                }

                else if (letter == ')' || letter == '}' || letter == ']')
                {
                    if (stack.Count == 0 || stack.Pop() != lpar(letter))
                    {
                        isCorrect = false;
                        break;
                    }
                }
            }

            if (!isCorrect || stack.Count > 0)
            {
                Console.WriteLine("NEJ!");
            }
            else
            {
                Console.WriteLine("JA!");
            }
        }

        static void ReverseText()
        {
         
            Console.WriteLine("Please enter a string: ");
            string input = Console.ReadLine();

            var stack = new Stack<char>();

            foreach (var letter in input)
                 stack.Push(letter);

            while (stack.Count > 0)
                Console.Write(stack.Pop());
            Console.WriteLine();
               
            }
        }

    }


   

