using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUi
{
    internal static class Menus
    {
        internal class MainMenu
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
        }

        internal class FindVehicleSubMenu
        {
            internal enum eMainMenu
            {
                All,
                InRepair,
                Repaired,
                PaidFor,
                ReturnToMainMenu
            }
        }
    }
}
