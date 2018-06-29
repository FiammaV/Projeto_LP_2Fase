using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    class Playable {
        private World world;
        private Agent currentAgent;


        public Playable(World world, Agent current) {
            this.world = world;
            currentAgent = current;
        }

        public void MoveNorth() {

        }

        public void MoveSouth() {

        }

        public void MoveEast() {

        }

        public void MoveWest() {

        }

        public void Infect() {

        }
    }
}
