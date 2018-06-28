using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    public class GameManager {
        private Config config;
        private World world;
        private UserInterface it;

        public int MaxT { get; }

        public GameManager (Config c) {
            config = c;
            world = new World(c);
            it = new UserInterface();
            world.Shuffle();
        }

        public void GameLoop()
        {
            do {
                it.ShowWorld(world.Grid);
                Console.ReadKey();
            } while (2 != 3);
        }
    }
}
