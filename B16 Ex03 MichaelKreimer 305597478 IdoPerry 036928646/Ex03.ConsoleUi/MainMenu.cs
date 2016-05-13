using System;

namespace Ex03.ConsoleUi.Menus
{

    public class MainMenu
    {
        public enum eMainMenu
        {
            EnterNewVehicle,
            ShowFindVehicleByLicencePlateSubMenu,
            ChangeVehicleStatus,
            InflateVehicleTiresToMax,
            FuelVehicle,
            ChargeVehicle,
            PrintFullVehicleDetails,
            Exit
        }

        public static string GetMainMenuUiDisplay()
        {
            string menuDisplayString = string.Format(
@"Press {0} to enter a new Vehicle
Press {1} to find all vehicle by status
Press {2} to change vehicle status
Press {3} to inflate vehicle tiers to maximun allowed
Press {4} to add Fuel to fuel based vehicle
Press {5} to charge electric vehicle
Press {6} to Print vehicle details
Press {7} to exit",
(int) eMainMenu.EnterNewVehicle,
(int)eMainMenu.ShowFindVehicleByLicencePlateSubMenu,
(int) eMainMenu.ChangeVehicleStatus,
(int) eMainMenu.InflateVehicleTiresToMax,
(int) eMainMenu.FuelVehicle,
(int) eMainMenu.ChargeVehicle,
(int) eMainMenu.PrintFullVehicleDetails,
(int) eMainMenu.Exit);

            return menuDisplayString.ToString();
        }
        
    }
}
