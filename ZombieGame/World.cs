using System;

namespace ZombieGame
{
    public class World
    {
        private IGameObject[] agents;
        public IGameObject[,] Grid { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        Random rnd = new Random();

        public World(Config c)
        {
            agents = new IGameObject[c.InitialHumans + c.InitialZombies];

            Grid = new IGameObject[c.Row, c.Column];

            for (int i = 0; i < Grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.GetLength(1); j++)
                {
                    Grid[i, j] = new Empty();
                }
            }

            // This for runs through the array of agents
            for (int i = 0; i < c.InitialHumans; i++)
            {
                Agent a = new Agent(AgentType.Human);
                agents[i] = a;
            }
            for (int i = 0; i < c.InitialZombies; i++)
            {
                Agent a = new Agent(AgentType.Zombie);
                agents[i + c.InitialHumans] = a;
            }

            Spawn(c);
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

        public void Spawn(Config c) {
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