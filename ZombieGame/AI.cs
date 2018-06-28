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
            VerifyNeighbours();

            agentIndex++;
            if (agentIndex >= world.agents.Length) {
                agentIndex = 0;
            }

        }

        private void VerifyNeighbours() {
            // Verify for Humans

            if (currentAgent.Type == AgentType.Human) {

                if (currentRow != 0) // Norte
                {
                    if (world.Grid[currentRow - 1, currentCol] is Empty) {
                        world.Grid[currentRow - 1, currentCol] = currentAgent;
                        world.Grid[currentRow, currentCol] = new Empty();
                        return;
                    }
                    else if ((world.Grid[currentRow - 1, currentCol] as Agent).Type == AgentType.Zombie) {
                        world.Grid[currentRow + 1, currentCol] = currentAgent;
                        world.Grid[currentRow, currentCol] = new Empty();
                        return;
                    }
                }
                if (currentCol != 0) // Oeste
                {
                    if (world.Grid[currentRow, currentCol - 1] is Empty) {
                        world.Grid[currentRow, currentCol - 1] = currentAgent;
                        world.Grid[currentRow, currentCol] = new Empty();
                        return;
                    }
                    else if ((world.Grid[currentRow, currentCol - 1] as Agent).Type == AgentType.Zombie) {
                        world.Grid[currentRow, currentCol + 1] = currentAgent;
                        world.Grid[currentRow, currentCol] = new Empty();
                        return;
                    }
                }
                if (currentRow != c.Row) // Sul
                {
                    if (world.Grid[currentRow + 1, currentCol] is Empty) {
                        world.Grid[currentRow + 1, currentCol] = currentAgent;
                        world.Grid[currentRow, currentCol] = new Empty();
                        return;
                    }
                    else if ((world.Grid[currentRow + 1, currentCol] as Agent).Type == AgentType.Zombie) {
                        world.Grid[currentRow - 1, currentCol] = currentAgent;
                        world.Grid[currentRow, currentCol] = new Empty();
                        return;
                    }
                }
                if (currentCol != c.Column) // Este
                {
                    if (world.Grid[currentRow, currentCol + 1] is Empty) {
                        world.Grid[currentRow, currentCol + 1] = currentAgent;
                        world.Grid[currentRow, currentCol] = new Empty();
                        return;
                    }
                    else if ((world.Grid[currentRow, currentCol + 1] as Agent).Type == AgentType.Zombie) {
                        world.Grid[currentRow, currentCol - 1] = currentAgent;
                        world.Grid[currentRow, currentCol] = new Empty();
                        return;
                    }
                }
                // Verify for zombies
            }
        }
    }
}
