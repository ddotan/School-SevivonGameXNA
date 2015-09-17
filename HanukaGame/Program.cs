using System;

namespace HanukaGame
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {
            using (HanukaGame game = new HanukaGame())
            {
                game.Run();
            }
        }
    }
}