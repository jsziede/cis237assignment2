//Joshua Sziede

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//it seemed like it would be a lot easier to write and manage this code if I added a UI class
namespace cis237assignment2
{
    class UI
    {
        char[,] maze = null;

        public char[,] Maze
        {
            get { return maze; }
            set { maze = value; }
        }

        public UI(char[,] maze)
        {
            this.maze = maze;
        }

        public UI()
        { }

        public int MazePrompt()
        {
            this.printMazePrompt();
            string promptResponse = Console.ReadLine();                                                                 //program records the user's response to the promptResponse string
            while (promptResponse != "1" && promptResponse != "2" &&
                promptResponse != "3" && promptResponse != "4"
                && promptResponse != "5")                                                                               //runs while the user continues to provide an invalid response
            {
                Console.WriteLine("Error. Please select a valid number." + Environment.NewLine);                        //user is told that their response was invalid
                this.printMazePrompt();                                                                                 //user is listed the options once again
                promptResponse = Console.ReadLine();                                                                    //program records the user's response again
            }
            return Int32.Parse(promptResponse);                                                                         //returns any valid response from the user
        }


        public void MazeSteps()
        {
            Console.WriteLine("Press Enter to see the next step.");
            Console.ReadLine();
        }

        public void Solved()
        {
            Console.WriteLine("The maze has been solved." + Environment.NewLine + "Press Enter to close.");
            Console.ReadLine();
        }

        public void NotSolved()
        {
            Console.WriteLine("Error: No solution found." + Environment.NewLine + "Press Enter to close.");
            Console.ReadLine();
        }

        public void PrintMaze(char[,] maze) //a near-identical method can be found in Program.cs with an explanation of the steps
        {
            int a = 0;
            int b = 0;
            while (a <= 11)
            {
                while (b <= 11)
                {
                    Console.Write(maze[a, b]);
                    b++;
                }
                Console.WriteLine();    ///this writeline prevents the entire maze from being on the same line
                                        ///a new line is created after every twelve chars are printed
                a++;
                b = 0;
            }
            Console.WriteLine();        //this writeline occurs only once after the entire maze is printed
        }

        private void printMazePrompt()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. View Maze");
            Console.WriteLine("2. Solve Maze");
            Console.WriteLine("3. View Transposed Maze");
            Console.WriteLine("4. Solve Transposed Maze");
            Console.WriteLine("5. Exit");
        }
    }
}
