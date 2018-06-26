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
        // Renders the grid
        public void ShowWorld(IGameObject[,] grid) {
            char state = ' ';
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    state = State(grid[i, j]);
                    Console.Write(state);
                    Console.Write("\t");
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        
        public char State(IGameObject go) {
            char state = ' ';

            //Render the empties
            if (go is Empty) {
                state = '.';
            }

            return state;
        }
    }
}

