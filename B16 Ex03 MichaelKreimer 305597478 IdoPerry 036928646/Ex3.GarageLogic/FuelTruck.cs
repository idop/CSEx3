using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.TruckModels
{
    public class FuelTruck : FuelVehicle
    {
        private TruckProperties m_TruckProperties;

        public FuelTruck(string i_ModelName, string i_LicensePlate, List<Tire> i_Tiers, FuelTypes.eFuelType i_FuelType, float i_MaxFuelCapacity, bool i_IsCarryingDangerousMaterials, float i_MaxCarryLoad)
            : base(i_ModelName, i_LicensePlate, i_Tiers, i_FuelType, i_MaxFuelCapacity)
        {
            m_TruckProperties = new TruckProperties(i_IsCarryingDangerousMaterials, i_MaxCarryLoad);
        }

        public FuelTruck(string i_ModelName, string i_LicensePlate, List<Tire> i_Tiers, FuelTypes.eFuelType i_FuelType, float i_MaxFuelCapacity, float i_initialFuel, bool i_IsCarryingDangerousMaterials, float i_MaxCarryLoad)
          : base(i_ModelName, i_LicensePlate, i_Tiers, i_FuelType, i_MaxFuelCapacity, i_initialFuel)
        {
            m_TruckProperties = new TruckProperties(i_IsCarryingDangerousMaterials, i_MaxCarryLoad);
        }
    }
}
