using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    class AI {
        private World world;
        private Agent currentAgent;
        private Config c;
        private int agentIndex = 0;
        private int currentRow = 0;
        private int currentCol = 0;

        public AI(Config c, World world) {
            this.world = world;
            this.c = c;
        }

        public void SearchAgent() {
            currentAgent = (world.agents[agentIndex] as Agent);

            for (int i = 0; i < world.Grid.GetLength(0); i++) {
                for (int j = 0; j < world.Grid.GetLength(1); j++) {
                    if (world.Grid[i, j] == currentAgent) {
                        currentCol = j;
                        currentRow = i;
                    }
                }
            }

            agentIndex++;
            if (agentIndex >= world.agents.Length) {
                agentIndex = 0;
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
                        if (currentRow != world.Grid.GetLength(0)) {
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
            if (currentCol != world.Grid.GetLength(1)) {
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
            if (currentRow != world.Grid.GetLength(0)) {
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
                        if (currentCol != world.Grid.GetLength(1)) {
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
        }
    }
}
