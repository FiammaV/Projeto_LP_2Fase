using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    class AI {
        private World world;
        private Agent currentAgent;
        private Random rnd;
        private Config c;
        private int currentRow = 0;
        private int currentCol = 0;

        public AI(Config c, World world, Random rnd, Agent current) {
            this.world = world;
            this.c = c;
            this.rnd = rnd;
            currentAgent = current;
        }

        public void SearchAgent() {
            for (int i = 0; i < world.Grid.GetLength(0); i++) {
                for (int j = 0; j < world.Grid.GetLength(1); j++) {
                    if (world.Grid[i, j] == currentAgent) {
                        currentCol = j;
                        currentRow = i;
                    }
                }
            }
            MoveAgents();

        }

        private void MoveAgents() {
            Agent nearAgent;

            // Verify North
            if (currentRow != 0) {
                if (world.Grid[currentRow - 1, currentCol] is Agent) {
                    nearAgent = (world.Grid[currentRow - 1, currentCol] as Agent);
                    if (currentAgent.Type != nearAgent.Type && nearAgent.Type == AgentType.Zombie) {
                        if (currentRow != world.Grid.GetLength(0) - 1) {
                            if (world.Grid[currentRow + 1, currentCol] is Empty) {
                                world.Grid[currentRow + 1, currentCol] = currentAgent;
                                world.Grid[currentRow, currentCol] = new Empty();
                                return;
                            }
                        }
                    }
                    else if (currentAgent.Type != nearAgent.Type && nearAgent.Type == AgentType.Human) {
                        nearAgent.Type = AgentType.Zombie;
                        return;
                    }
                }
            }

            //Verify East
            if (currentCol != world.Grid.GetLength(1) - 1) {
                if (world.Grid[currentRow, currentCol + 1] is Agent) {
                    nearAgent = (world.Grid[currentRow, currentCol + 1] as Agent);
                    if (currentAgent.Type != nearAgent.Type && nearAgent.Type == AgentType.Zombie) {
                        if (currentCol != 0) {
                            if (world.Grid[currentRow, currentCol - 1] is Empty) {
                                world.Grid[currentRow, currentCol - 1] = currentAgent;
                                world.Grid[currentRow, currentCol] = new Empty();
                                return;
                            }
                        }
                    }
                    else if (currentAgent.Type != nearAgent.Type && nearAgent.Type == AgentType.Human) {
                        nearAgent.Type = AgentType.Zombie;
                        return;
                    }
                }
            }

            //Verify South
            if (currentRow != world.Grid.GetLength(0) - 1) {
                if (world.Grid[currentRow + 1, currentCol] is Agent) {
                    nearAgent = (world.Grid[currentRow + 1, currentCol] as Agent);
                    if (currentAgent.Type != nearAgent.Type && nearAgent.Type == AgentType.Zombie) {
                        if (currentRow != 0) {
                            if (world.Grid[currentRow - 1, currentCol] is Empty) {
                                world.Grid[currentRow - 1, currentCol] = currentAgent;
                                world.Grid[currentRow, currentCol] = new Empty();
                                return;
                            }
                        }
                    }
                    else if (currentAgent.Type != nearAgent.Type && nearAgent.Type == AgentType.Human) {
                        nearAgent.Type = AgentType.Zombie;
                        return;
                    }
                }
            }

            //Verify West
            if (currentCol != 0) {
                if (world.Grid[currentRow, currentCol - 1] is Agent) {
                    nearAgent = (world.Grid[currentRow, currentCol - 1] as Agent);
                    if (currentAgent.Type != nearAgent.Type && nearAgent.Type == AgentType.Zombie) {
                        if (currentCol != world.Grid.GetLength(1) - 1) {
                            if (world.Grid[currentRow, currentCol + 1] is Empty) {
                                world.Grid[currentRow, currentCol + 1] = currentAgent;
                                world.Grid[currentRow, currentCol] = new Empty();
                                return;
                            }
                        }
                    }
                    else if (currentAgent.Type != nearAgent.Type && nearAgent.Type == AgentType.Human) {
                        nearAgent.Type = AgentType.Zombie;
                        return;
                    }
                }
            }

            // Will check for the sides
            char dir = rnd.NextDouble() < 0.5f ? 'x' : 'y';
            // Will check which direction (negative or positive)
            int side = rnd.NextDouble() < 0.5f ? 1 : -1;

            if (currentCol == 0 && side == -1 || currentRow == 0 && side == -1) {
                side = 1;
            }
            else if (currentCol == world.Grid.GetLength(1) - 1 && side == 1
              || currentRow == world.Grid.GetLength(0) - 1 && side == 1) {
                side = -1;
            }
            if (currentCol == 0 && currentRow == 19) {
                if (dir == 'x') {
                    side = 1;
                } else {
                    side = -1;
                }
            } else if (currentCol == 19 && currentRow == 0) {
                if (dir == 'x') {
                    side = -1;
                } else {
                    side = 1;
                }
            }


            if (dir == 'x') {
                if (world.Grid[currentRow, currentCol + side] is Empty) {
                    world.Grid[currentRow, currentCol + side] = currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            } else if (dir == 'y') {
                if (world.Grid[currentRow, currentCol + side] is Empty) {
                    world.Grid[currentRow + side, currentCol] = currentAgent;
                    world.Grid[currentRow, currentCol] = new Empty();
                }
            }
        }
    }
}
