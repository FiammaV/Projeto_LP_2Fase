using System;

namespace ZombieGame
{
    public class World
    {
        public IGameObject[] agents;
        public IGameObject[,] Grid { get; set; }
        public Agent currentAgent { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        Random rnd;
        Config c;

        public World(Config c, Random rnd)
        {
            this.rnd = rnd;
            this.c = c;

            Grid = new IGameObject[c.Row, c.Column];

            for (int i = 0; i < c.Row; i++) {
                for (int j = 0; j < c.Column; j++) {
                    Grid[i, j] = new Empty();
                }
            }
            StartAgentsArray();
        }

        private void StartAgentsArray() {
            agents = new IGameObject[c.InitialHumans + c.InitialZombies];

            // This for runs through the array of agents
            for (int i = 0; i < c.InitialHumans; i++) {
                agents[i] = new Agent(AgentType.Human);
            }
            for (int i = 0; i < c.InitialZombies; i++) {
                agents[i + c.InitialHumans] = new Agent(AgentType.Zombie);
            }
            Spawn();
            Shuffle();
        }

        // Fisher Yates method
        public void Shuffle()
        {
            for (int i = agents.Length - 1; i > 0; i--) {
                int j = rnd.Next(i + 1);
                Agent temp = (Agent)agents[i];
                agents[i] = agents[j];
                agents[j] = temp;
            }
        }

        public void Spawn() {
            for (int i = 0; i < agents.Length; i++) {
                do {
                    Row = rnd.Next(c.Row -1);
                    Column = rnd.Next(c.Column -1);
                } while (Grid[Row, Column] is Agent);

                    Grid[Row, Column] = agents[i];
            }
        }
    }
}