namespace ZombieGame {
    public class World {

        private IGameObject[] agents;
        private IGameObject[,] grid;

        public World(Config c) {
            agents = new IGameObject[c.InitialHumans + c.InitialZombies];
        }
    }
}