using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    class Config {
        public string InitialHumans { get; }
        public string InitialZombies { get; }
        public Config[,] command = ["-x", "-y", "-h", "-z", "-H", "-Z", "-t"];

        public Config (string[] args) {
            for (int i = 0; i < args.Length; i += 2) {
                switch (args[i]) {
                    case "-h":
                        InitialHumans = Convert.ToInt32(args[i + 1]);
                }
            }
        }
    }
}
