using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    class Config {
        public string ControlHumans { get; set; }
        public string InitialZombies { get; set; }
        public string WorldX { get; set; }
        public string WorldY { get; set; }
        public string ControlHuman { get; set; }
        public string ControlZombies { get; set; }
        public string MaxT { get; set; }
        public string[] args = new string[] { "-x", "8", "-y", "8", "-h", "2",
            "-z", "20", "-H", "1", "-Z", "1", "-t", "20" };

        public Config(string[] args) {
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
                        ControlHumans = (args[i + 1]);
                        Console.WriteLine(ControlHumans);
                        break;
                    case "-z":
                        InitialZombies = (args[i + 1]);
                        Console.WriteLine(InitialZombies);
                        break;
                    case "-H":
                        ControlHumans = (args[i + 1]);
                        Console.WriteLine(ControlHuman);
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
