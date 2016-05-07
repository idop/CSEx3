using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class TruckModels 
    {
        public class FuelTruck : FuelVehicle
        {
            bool m_IsCarryingDangerousMaterials;
            float m_MaxCarryLoad;

            public FuelTruck(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, eFuelType i_FuelType, float i_MaxFuelCapacity, bool i_IsCarryingDangerousMaterials, float i_MaxCarryLoad) 
                : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_FuelType, i_MaxFuelCapacity)
            {
                m_IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials;
                m_MaxCarryLoad = i_MaxCarryLoad;
            }

            public FuelTruck(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, eFuelType i_FuelType, float i_MaxFuelCapacity, float i_initialFuel, bool i_IsCarryingDangerousMaterials, float i_MaxCarryLoad)
              : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_FuelType, i_MaxFuelCapacity , i_initialFuel)
            {
                m_IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials;
                m_MaxCarryLoad = i_MaxCarryLoad;
            }
        }
    }
}
