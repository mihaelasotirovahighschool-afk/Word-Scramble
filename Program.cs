using System;
using System.Windows.Forms;

namespace WordScrambleApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Тези два реда заместват проблемния Initialize() и конфигурират визията на прозорците
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Стартира твоята форма
            Application.Run(new IndexForm());
        }
    }
}