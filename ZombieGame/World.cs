namespace ZombieGame {
    public class World {

        private IGameObject[] agents;
        private IGameObject[,] grid;
        public int Row { get; set; }
        public int Column { get; set; }

        public World(Config c) {
            agents = new IGameObject[c.InitialHumans + c.InitialZombies];

            grid = new IGameObject[Row, Column];

            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    grid[i, j] = new Empty();
                }
            }

            UserInterface it = new UserInterface();
            it.ShowWorld(grid);
        }
    }
}