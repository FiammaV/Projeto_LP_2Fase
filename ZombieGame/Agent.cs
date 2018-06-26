using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    public class Agent : IGameObject {
       
        public int Column { get; }
        public int Row { get; }
        public AgentType Type { get; set; }
        public bool Playable { get; set; }

        public Agent(AgentType agent)
        {
        }

    }
}
