using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    public class Agent : IGameObject {
       /// <summary>
       ///  Column of the grid
       /// </summary>
        public int Column { get; }
        /// <summary>
        /// Row of the grid
        /// </summary>
        public int Row { get; }
        /// <summary>
        /// Enumeration of agents types
        /// </summary>
        public AgentType Type { get; set; }
        /// <summary>
        /// A boolean to check if it's playable or not
        /// </summary>
        public bool Playable { get; set; }
        /// <summary>
        /// Index to indentify agents
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Initializes a new instance of the AgentType class
        /// </summary>
        /// <param name="agent"></param>
        public Agent(AgentType agent, int index)
        {
            Type = agent;
            Index = index;
        }

        public override string ToString() {
            string type = "";

            if(Type == AgentType.Human) {
                type = string.Format("Human (\u2663{0:d2})", Index);
            } else if (Type == AgentType.Zombie) {
                type = string.Format("Zombie (\u25B2{0:d2})", Index);
            }

            return type;
        }

        
    }
}
