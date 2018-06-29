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

        // Contructor iniciates the game (nao devolve nada MAS pode receber se tiveres cenas entre parentises)
        public Menu(Config c)
        {
            gameManager = new GameManager(c);
        }

        public void DrawMenu()
        {
            // Clear console
            Console.Clear();
            Console.WriteLine(" ╓━━━━━━━━━━━━━━━━━━━━━━━━━━╖");
            Console.WriteLine(" ║     ZombieApocalypse     ║");
            Console.WriteLine(" ║˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭║");
            Console.WriteLine(" ║      1  Game     ♚       ║");
            Console.WriteLine(" ║      2  Credits  ☰       ║");
            Console.WriteLine(" ║      3  Exit     ✈       ║");
            Console.WriteLine(" ╙˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭˭╜");

            // Return the string of method "Options"
            Options(Console.ReadLine());
        }

        private void Options(string option)
        {
            switch (option)
            {
                case "1":
                    Console.Clear();
                    gameManager.GameLoop();
                    break;

                case "2":
                    Credits();
                    break;

                case "3":
                    Environment.Exit(0);
                    break;
            }
        }

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
