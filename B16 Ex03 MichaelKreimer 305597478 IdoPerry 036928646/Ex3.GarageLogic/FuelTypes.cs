using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class FuelTypes
    {
        private const int k_MinEnumValue = 0;
        private const int k_MaxEnumValue = 3;
        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }
        public static string GetFuelTypesUiDisplay()
        {
            string fuelTypesUiDisplay = string.Format(
@"{0} - Octan 95
{1} - Octan 96
{2} - Octan 98
{3} - Solar",
(int)eFuelType.Octan95,
(int)eFuelType.Octan96,
(int)eFuelType.Octan98,
(int)eFuelType.Soler);

            return fuelTypesUiDisplay;
        }

        public static eFuelType GetOption(string i_Input)
        {
            return GarageUtils.GetEnumOption<eFuelType>(i_Input, k_MinEnumValue, k_MaxEnumValue);
        }
    }
}
