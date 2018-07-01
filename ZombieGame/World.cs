using System;

namespace ZombieGame {
    /// <summary>
    /// Class for the world
    /// </summary>
    public class World {
        /// <summary>
        /// Arrays for the world and the agents
        /// </summary>
        public IGameObject[] agents;
        /// <summary>
        /// Properties for the array
        /// </summary>
        public IGameObject[,] Grid { get; set; }
        /// <summary>
        /// Properties for the current player
        /// </summary>
        public Agent currentAgent { get; set; }
        /// <summary>
        /// Properties for the row
        /// </summary>
        public int Row { get; set; }
        /// <summary>
        /// Properties for the row
        /// </summary>
        public int Column { get; set; }
        // Initialization of the other classes
        private Random rnd;
        private Config c;

        /// <summary>
        /// Constrotor of the class
        /// </summary>
        /// <param name="c"></param>
        /// <param name="rnd"></param>
        public World(Config c, Random rnd) {
            this.rnd = rnd;
            this.c = c;

            // Creats a new grid
            Grid = new IGameObject[c.Row, c.Column];

            // Fills the grid array with empties
            for (int i = 0; i < c.Row; i++) {
                for (int j = 0; j < c.Column; j++) {
                    Grid[i, j] = new Empty();
                }
            }
            // Calls the StartAgentsArray()
            StartAgentsArray();
        }

        /// <summary>
        /// Method that fills the array of agents with humans and zombies
        /// </summary>
        private void StartAgentsArray() {
            agents = new IGameObject[c.InitialHumans + c.InitialZombies];

            // This for runs through the array of agents
            for (int i = 0; i < c.InitialHumans; i++) {
                agents[i] = new Agent(AgentType.Human, i);

                if (i < c.ControlHumans) {
                    (agents[i] as Agent).Playable = true;
                }
            }
            for (int i = 0; i < c.InitialZombies; i++) {
                agents[i + c.InitialHumans] = new Agent(AgentType.Zombie, i);

                if (i < c.ControlZombies) {
                    (agents[i + c.InitialHumans] as Agent).Playable = true ;
                }
            }
            // Calls the methods Spawm() and Suffle()
            Spawn();
            Shuffle();
        }

        /// <summary>
        /// Fisher Yates method
        /// </summary>
        public void Shuffle() {
            for (int i = agents.Length - 1; i > 0; i--) {
                int j = rnd.Next(i + 1);
                Agent temp = (Agent)agents[i];
                agents[i] = agents[j];
                agents[j] = temp;
            }
        }

        /// <summary>
        /// Method that spawms the agents
        /// </summary>
        public void Spawn() {
            // For cicle that runs through the array of agents and makes them 
            // spawm and move in a random way
            for (int i = 0; i < agents.Length; i++) {
                do {
                    Row = rnd.Next(c.Row - 1);
                    Column = rnd.Next(c.Column - 1);
                } while (Grid[Row, Column] is Agent);

                Grid[Row, Column] = agents[i];
            }
        }
    }
}