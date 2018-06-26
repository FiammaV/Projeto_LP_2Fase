using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    public class UserInterface {
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

            if (go is Empty) {
                state = '.';
            }

            return state;
        }
    }
}

