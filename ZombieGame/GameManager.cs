using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    class GameManager {
        private Config config;
       

        public GameManager (Config c) {
            config = c;
        }

        public void Start()
        {
            World world = new World(c);
        }
    }
}
