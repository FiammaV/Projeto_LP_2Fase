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
            Console.OutputEncoding = Encoding.UTF8;

            Config c = new Config(args);

            // Declaration/ initiate the menu
            Menu menu = new Menu(args);

            // Initiate DrawMenu
            menu.DrawMenu();
        }
    }
}
