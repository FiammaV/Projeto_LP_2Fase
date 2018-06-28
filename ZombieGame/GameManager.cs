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
        private AI ai;

        public int MaxT { get; }

        //construtor 
        public GameManager (Config c) {
            config = c;
            world = new World(c);
            it = new UserInterface();
            ai = new AI(c, world);
        }

        public void GameLoop()
        {
            do {
                it.ShowWorld(world.Grid);
                ai.SearchAgent();
                Console.ReadKey();
            } while (2 != 3);
        }
    }
}
