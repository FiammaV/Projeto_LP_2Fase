using System;

namespace ZombieGame {
    /// <summary>
    /// Class that draws the menu
    /// </summary>
    class Menu {
        // Initialization of the other classes
        private GameManager gameManager;
        private Config c;
        // Array of strings
        private string[] args;

        /// <summary>
        /// Contructor of the menu
        /// </summary>
        /// <param name="args"></param>
        public Menu(string[] args) {
            this.args = args;
        }
        /// <summary>
        /// Method that draws the menu
        /// </summary>
        public void DrawMenu() {
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

            // Returns the string of the method "Options"
            Options(Console.ReadLine());
        }

        /// <summary>
        /// Reads input of the player
        /// </summary>
        /// <param name="option"></param>
        private void Options(string option) {
            switch (option) {
                case "1":
                    c = new Config(args);
                    gameManager = new GameManager(c);
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
        /// Method that draws info of the rules
        /// </summary>
        public void Rules() {
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
        /// Method that draws info of Credits
        /// </summary>
        public void Credits() {
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
