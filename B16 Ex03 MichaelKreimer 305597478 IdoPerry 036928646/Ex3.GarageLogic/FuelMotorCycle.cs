﻿

namespace Ex03.GarageLogic.MotorCycleModels
{
    public class FuelMotorCycle : FuelVehicle
    {
        private MotorCycleProperties m_MotorCycleProperties;

        public FuelMotorCycle(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, eFuelType i_FuelType, float i_MaxFuelCapacity, MotorCycleProperties.eLicenseType i_LicenseType, int i_EngineDisplacement)
            : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_FuelType, i_MaxFuelCapacity)
        {
            m_MotorCycleProperties = new MotorCycleProperties(i_LicenseType, i_EngineDisplacement);
        }

        public FuelMotorCycle(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, eFuelType i_FuelType, float i_MaxFuelCapacity, float i_initialFuel, MotorCycleProperties.eLicenseType i_LicenseType, int i_EngineDisplacement)
: base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_FuelType, i_MaxFuelCapacity, i_initialFuel)
        {
            m_MotorCycleProperties = new MotorCycleProperties(i_LicenseType, i_EngineDisplacement);
        }
    }
}
