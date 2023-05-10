using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pokus3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = 15; // number of rows in the game board
            int cols = 30; // number of columns in the game board

            // Create the game board with 1's at the borders and 0's inside
            int[,] board = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || i == rows - 1 || j == 0 || j == cols - 1)
                    {
                        board[i, j] = 1;
                    }
                }
            }

            // Initialize the snake head in the middle of the board
            int snakeRow = rows / 2;
            int snakeCol = cols / 2;
            board[snakeRow, snakeCol] = 2; // using '2' to represent the snake head

            // Spawn an apple in a random position on the board
            Random rand = new Random();
            int appleRow = rand.Next(1, rows - 1);
            int appleCol = rand.Next(1, cols - 1);
            board[appleRow, appleCol] = 3; // using '3' to represent the apple

            // Set up the initial direction of the snake
            int dx = 0; // horizontal movement (positive to the right, negative to the left)
            int dy = 0; // vertical movement (positive downwards, negative upwards)

            // Game loop
            while (true)
            {
                // Move the snake head according to the current direction
                snakeRow += dy;
                snakeCol += dx;

                // Check if the snake head has hit the border
                if (snakeRow <= 0 || snakeRow >= rows - 1 || snakeCol <= 0 || snakeCol >= cols - 1)
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                // Check if the snake head has eaten the apple
                if (board[snakeRow, snakeCol] == 3)
                {
                    // Spawn a new apple in a random position
                    appleRow = rand.Next(1, rows - 1);
                    appleCol = rand.Next(1, cols - 1);
                    board[appleRow, appleCol] = 3;

                    // Increase the length of the snake by 1
                    // For simplicity, we're just going to add a new head at the end
                    board[snakeRow, snakeCol] = 2;
                }

                // Move the snake head on the board
                board[snakeRow, snakeCol] = 2;
                board[snakeRow - dy, snakeCol - dx] = 0;

                // Print out the game board with the snake head and apple
                Console.Clear();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (board[i, j] == 1)
                        {
                            Console.Write("1 ");
                        }
                        else if (board[i, j] == 2)
                        {
                            Console.Write("▄ ");
                        }
                        else if (board[i, j] == 3)
                        {
                            Console.Write("@ ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    Console.WriteLine();
                }

                // Wait for 1 second before moving again
                System.Threading.Thread.Sleep(1000);
                // Read keyboard input to set the direction of the snake
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        dx = 0;
                        dy = -1;
                        break;
                    case ConsoleKey.DownArrow:
                        dx = 0;
                        dy = 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        dx = -1;
                        dy = 0;
                        break;
                    case ConsoleKey.RightArrow:
                        dx = 1;
                        dy = 0;
                        break;
                }
            }
        }
    }
}
