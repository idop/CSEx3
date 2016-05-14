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

        internal static int GetIntegerFromUser(int i_MinRange, int i_MaxRange)
        {

            throw new NotImplementedException();
        }

        internal static void ClearConsle()
        {
            try
            {
                Console.Clear();
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine("Clearing Console failed, please contact you system administrator");
            }
        }

        internal static void PrintMessage(string msg)
        {
            throw new NotImplementedException();
        }

        internal static string GetStringFromUser()
        {
            throw new NotImplementedException();
        }

        internal static float GetFloatFromUser(int v1, float v2)
        {
            throw new NotImplementedException();
        }
    }
}
