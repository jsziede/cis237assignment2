//Joshua Sziede

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '.' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            /// <summary>
            /// Create a new instance of a mazeSolver.
            /// </summary>
            MazeSolver mazeSolver = new MazeSolver();

            /// <summary>
            /// Create a new instance of a ui.
            /// </summary>
            UI ui = new UI(maze1);

            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);

            int choice = ui.MazePrompt();
            while (choice != 5)
            {
                switch (choice.ToString())
                {
                    case "1":
                        ui.PrintMaze(maze1);
                        choice = ui.MazePrompt();
                        break;
                    case "2":
                        /// <summary>
                        /// Tell the instance to solve the first maze with the passed maze, and start coordinates.
                        /// </summary>
                        mazeSolver.SolveMaze(maze1, X_START, Y_START);
                        choice = ui.MazePrompt();
                        break;
                    case "3":
                        maze2 = transposeMaze(maze1);
                        ui.PrintMaze(maze2);
                        choice = ui.MazePrompt();
                        break;
                    case "4":
                        //Solve the transposed maze.
                        mazeSolver.SolveMaze(maze2, X_START, Y_START);
                        choice = ui.MazePrompt();
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Error. Please select a valid number.");
                        choice = ui.MazePrompt();
                        break;
                }
            }
        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            //Write code here to create a transposed maze.
            int a = 0;                                          //creates a buffer to store the value of the y-axis
            int b = 0;                                          //creates a buffer to store the value of the x-axis
            char[,] newMaze = new char[12, 12];                 //creates a buffer to store the transposed array so I don't have to overwrite the existing array
            while (a <= 11)                                     //while loop to check every memeber in the y-axis
            {
                while (b <= 11)                                 //while loop to check every member of the x-axis
                {
                    newMaze[a, b] = mazeToTranspose[b, a];      //the actual transposition; the axes are swapped for the new array
                    b++;                                        //increments b by one so that every member of one x-axis is read
                }
                a++;                                            //increments a by one so that every member of one y-axis is read
                b = 0;                                          //resets b so that the index will not be out of range when the program goes back in the x-axis while loop and that the loop will be entered in the first place
            }
            return newMaze;                                     //returns the value of the new maze
        }
    }
}
