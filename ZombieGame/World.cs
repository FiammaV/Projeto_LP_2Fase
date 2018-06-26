using System;

namespace ZombieGame
{
    public class World
    {

        private IGameObject[] agents;
        private IGameObject[,] grid;
        public int Row { get; }
        public int Column { get; }
        
        public World(Config c)
        {
            Random rnd = new Random();

            agents = new IGameObject[c.InitialHumans + c.InitialZombies];

            grid = new IGameObject[Row, Column];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Empty();
                }
            }

            UserInterface it = new UserInterface();
            it.ShowWorld(grid);

            // This for runs through the array of agents
            for (int i = 0; i < agents.Length; i++)
            {
                Agent a = new Agent(AgentType.Human);
                agents[i] = a;
                Row = Convert.ToInt32(rnd);
                Column = Convert.ToInt32(rnd);
                grid[Row, Column] = a;
            }
            for (int i = 0; i < agents.Length; i++)
            {
                Agent a = new Agent(AgentType.Zombie);
                agents[i] = a;
                Row = Convert.ToInt32(rnd);
                Column = Convert.ToInt32(rnd);
                grid[Row, Column] = a;
            }

        }
    }
}