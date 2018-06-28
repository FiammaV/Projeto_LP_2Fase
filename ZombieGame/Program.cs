using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame {
    /// <summary>
    /// It create instances of Config and GameManager 
    /// </summary>
    public class Program {
        static void Main(string[] args) {

            Config c = new Config(args);

            GameManager game = new GameManager(c);
            game.GameLoop();
        }
    }
}
