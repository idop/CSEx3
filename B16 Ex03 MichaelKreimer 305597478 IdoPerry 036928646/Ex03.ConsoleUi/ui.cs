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


        internal static float GetFloatFromUser(int v1, float v2)
        {
            throw new NotImplementedException();
        }

        internal static void PrintStringsList(List<string> i_VehiclesPlateNumbers)
        {
            foreach (string vehiclePlateNumber in i_VehiclesPlateNumbers)
            {
                Console.WriteLine(vehiclePlateNumber);
            }
        }
    }
}
