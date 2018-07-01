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

        private string north = "";
        private string south = "";
        private string east = "";
        private string west = "";

        private bool zNorth;
        private bool zEast;
        private bool zSouth;
        private bool zWest;

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
                        // Human
                        state = '\u2663';
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else {
                        // Zombie
                        state = '\u25B2';
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
                else {
                    if ((go as Agent).Type == AgentType.Human) {
                        // Human
                        state = '\u2663';
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else {
                        // Zombie
                        state = '\u25B2';
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
            Console.WriteLine("* Current player: " + currentAgent);

            if (currentRow != 0) {
                if (world.Grid[currentRow - 1, currentCol] is Empty) {
                    Console.WriteLine("\t- At North the path is free.");
                    north = "W (north)";
                }
                else {
                    Console.WriteLine("\t- At North there's a {0}.", (world.Grid[currentRow - 1, currentCol] as Agent));
                    if (currentAgent.Type == AgentType.Zombie && currentAgent.Type !=
                        (world.Grid[currentRow - 1, currentCol] as Agent).Type) {
                        north = "W (north)";
                        zNorth = true;
                    } else {
                        north = "";
                        zNorth = false;
                    }
                }
            } else {
                north = "";
                zNorth = false;
            }

            if (currentCol != 0) {
                if (world.Grid[currentRow, currentCol - 1] is Empty) {
                    Console.WriteLine("\t- At West the path is free.");
                    west = "A (west)";
                }
                else {
                    Console.WriteLine("\t- At West there's a {0}.", (world.Grid[currentRow, currentCol - 1] as Agent));
                    if (currentAgent.Type == AgentType.Zombie && currentAgent.Type !=
                        (world.Grid[currentRow, currentCol -1] as Agent).Type) {
                        west = "A (west)";
                        zWest = true;
                    } else {
                        west = "";
                        zWest = false;
                    }
                }
            } else {
                west = "";
                zWest = false;
            }

            if (currentRow != world.Grid.GetLength(0) - 1) {
                if (world.Grid[currentRow + 1, currentCol] is Empty) {
                    Console.WriteLine("\t- At South the path is free.");
                    south = "S (south)";
                }
                else {
                    Console.WriteLine("\t- At South there's a {0}.", (world.Grid[currentRow + 1, currentCol] as Agent));
                    if (currentAgent.Type == AgentType.Zombie && currentAgent.Type !=
                        (world.Grid[currentRow + 1, currentCol] as Agent).Type) {
                        south = "S (south)";
                        zSouth = true;
                    } else {
                        south = "";
                        zSouth = false;
                    }
                }
            } else {
                south = "";
                zSouth = false;
            }

            if (currentCol != world.Grid.GetLength(1) - 1) {
                if (world.Grid[currentRow, currentCol + 1] is Empty) {
                    Console.WriteLine("\t- At East the path is free.");
                    east = "D (east)";
                }
                else {
                    Console.WriteLine("\t- At East there's a {0}.", (world.Grid[currentRow, currentCol + 1] as Agent));
                    if (currentAgent.Type == AgentType.Zombie && currentAgent.Type !=
                        (world.Grid[currentRow, currentCol + 1] as Agent).Type) {
                        east = "";
                        zEast = true;
                    } else {
                        east = "";
                        zEast = false;
                    }
                }
            } else {
                east = "";
                zEast = false;
            }

            Console.Write("* What path to take? ");
            Console.Write(north == "" ? "" : (north + ", "));
            Console.Write(east == "" ? "" : (east + ", "));
            Console.Write(south == "" ? "" : (south + ", "));
            Console.Write(west == "" ? "" : west);
            Console.WriteLine();

            MovePlayer();
        }

        private void MovePlayer() {
            string key = Console.ReadLine();

            if((key == "w" || key == "W") && north != "") {
                if (zNorth) {
                    (world.Grid[currentRow - 1, currentCol] as Agent).Type = AgentType.Zombie;
                } else {
                    world.Grid[currentRow - 1, currentCol] = world.currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            }

            if ((key == "d" || key == "D") && east != "") {
                if (zEast) {
                    (world.Grid[currentRow, currentCol +1] as Agent).Type = AgentType.Zombie;
                }
                else {
                    world.Grid[currentRow, currentCol + 1] = world.currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            }

            if ((key == "s" || key == "S") && south != "") {
                if (zSouth) {
                    (world.Grid[currentRow + 1, currentCol] as Agent).Type = AgentType.Zombie;
                }
                else {
                    world.Grid[currentRow + 1, currentCol] = world.currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            }

            if ((key == "a" || key == "A") && west != "") {
                if (zWest) {
                    (world.Grid[currentRow, currentCol - 1] as Agent).Type = AgentType.Zombie;
                }
                else {
                    world.Grid[currentRow, currentCol -1] = world.currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            }
        }
    }
}

