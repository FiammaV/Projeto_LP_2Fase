using System;

namespace ZombieGame {
    /// <summary>
    /// Class responsible for the movement of the AI
    /// </summary>
    class AI {
        // Initialization of the other classes
        private World world;
        private Random rnd;
        private Config c;
        // Variables initiated at zero
        private int totalZombies = 0;
        private int currentRow = 0;
        private int currentCol = 0;

        /// <summary>
        /// Construtor of the class
        /// </summary>
        /// <param name="c"></param>
        /// <param name="world"></param>
        /// <param name="rnd"></param>
        public AI(Config c, World world, Random rnd) {
            this.world = world;
            this.c = c;
            this.rnd = rnd;
        }

        /// <summary>
        /// Method that searches the position of the current player and calls
        /// the method MoveAgents() to move it
        /// </summary>
        public void SearchAgent() {
            // Two for cicles that run through the array of the grid to find the
            // current agent, once it finds it, it will temporarily save its 
            // position on two distincts variables
            for (int i = 0; i < world.Grid.GetLength(0); i++) {
                for (int j = 0; j < world.Grid.GetLength(1); j++) {
                    if (world.Grid[i, j] == world.currentAgent) {
                        currentCol = j;
                        currentRow = i;
                    }
                }
            }
            // Calls the method MoveAgents()
            MoveAgents();

        }

        /// <summary>
        /// Method that moves the AI
        /// </summary>
        private void MoveAgents() {
            Agent nearAgent;
            totalZombies = 0;
            // For cicle that runs through the array of agents to get the total
            // number of zombies
            for (int i = 0; i < world.agents.Length; i++)
            {
                if ((world.agents[i] as Agent).Type == AgentType.Zombie)
                {
                    totalZombies++;
                }
            }

            // All of this block of code does the same thing but for different
            // directions

            // Checks if in the current position there's an agent and acts 
            // accordingly, with means if the current agent is a human and
            // finds another human, it will simply move elsewhere, if it finds a zombie
            // it will move to the opposite direction. And if it's a zombie finding
            // a human it will infect it and stay in the same place
            // *************************

            // Verifies North
            if (currentRow != 0) {
                if (world.Grid[currentRow - 1, currentCol] is Agent) {
                    nearAgent = (world.Grid[currentRow - 1, currentCol] as Agent);
                    if (world.currentAgent.Type != nearAgent.Type && 
                        nearAgent.Type == AgentType.Zombie) {
                        if (currentRow != world.Grid.GetLength(0) - 1) {
                            if (world.Grid[currentRow + 1, currentCol] is Empty) {
                                world.Grid[currentRow + 1, currentCol] = world.currentAgent;
                                world.Grid[currentRow, currentCol] = new Empty();
                                return;
                            }
                        }
                    }
                    else if (world.currentAgent.Type != nearAgent.Type &&
                        nearAgent.Type == AgentType.Human) {
                        nearAgent.Type = AgentType.Zombie;
                        nearAgent.Index = totalZombies;
                        c.InitialHumans--;
                        return;
                    }
                }
            }

            //Verifies East
            if (currentCol != world.Grid.GetLength(1) - 1) {
                if (world.Grid[currentRow, currentCol + 1] is Agent) {
                    nearAgent = (world.Grid[currentRow, currentCol + 1] as Agent);
                    if (world.currentAgent.Type != nearAgent.Type &&
                        nearAgent.Type == AgentType.Zombie) {
                        if (currentCol != 0) {
                            if (world.Grid[currentRow, currentCol - 1] is Empty) {
                                world.Grid[currentRow, currentCol - 1] = world.currentAgent;
                                world.Grid[currentRow, currentCol] = new Empty();
                                return;
                            }
                        }
                    }
                    else if (world.currentAgent.Type != nearAgent.Type && 
                        nearAgent.Type == AgentType.Human) {
                        nearAgent.Type = AgentType.Zombie;
                        nearAgent.Index = totalZombies;
                        c.InitialHumans--;
                        return;
                    }
                }
            }

            //Verifies South
            if (currentRow != world.Grid.GetLength(0) - 1) {
                if (world.Grid[currentRow + 1, currentCol] is Agent) {
                    nearAgent = (world.Grid[currentRow + 1, currentCol] as Agent);
                    if (world.currentAgent.Type != nearAgent.Type &&
                        nearAgent.Type == AgentType.Zombie) {
                        if (currentRow != 0) {
                            if (world.Grid[currentRow - 1, currentCol] is Empty) {
                                world.Grid[currentRow - 1, currentCol] = world.currentAgent;
                                world.Grid[currentRow, currentCol] = new Empty();
                                return;
                            }
                        }
                    }
                    else if (world.currentAgent.Type != nearAgent.Type &&
                        nearAgent.Type == AgentType.Human) {
                        nearAgent.Type = AgentType.Zombie;
                        nearAgent.Index = totalZombies;
                        c.InitialHumans--;
                        return;
                    }
                }
            }

            //Verifies West
            if (currentCol != 0) {
                if (world.Grid[currentRow, currentCol - 1] is Agent) {
                    nearAgent = (world.Grid[currentRow, currentCol - 1] as Agent);
                    if (world.currentAgent.Type != nearAgent.Type && 
                        nearAgent.Type == AgentType.Zombie) {
                        if (currentCol != world.Grid.GetLength(1) - 1) {
                            if (world.Grid[currentRow, currentCol + 1] is Empty) {
                                world.Grid[currentRow, currentCol + 1] = world.currentAgent;
                                world.Grid[currentRow, currentCol] = new Empty();
                                return;
                            }
                        }
                    }
                    else if (world.currentAgent.Type != nearAgent.Type &&
                        nearAgent.Type == AgentType.Human) {
                        nearAgent.Type = AgentType.Zombie;
                        nearAgent.Index = totalZombies;
                        c.InitialHumans--;
                        return;
                    }
                }
            }
            // *************************


            // Will check if it moves in x or y
            char dir = rnd.NextDouble() < 0.5f ? 'x' : 'y';
            // Will check which direction it will move to
            int side = rnd.NextDouble() < 0.5f ? 1 : -1;

            // Checks if the random movement gives an out of bounds exception
            if (currentCol == 0 && side == -1 || currentRow == 0 && side == -1) {
                // If it does, it will change the direction to positive
                side = 1;
            }
            // Checks if the random movement gives an out of bounds exception
            else if (currentCol == world.Grid.GetLength(1) - 1 && side == 1
              || currentRow == world.Grid.GetLength(0) - 1 && side == 1) {
                // If it does, it will change the direction to negative
                side = -1;
            }

            // Checks if the random movement gives an out of bounds exception
            // in the corners
            if (currentCol == 0 && currentRow == world.Grid.GetLength(0) - 1) {
                if (dir == 'x') {
                    side = 1;
                } else {
                    side = -1;
                }
            }
            // Checks if the random movement gives an out of bounds exception
            // in the corners
            else if (currentCol == world.Grid.GetLength(1) - 1 && currentRow == 0) {
                if (dir == 'x') {
                    side = -1;
                } else {
                    side = 1;
                }
            }

            // Moves the player
            if (dir == 'x') {
                if (world.Grid[currentRow, currentCol + side] is Empty) {
                    world.Grid[currentRow, currentCol + side] = world.currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            } else if (dir == 'y') {
                if (world.Grid[currentRow + side, currentCol] is Empty) {
                    world.Grid[currentRow + side, currentCol] = world.currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            }
        }
    }
}
