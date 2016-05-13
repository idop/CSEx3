using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUi
{
    static class UI
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine(Menus.MainMenu.GetMainMenuUiDisplay());
        }

        internal static int GetIntegerFromUser(int i_MinRange, int i_MaxRange)
        {

            throw new NotImplementedException();
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
