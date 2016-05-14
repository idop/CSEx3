using System;

namespace Ex03.ConsoleUi.Menus
{

    public class MainMenu
    {
        public const int k_MinEnumValue = 0;
        public const int k_MaxEnumValue = 7;
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
@"Welcome to the garage managment program. please select your action:
{0} - to enter a new Vehicle
{1} - to find all vehicle by status
{2} - to change vehicle status
{3} - to inflate vehicle tiers to maximun allowed
{4} - to add Fuel to fuel based vehicle
{5} - to charge electric vehicle
{6} - to Print vehicle details
{7} - to exit",
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
