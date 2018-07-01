using System;

namespace ZombieGame {
    /// <summary>
    /// Class that gets the value of the arguments of the console and sets up
    /// the properties accordingly
    /// </summary>
    public class Config {
        /// <summary>
        /// Properties of InitialHumans
        /// </summary>
        public int InitialHumans { get; set; }
        /// <summary>
        /// Properties of InitialZombies
        /// </summary>
        public int InitialZombies { get; }
        /// <summary>
        /// Properties of row
        /// </summary>
        public int Row { get; }
        /// <summary>
        /// Properties of column
        /// </summary>
        public int Column { get; }
        /// <summary>
        /// Properties of ControlHumans
        /// </summary>
        public int ControlHumans { get; }
        /// <summary>
        /// Properties of ControlZombies
        /// </summary>
        public int ControlZombies { get; }
        /// <summary>
        /// Properties of max turns
        /// </summary>
        public int MaxT { get; }

        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="args"></param>
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
