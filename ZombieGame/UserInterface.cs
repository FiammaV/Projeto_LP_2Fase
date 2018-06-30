using System;

namespace ZombieGame {
    /// <summary>
    /// It receives the output and the input
    /// </summary>
    public class UserInterface {

        private World world;
        private int currentRow = 0;
        private int currentCol = 0;
        private bool playableAgent;

        public UserInterface(World world) {
            this.world = world;
        }
        
        // Renders the grid
        public void ShowWorld(IGameObject[,] grid, Agent currentAgent) {
            Console.Clear();
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {

                    if(grid[i, j] == currentAgent) {
                        playableAgent = true;
                        currentRow = i;
                        currentCol = j;
                    } else {
                        playableAgent = false;
                    }

                    Console.Write(State(grid[i, j]));
                    Console.ForegroundColor = ConsoleColor.White;
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

                if ((go as Agent).Playable) {
                    if ((go as Agent).Type == AgentType.Human) {
                        state = 'H';
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else {
                        state = 'Z';
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
                else {
                    if ((go as Agent).Type == AgentType.Human) {
                        state = 'h';
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else {
                        state = 'z';
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                }
            }
            if (playableAgent) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            return state;
        }

        public void WhereToMove(Agent currentAgent, World world) {
            int currentRow = 0;
            int currentCol = 0;
            for (int i = 0; i < world.Grid.GetLength(0); i++) {
                for (int j = 0; j < world.Grid.GetLength(1); j++) {
                    if (world.Grid[i, j] == currentAgent) {
                        currentRow = i;
                        currentCol = j;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("\t* Current player: " + currentAgent);
            Console.WriteLine();

            if (currentRow != 0) {
                if (world.Grid[currentRow - 1, currentCol] is Empty) {
                    Console.WriteLine("At North the path is free.");
                }
                else {
                    Console.WriteLine("At North there's a {0}.", (world.Grid[currentRow - 1, currentCol] as Agent));
                }
            }

            if (currentCol != 0) {
                if (world.Grid[currentRow, currentCol - 1] is Empty) {
                    Console.WriteLine("At East the path is free.");
                }
                else {
                    Console.WriteLine("At East there's a {0}.", (world.Grid[currentRow, currentCol - 1] as Agent));
                }
            }

            if (currentRow != world.Grid.GetLength(0) - 1) {
                if (world.Grid[currentRow + 1, currentCol] is Empty) {
                    Console.WriteLine("At South the path is free.");
                }
                else {
                    Console.WriteLine("At South there's a {0}.", (world.Grid[currentRow + 1, currentCol] as Agent));
                }
            }

            if (currentCol != world.Grid.GetLength(1) - 1) {
                if (world.Grid[currentRow, currentCol + 1] is Empty) {
                    Console.WriteLine("At West the path is free.");
                }
                else {
                    Console.WriteLine("At West there's a {0}.", (world.Grid[currentRow, currentCol + 1] as Agent));
                }
            }

            MovePlayer();
            Console.WriteLine();
        }

        public void MovePlayer() {
            string key = Console.ReadLine();

            if(key == "w") {
                world.Grid[currentRow - 1, currentCol] = world.currentAgent;
                world.Grid[currentRow, currentCol] = new Empty();
            }

            if (key == "d") {
                world.Grid[currentRow, currentCol + 1] = world.currentAgent;
                world.Grid[currentRow, currentCol] = new Empty();
            }

            if (key == "s") {
                world.Grid[currentRow + 1, currentCol] = world.currentAgent;
                world.Grid[currentRow, currentCol] = new Empty();
            }

            if (key == "a") {
                world.Grid[currentRow, currentCol - 1] = world.currentAgent;
                world.Grid[currentRow, currentCol] = new Empty();
            }
        }
    }
}

