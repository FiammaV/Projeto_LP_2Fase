using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    /// <summary>
    /// It receives the output and the input
    /// </summary>
    public class UserInterface {
        public UserInterface() { }

        // Renders the grid
        public void ShowWorld(IGameObject[,] grid) {
            Console.Clear();
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    Console.Write(State(grid[i, j]));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        public char State(IGameObject go) {
            char state = ' ';

            //Render the empties
            if (go is Empty) {
                state = '.';
            }
            else if (go is Agent) {
                if ((go as Agent).Type == AgentType.Human) {
                    state = 'H';
                }
                else {
                    state = 'Z';
                }
            }

            return state;
        }

        public void WhereToMove(Agent currentAgent, World world) {
            int currentRow = 0;
            int currentCol = 0;
            for (int i = 0; i < world.Grid.GetLength(0); i++) {
                for (int j = 0; j < world.Grid.GetLength(1); j++) {
                    if (world.Grid[i,j] == currentAgent) {
                        currentRow = i;
                        currentCol = j;
                    }
                }
            }

            Console.WriteLine("\t * Next player: ");

            if (world.Grid[currentRow - 1, currentCol] is Empty) {
                Console.WriteLine("At North the path is free");
            } else {
                Console.WriteLine("At North there's: {0}", world.Grid[currentRow - 1, currentCol]);
            }

            if (world.Grid[currentRow, currentCol - 1] is Empty) {
                Console.WriteLine("At East the path is free");
            }
            else {
                Console.WriteLine("At East there's: {0}", world.Grid[currentRow, currentCol - 1]);
            }

            if (world.Grid[currentRow + 1, currentCol] is Empty) {
                Console.WriteLine("At South the path is free");
            }
            else {
                Console.WriteLine("At South there's: {0}", world.Grid[currentRow + 1, currentCol]);
            }

            if (world.Grid[currentRow, currentCol + 1] is Empty) {
                Console.WriteLine("At West the path is free");
            }
            else {
                Console.WriteLine("At West there's: {0}", world.Grid[currentRow, currentCol + 1]);
            }


            //            *Proximo a jogar: H00
            // - A Norte existe o zombie 01(IA).
            // - A Sul existe o humano 02(IA).
            // - A Oeste o caminho está livre.
            // - A Leste o caminho está livre.
            //* Qual o caminho a seguir? A(oeste) ou D(leste) >
        }
    }
}

