using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    /// <summary>
    /// Agent implement IGameObject
    /// </summary>
    public class Agent : IGameObject {
       // Properties
        public int Column { get; }
        public int Row { get; }
        public AgentType Type { get; set; }
        public bool Playable { get; set; }

        // Empty constructor 
        public Agent(AgentType agent)
        {
        }
    }
}
