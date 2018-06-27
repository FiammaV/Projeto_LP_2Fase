using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    public class GameManager {
        private Config config;

        public int MaxT { get; }

        //construtor 
        public GameManager()
        {
            Menu menu = new Menu();
        }

        public GameManager (Config c) {
            config = c;
        }

        public void Start(Config c)
        {
            World world = new World(c);
        }

        private void GameLoop(World world, UserInterface it, IGameObject[,] grid)
        {
            for (int i = 0; (i > MaxT) || (AgentType.Human == 0);)
            {
                world.Shuffle();
                it.ShowWorld(grid);
            }
        }
    }
}
