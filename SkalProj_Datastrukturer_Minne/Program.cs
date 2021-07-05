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
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
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

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
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


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
 //           string popped;
            char tecken, nav = ' ';
            Par_pos item = new Par_pos();
            Stack<Par_pos> stack = new Stack<Par_pos>();
            do
            {
                string input = Console.ReadLine();
                nav = input[0];
                string value = input[1..];
                

                switch (nav)
                {
                    case '+':
                        for (int i = 0; i < value.Length; i++)
                        {
                            tecken = (char)value[i];
                            if (tecken == '(' || tecken == '{' || tecken == '[')
                            {
                                item.Par = (char)value[i];
                                item.Pos = i;
                                stack.Push(item);
                            }
                            else if (tecken == ')' || tecken == '}' || tecken == ']')
                            {
                                if (stack.Count == 0 || !stack.TryPop(out item))
                                {
                                    Console.WriteLine("The stack is empty -> nothing to pop");
                                }
                                else
                                {
                                    foreach (Par_pos obj in stack)
                                        Console.Write("    {0}    {1}", obj.Pos, obj.Par);
                                    Console.WriteLine();

                                    switch (item.Par)
                                    {
                                        case '(':
                                            if (tecken != ')') Console.WriteLine("Error! ) expected to match ( at pos {0}", item.Pos);
                                            else
                                            {
                                                Console.WriteLine("pos {0} matching {1} at pos {2}", i, item.Par, item.Pos);
                                            }

                                            //                                           else Writelog(i);
                                            break;
                                        case '{':
                                            if (tecken != '}') Console.WriteLine("Error! } expected to match { at pos { 0}", item.Pos);
                                            else
                                            {
                                                Console.WriteLine("pos {0} matching {1} at pos {2}", i, item.Par, item.Pos);
                                            }
 //                                           Writelog(i, item);
                                            break;
                                        case '[':
                                            if (tecken != ']') Console.WriteLine("Error! ] expected to match [ at pos { 0}", item.Pos);                                           Console.WriteLine("pos {0} matching {1} at pos {2}", i, item.Par, item.Pos);
 //                                           else
 //                                           {
  //                                              Console.WriteLine("pos {0} matching {1} at pos {2}", i, item.Par, item.Pos);
   //                                         }


                                            //                                           else Par_pos.Writelog(i, item);

                                            break;

                                        default:

                                            Console.WriteLine(" Error should not enter this default statement!");
                                            foreach (Par_pos obj in stack)
                                                Console.Write("    {0}    {1}", obj.Pos, obj.Par);
                                            Console.WriteLine();
                                            stack.Clear();
                                            break;
                                    }


                                }
                            }
                        }
                        break;

                    case '-':
                        break;

                    case 'q':
                        if (stack.Count != 0)
                        {
                            foreach (Par_pos obj in stack)
                                Console.Write("    {0}    {1}", obj.Pos, obj.Par);
                            Console.WriteLine();
                            stack.Clear();
                        }
                        return;
                        break;
                    default:
                        //Console.WriteLine("Unknown command " + nav.ToString + " please enter '+','-' or 'q' at beginning of line");
                        Console.WriteLine("Unknown command please enter '+','-' or 'q' at beginning of line");
                        break;
                }
            } while (nav != 'q');
            /*                if (inputLineCount % 5 == 0)
                            {
                                listCap = theList.Capacity;
                                Console.WriteLine("Capacity = {0} No of added = {1} No of deleted = {2}", listCap, noAdd, noDel);
                                Console.WriteLine("Capacity = {0} ", listCap);
                                Console.WriteLine($"listlength = {theList.Count}");
                            } */
        }

        static void CheckParenthesis2()
        {
            bool isCorrect = true;

            Console.WriteLine("Please enter a string: ");
            string input = Console.ReadLine();

            var stack = new Stack<char>();

            foreach (var letter in input)
            {
                if (letter == '(' || letter == '{' || letter == '[')
                {
                    stack.Push(letter);
                }

                else if (letter == ')' || letter == '}' || letter == ']')
                {
                    //if (stack.Count == 0 || stack.Pop() != "motsatta tecknet" )
                    //{
                    //    isCorrect = false;
                    //    break;
                    //}
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

    }



    public class Par_pos
    {
        public int Pos = 0;
        public char Par = '\0';

//        public static void Writelog(int i)
//       {
//            Console.WriteLine("pos {0} matching {1} at pos {2}", i, Par, Pos);
//        }
    }
}
    //
    /*public class PushnPop
    {
        private string str;
        private int index;

        public int Push(char ch)
        {
            // str += ToString(ch);
            str = str + ch;
            Console.WriteLine(str);
            return index++;
        }
        //   public int Push(int ipos, char ch)

    /*    public char Pop() {
            char ch str.this[--index];
            return ch; 
        } */

    /*  public void StackTest()
      {
          var stack = new Stack<string>();
          stack.Push("Hej");
          stack.Push("jag");
          stack.Pop();



      }*/


