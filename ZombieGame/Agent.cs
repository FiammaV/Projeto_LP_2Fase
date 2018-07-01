namespace ZombieGame {
    /// <summary>
    /// Class responsible for the agents
    /// </summary>
    public class Agent : IGameObject {
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
        /// Construtor of the class
        /// </summary>
        /// <param name="agent"></param>
        public Agent(AgentType agent, int index)
        {
            Type = agent;
            Index = index;
        }

        /// <summary>
        /// Override of the method ToString() to write the name of the agent
        /// the way we want it
        /// </summary>
        /// <returns></returns>
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
