using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    public class Agent : IGameObject {
        public int Column { get; set; }
        public int Row { get; set; }
        public AgentType Type { get; set; }
        public bool Playable { get; set; }
    }
}
