using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    public class GameManager {
        Random rnd = new Random();
        private Config config;
        private World world;
        private UserInterface it;
        private AI ai;
        private Playable playable;
        

        private int agentIndex = 0;

        public int MaxT { get; }

        //construtor 
        public GameManager(Config c) {
            config = c;
            world = new World(c, rnd);
            it = new UserInterface(world);
            ai = new AI(c, world, rnd);
            playable = new Playable(world, world.currentAgent);
        }

        public void GameLoop() {
            do {
                world.currentAgent = (world.agents[agentIndex] as Agent);

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

                // Update current Agent
                ai = new AI(config, world, rnd);

                Console.ReadKey();
            } while (2 != 3);
        }
    }
}
