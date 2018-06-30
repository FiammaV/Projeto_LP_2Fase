using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieGame
{
    /// <summary>
    /// Construction of the game
    /// </summary>
    class Menu
    {
        // Declaration of the game
        private GameManager gameManager;

        private Config c;

        /// <summary>
        /// Contructor iniciates the game (nao devolve nada MAS pode receber se tiveres cenas entre parentises)
        /// </summary>
        /// <param name="c"></param>
        public Menu(Config c)
        {
            gameManager = new GameManager(c);
        }
        /// <summary>
        /// Draw's info of DrawMenu
        /// </summary>
        public void DrawMenu()
        {
            // Clear console
            Console.Clear();
            Console.WriteLine(" ╓━━━━━━━━━━━━━━━━━━━━━━━━╖");
            Console.WriteLine(" ║    ZombieApocalypse    ║");
            Console.WriteLine(" ║━━━━━━━━━━━━━━━━━━━━━━━━║");
            Console.WriteLine(" ║       1  Game          ║");
            Console.WriteLine(" ║       2  Rules         ║");
            Console.WriteLine(" ║       3  Credits       ║");
            Console.WriteLine(" ║       4  Exit          ║");
            Console.WriteLine(" ╙━━━━━━━━━━━━━━━━━━━━━━━━╜");

            // Return the string of method "Options"
            Options(Console.ReadLine());
        }
        /// <summary>
        /// Read input of player
        /// </summary>
        /// <param name="option"></param>
        private void Options(string option)
        {
            switch (option)
            {
                case "1":
                    Console.Clear();
                    gameManager.GameLoop();
                    break;
                case "2":
                    Rules();
                    break;

                case "3":
                    Credits();
                    break;

                case "4":
                    Environment.Exit(0);
                    break;
            }
            DrawMenu();
        }
        /// <summary>
        /// Draw's info of Rules
        /// </summary>
        public void Rules()
        {
            Console.Clear();
            Console.WriteLine("╓━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╖");
            Console.WriteLine("║                                Rules                                ║");
            Console.WriteLine("║━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━║");
            Console.WriteLine("║   Agent    ║   Color   ║   Current Player   ║   Controlled Player   ║");
            Console.WriteLine("║━━━━━━━━━━━━║━━━━━━━━━━━║━━━━━━━━━━━━━━━━━━━━║━━━━━━━━━━━━━━━━━━━━━━━║");
            Console.WriteLine("║   Human    ║   Green   ║                    ║         Blue          ║");
            Console.WriteLine("║━━━━━━━━━━━━║━━━━━━━━━━━║       Yellow       ║━━━━━━━━━━━━━━━━━━━━━━━║");
            Console.WriteLine("║   Zombie   ║    Red    ║                    ║        Magenta        ║");
            Console.WriteLine("╙━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╜");
            Console.WriteLine("  ");
            Console.ReadKey();
        }
        /// <summary>
        /// Draw's info of Credits
        /// </summary>
        public void Credits()
        {
            Console.Clear();
            Console.WriteLine(" ╓━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╖");
            Console.WriteLine(" ║              Credits            ║");
            Console.WriteLine(" ║━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━║");
            Console.WriteLine(" ║  ♫  Inês Gonçalves  nº21702076  ║");
            Console.WriteLine(" ║  ♪  Inês Nunes      nº21702520  ║");
            Console.WriteLine(" ║  ♫  Sara Gama       nº21705494  ║");
            Console.WriteLine(" ╙━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━╜");
            // Reads the input of the player
            Console.ReadKey();
        }
    }
}
