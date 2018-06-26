using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    class GameManager {
        private Config config;

        public int MaxT { get; }

        public GameManager (Config c) {
            config = c;
        }

        public void Start()
        {
            World world = new World(c);
        }

        private void GameLoop(World world, UserInterface it)
        {
            for (int i = 0; (i > MaxT) || (AgentType.Human == 0);)
            {
                world.Shuffle();
            }
        }
    }
}
