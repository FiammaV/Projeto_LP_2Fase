using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    public class Config {
        /// <summary>
        /// Proprieties of each argument
        /// </summary>
        public string InitialHumans { get; }
        public string InitialZombies { get; }
        public string WorldX { get; }
        public string WorldY { get; }
        public string ControlHumans { get; }
        public string ControlZombies { get; }
        public string MaxT { get; }
        //public string[] args = new string[] { "-x", "8", "-y", "8", "-h", "2",
        //    "-z", "20", "-H", "1", "-Z", "1", "-t", "1000" };

        public Config(string[] args) {
            // A for that will run through the arguments' array
            for (int i = 0; i < args.Length; i += 2) {
                switch (args[i]) {
                    case "-x":
                        WorldX = (args[i + 1]);
                        Console.WriteLine(WorldX);
                        break;
                    case "-y":
                        WorldY = (args[i + 1]);
                        Console.WriteLine(WorldY);
                        break;
                    case "-h":
                        InitialHumans = (args[i + 1]);
                        Console.WriteLine(InitialHumans);
                        break;
                    case "-z":
                        InitialZombies = (args[i + 1]);
                        Console.WriteLine(InitialZombies);
                        break;
                    case "-H":
                        ControlHumans = (args[i + 1]);
                        Console.WriteLine(ControlHumans);
                        break;
                    case "-Z":
                        ControlZombies = (args[i + 1]);
                        Console.WriteLine(ControlZombies);
                        break;
                    case "-t":
                        MaxT = (args[i + 1]);
                        Console.WriteLine(MaxT);
                        break;
                    default:
                        Console.WriteLine("You've done goof");
                        break;
                }
            }
        }
    }
}
