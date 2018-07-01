using System;

namespace ZombieGame {
    /// <summary>
    /// Class that gets the value of the arguments of the console and sets up
    /// the properties accordingly
    /// </summary>
    public class Config {
        /// <summary>
        /// Properties of each argument
        /// </summary>
        public int InitialHumans { get; set; }
        public int InitialZombies { get; }
        public int Row { get; }
        public int Column { get; }
        public int ControlHumans { get; }
        public int ControlZombies { get; }
        public int MaxT { get; }

        public Config(string[] args) {
            // A for that will run through the arguments' array
            for (int i = 0; i < args.Length; i += 2) {
                switch (args[i]) {
                    case "-x":
                        Row = Convert.ToInt32(args[i + 1]);
                        break;
                    case "-y":
                        Column = Convert.ToInt32(args[i + 1]);
                        break;
                    case "-h":
                        InitialHumans = Convert.ToInt32(args[i + 1]);
                        break;
                    case "-z":
                        InitialZombies = Convert.ToInt32(args[i + 1]);
                        break;
                    case "-H":
                        ControlHumans = Convert.ToInt32(args[i + 1]);
                        break;
                    case "-Z":
                        ControlZombies = Convert.ToInt32(args[i + 1]);
                        break;
                    case "-t":
                        MaxT = Convert.ToInt32(args[i + 1]);
                        break;
                    default:
                        Console.WriteLine("You've done goof");
                        break;
                }
            }
        }
    }
}
