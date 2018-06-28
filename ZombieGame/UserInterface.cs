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
            } else if (go is Agent) {
                if ((go as Agent).Type == AgentType.Human) {
                    state = 'H';
                } else {
                    state = 'Z';
                }
            }

            return state;
        }
    }
}

