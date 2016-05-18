using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUi
{
    internal static class UI
    {
        internal static void DisplayMainMenu()
        {
            Console.WriteLine(Menus.MainMenu.GetMainMenuUiDisplay());
        }

        internal static void ClearConsle()
        {
            Console.Clear();
        }

        internal static void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        internal static string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
