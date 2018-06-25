using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    public class Config {
        /// <summary>
        /// Properties of each argument
        /// </summary>
        public int InitialHumans { get; set; }
        public int InitialZombies { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int ControlHumans { get; set; }
        public int ControlZombies { get; set; }
        public int MaxT { get; set; }
        public IGameObject[,] grid;

        //public string[] args = new string[] { "-x", "8", "-y", "8", "-h", "2",
        //    "-z", "20", "-H", "1", "-Z", "1", "-t", "1000" };

        public Config(string[] args) {
            // A for that will run through the arguments' array
            for (int i = 0; i < args.Length; i += 2) {
                switch (args[i]) {
                    case "-x":
                        Row = Convert.ToInt32(args[i + 1]);
                        Console.WriteLine(Row);
                        break;
                    case "-y":
                        Column = Convert.ToInt32(args[i + 1]);
                        Console.WriteLine(Column);
                        break;
                    case "-h":
                        InitialHumans = Convert.ToInt32(args[i + 1]);
                        Console.WriteLine(InitialHumans);
                        break;
                    case "-z":
                        InitialZombies = Convert.ToInt32(args[i + 1]);
                        Console.WriteLine(InitialZombies);
                        break;
                    case "-H":
                        ControlHumans = Convert.ToInt32(args[i + 1]);
                        Console.WriteLine(ControlHumans);
                        break;
                    case "-Z":
                        ControlZombies = Convert.ToInt32(args[i + 1]);
                        Console.WriteLine(ControlZombies);
                        break;
                    case "-t":
                        MaxT = Convert.ToInt32(args[i + 1]);
                        Console.WriteLine(MaxT);
                        break;
                    default:
                        Console.WriteLine("You've done gridof");
                        break;
                }
            }

            grid = new IGameObject[Row, Column];

            for(int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Empty();
                }

            }

            Interface it = new Interface();
            it.ShowWorld(grid);
        }
    }
}
