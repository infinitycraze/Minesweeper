// Name: Liam Lidder
// Date: 8/7/2026
// Assignment: Final Project
// Description: The main entry point for the game. Nothing added here.

using System;
using System.Windows.Forms;

namespace Minesweeper
{
    internal static class main
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MinesweeperGame());
        }
    }
}
