//Joshua Sziede

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level member variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        int a;
        int b;
        char[,] currentLocation = new char[12, 12];

        UI ui = new UI();

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class.
            //It is possible that you will not need these class level ones and can get all of the work done
            //with the local ones. Regardless of how you implement it, here are the class level assignments.
            //Feel free to remove the class level variables and assignments if you determine that you don't need them.
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

            //Do work needed to use mazeTraversal recursive call and solve the maze.
            a = yStart;
            b = xStart;
            mazeTraversal();
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// 
        /// I'm not sure if doing a giant if/else structure was the most efficient way of doing this but it seems to work.
        /// Essentially what is happening is that the program will check East, South, West, or North, but only one at a time.
        /// The solver will only advance through paths that are marked with either a '.' or an 'X'.
        /// Every single step that the solver takes will result in going through the method once more until the end has been reached.
        /// Every step will manipulate the coordinate of the solver in either the x-axis or the y-axis.
        /// Eventually one of the coordinates will reach either a 0 or an 11 in ether axis, which tells the program that the end of the maze has been reached.
        /// </summary>
        private void mazeTraversal()
        {
            //Implement maze traversal recursive call
            if (a <= 11 || a > 0 || b <= 11 || b > 0)  //base case which determines that the goal is reached when any coordinate is on the very edge of the maze
            {
                if (a == 11 || b == 11)     //final step of the maze that can only run if the coordinate is on the edge of the maze
                {
                    maze[a, b] = 'X';
                    ui.PrintMaze(maze);
                    ui.Solved();    //simple Console.WriteLine telling the user that the maze is solved
                    a++;
                    b++;
                }
                else if (maze[a, b + 1] != '#' && maze[a, b + 1] == '.' && maze[a, b + 1] != '0')         //check east
                {

                    maze[a, b] = 'X';   //the current position is marked with a successful X
                    b++;    //coord is updated to reflect the path
                    ui.PrintMaze(maze); //maze is printed to the console with the new X
                    ui.MazeSteps(); //user is prompted to see the next step
                    mazeTraversal();    //recursion happens
                }
                else if (maze[a + 1, b] != '#' && maze[a + 1, b] == '.' && maze[a + 1, b] != '0')         //check south 
                {

                    maze[a, b] = 'X';
                    a++;
                    ui.PrintMaze(maze);
                    ui.MazeSteps();
                    mazeTraversal();
                }
                else if (maze[a, b - 1] != '#' && maze[a, b - 1] == '.' && maze[a, b - 1] != '0')         //check west
                {

                    maze[a, b] = 'X';
                    b--;
                    ui.PrintMaze(maze);
                    ui.MazeSteps();
                    mazeTraversal();
                }
                else if (maze[a - 1, b] != '#' && maze[a - 1, b] == '.' && maze[a - 1, b] != '0')         //check north
                {

                    maze[a, b] = 'X';
                    a--;
                    ui.PrintMaze(maze);
                    ui.MazeSteps();
                    mazeTraversal();
                }
                else if (maze[a, b + 1] != '#' && maze[a, b + 1] == 'X')         //check east if dead end
                {
                    maze[a, b] = '0';   //the current position is marked with an unsuccessful 0
                    b++;
                    ui.PrintMaze(maze);
                    ui.MazeSteps();
                    mazeTraversal();
                }
                else if (maze[a + 1, b] != '#' && maze[a + 1, b] == 'X')         //check south if dead end
                {

                    maze[a, b] = '0';
                    a++;
                    ui.PrintMaze(maze);
                    ui.MazeSteps();
                    mazeTraversal();
                }
                else if (maze[a, b - 1] != '#' && maze[a, b - 1] == 'X')         //check west if dead end
                {

                    maze[a, b] = '0';
                    b--;
                    ui.PrintMaze(maze);
                    ui.MazeSteps();
                    mazeTraversal();
                }
                else if (maze[a - 1, b] != '#' && maze[a - 1, b] == 'X')         //check north if dead end
                {

                    maze[a, b] = '0';
                    a--;
                    ui.PrintMaze(maze);
                    ui.MazeSteps();
                    mazeTraversal();
                }
                else if (a == yStart && b == xStart)    //emergency code only ran if there is no exit.
                {
                    maze[a, b] = 'X';
                    ui.PrintMaze(maze);
                    ui.NotSolved();
                    a = 0;
                    b = 0;
                }
            }
        }
    }
}
