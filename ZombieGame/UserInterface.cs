using System;

namespace ZombieGame {
    /// <summary>
    /// Class that receives the output and the input
    /// </summary>
    public class UserInterface {

        // Initialization of the other classes
        private Config c;
        private World world;
        // Variables initiated at zero
        private int currentRow = 0;
        private int currentCol = 0;
        private int totalZombies = 0;
        private bool playableAgent;

        private string north = "";
        private string south = "";
        private string east = "";
        private string west = "";

        private bool zNorth;
        private bool zEast;
        private bool zSouth;
        private bool zWest;

        /// <summary>
        /// Construtor of the class
        /// </summary>
        /// <param name="world"></param>
        /// <param name="c"></param>
        public UserInterface(World world, Config c) {
            this.world = world;
            this.c = c;
        }
        
        // Method that renders the grid
        public void ShowWorld(IGameObject[,] grid, Agent currentAgent) {
            Console.Clear();
            totalZombies = 0;

            // Two for cicles that run through the array of agents to get the total
            // number of zombies
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    if (grid[i, j] is Agent)
                    {
                        if ((grid[i, j] as Agent).Type == AgentType.Zombie)
                        {
                            totalZombies++;
                        }
                    }

                    // Checks if the current agent is playble
                    if(grid[i, j] == currentAgent) {
                        playableAgent = true;
                        currentRow = i;
                        currentCol = j;
                    } else {
                        playableAgent = false;
                    }

                    // Renders the grid
                    Console.Write(State(grid[i, j]));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Method that draws the grid
        /// </summary>
        /// <param name="go"></param>
        /// <returns></returns>
        public string State(IGameObject go) {
            string state = " ";

            // Draws the empty place
            if (go is Empty) {
                state = " . ";
            }
            else if (go is Agent) {

                // Checks if it's playable or not to draw in the right colors
                if ((go as Agent).Playable) {
                    // Human
                    if ((go as Agent).Type == AgentType.Human) {
                        state = string.Format("\u2663{0:d2}", (go as Agent).Index);
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    // Zombie
                    else {
                        state = string.Format("\u25B2{0:d2}", (go as Agent).Index);
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                }
                else {
                    // Human
                    if ((go as Agent).Type == AgentType.Human) {
                        state = string.Format("\u2663{0:d2}", (go as Agent).Index);
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    // Zombie
                    else {
                        state = string.Format("\u25B2{0:d2}", (go as Agent).Index);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                }
            }

            if (playableAgent) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            return state;
        }

        /// <summary>
        /// Method that checks where the player can move
        /// </summary>
        /// <param name="currentAgent"></param>
        /// <param name="world"></param>
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
                // If the space above is empty, it'll display the messages
                if (world.Grid[currentRow - 1, currentCol] is Empty) {
                    Console.WriteLine("\t- At North the path is free.");
                    north = "W (north)";
                }
                // Otherwise, it'll show which agent is occupying it
                else {
                    Console.WriteLine("\t- At North there's a {0}.", 
                        (world.Grid[currentRow - 1, currentCol] as Agent));
                    // It'll check if the agent above is a human or agent
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
                // If the space on the left is empty, it'll display the messages
                if (world.Grid[currentRow, currentCol - 1] is Empty) {
                    Console.WriteLine("\t- At West the path is free.");
                    west = "A (west)";
                }
                // Otherwise, it'll show which agent is occupying it
                else {
                    Console.WriteLine("\t- At West there's a {0}.", 
                        (world.Grid[currentRow, currentCol - 1] as Agent));
                    // It'll check if the agent on the left is a human or agent
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
                // If the space below is empty, it'll display the messages
                if (world.Grid[currentRow + 1, currentCol] is Empty) {
                    Console.WriteLine("\t- At South the path is free.");
                    south = "S (south)";
                }
                // Otherwise, it'll show which agent is occupying it
                else {
                    Console.WriteLine("\t- At South there's a {0}.", 
                        (world.Grid[currentRow + 1, currentCol] as Agent));
                    // It'll check if the agent below you is a human or agent
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
                // If the space on the right is empty, it'll display the messages
                if (world.Grid[currentRow, currentCol + 1] is Empty) {
                    Console.WriteLine("\t- At East the path is free.");
                    east = "D (east)";
                }
                // Otherwise, it'll show which agent is occupying it
                else {
                    Console.WriteLine("\t- At East there's a {0}.", 
                        (world.Grid[currentRow, currentCol + 1] as Agent));
                    // It'll check if the agent on the right is a human or agent
                    if (currentAgent.Type == AgentType.Zombie && currentAgent.Type !=
                        (world.Grid[currentRow, currentCol + 1] as Agent).Type) {
                        east = "D (east)";
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

            // Calls the method MovePlayer()
            MovePlayer();
        }

        /// <summary>
        /// Method that moves the playable agents
        /// </summary>
        private void MovePlayer() {
            string key = Console.ReadLine();

            // If conditions that move the agent accordingly with the key the 
            // player presses
            if((key == "w" || key == "W") && north != "") {
                if (zNorth) {
                    (world.Grid[currentRow - 1, currentCol] as Agent).Type = AgentType.Zombie;
                    (world.Grid[currentRow - 1, currentCol] as Agent).Index = totalZombies;
                    c.InitialHumans--;
                } else {
                    world.Grid[currentRow - 1, currentCol] = world.currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            }

            if ((key == "d" || key == "D") && east != "") {
                if (zEast) {
                    (world.Grid[currentRow, currentCol +1] as Agent).Type = AgentType.Zombie;
                    (world.Grid[currentRow, currentCol + 1] as Agent).Index = totalZombies;
                    c.InitialHumans--;
                }
                else {
                    world.Grid[currentRow, currentCol + 1] = world.currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            }

            if ((key == "s" || key == "S") && south != "") {
                if (zSouth) {
                    (world.Grid[currentRow + 1, currentCol] as Agent).Type = AgentType.Zombie;
                    (world.Grid[currentRow + 1, currentCol] as Agent).Index = totalZombies;
                    c.InitialHumans--;
                }
                else {
                    world.Grid[currentRow + 1, currentCol] = world.currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            }

            if ((key == "a" || key == "A") && west != "") {
                if (zWest) {
                    (world.Grid[currentRow, currentCol - 1] as Agent).Type = AgentType.Zombie;
                    (world.Grid[currentRow, currentCol - 1] as Agent).Index = totalZombies;
                    c.InitialHumans--;
                }
                else {
                    world.Grid[currentRow, currentCol -1] = world.currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            }
        }
    }
}

