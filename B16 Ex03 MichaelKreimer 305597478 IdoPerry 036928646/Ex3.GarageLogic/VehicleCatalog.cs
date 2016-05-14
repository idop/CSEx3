using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleCatalog
    {
        private const int k_MinEnumValue = 0;
        private const int k_MaxEnumValue = 4;
        public enum eVehicleCatalog
        {
            FuelMotorCycle,
            ElectricMotorCycle,
            FuelCar,
            ElectricCar,
            Truck
        }

        public static string GetVehicleCatalogUiDisplay()
        {
            string vehicleCatalogUiDisplay = string.Format(
@"{0} - Regular Bike
{1} - Electric Bike
{2} - Regular Car
{3} - Electric Car 
{4} - Truck",
(int)eVehicleCatalog.FuelMotorCycle,
(int)eVehicleCatalog.ElectricMotorCycle,
(int)eVehicleCatalog.FuelCar,
(int)eVehicleCatalog.ElectricCar,
(int)eVehicleCatalog.Truck);

            return vehicleCatalogUiDisplay;
        }

        public static eVehicleCatalog GetOption(string i_Input)
        {
            return GarageUtils.GetEnumOption<eVehicleCatalog>(i_Input, k_MinEnumValue, k_MaxEnumValue);
        }
    }
}
