using System;

namespace ZombieGame {
    /// <summary>
    /// Class that does the gameloop
    /// </summary>
    public class GameManager {
        // Created a new random
        Random rnd = new Random();
        // Initialization of the other classes
        private Config config;
        private World world;
        private UserInterface it;
        private AI ai;
        // Variables initiated at one and zero
        private int currentTurn = 1;
        private int agentIndex = 0;

        // Construtor of the class
        public GameManager(Config c) {
            config = c;
            // Created the world, userinterface and AI
            world = new World(c, rnd);
            it = new UserInterface(world, c);
            ai = new AI(c, world, rnd);
        }

        /// <summary>
        /// Method that will keep looping the game until the while condition is met
        /// </summary>
        public void GameLoop() {
            do {
                world.currentAgent = (world.agents[agentIndex] as Agent);
                currentTurn++;

                it.ShowWorld(world.Grid, world.currentAgent);
                if (world.currentAgent.Playable) {
                    it.WhereToMove(world.currentAgent, world);
                } else {
                    ai.SearchAgent();
                }

                agentIndex++;
                if (agentIndex >= world.agents.Length) {
                    agentIndex = 0;
                }
                
                Console.ReadKey();

                // Ends the game when it reaches the max turns and there's no more
                // humans
            } while (currentTurn <= config.MaxT && config.InitialHumans > 0);
        }
    }
}
