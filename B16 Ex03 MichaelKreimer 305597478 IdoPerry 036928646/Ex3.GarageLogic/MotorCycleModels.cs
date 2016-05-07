using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class MotorCycleModels 
    {
        public enum eLicenseType
        {
            A,
            A1,
            AB,
            B1
        }

        public class FuelMotorCycle : FuelVehicle
        {
            private eLicenseType m_LicenseType;
            private int m_EngineDisplacement;

            public FuelMotorCycle(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, eFuelType i_FuelType, float i_MaxFuelCapacity, eLicenseType i_LicenseType, int i_EngineDisplacement) 
                : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_FuelType, i_MaxFuelCapacity)
            {
                m_EngineDisplacement = i_EngineDisplacement;
                m_LicenseType = i_LicenseType;
            }

            public FuelMotorCycle(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, eFuelType i_FuelType, float i_MaxFuelCapacity, float i_initialFuel, eLicenseType i_LicenseType, int i_EngineDisplacement)
    : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_FuelType, i_MaxFuelCapacity , i_initialFuel)
            {
                m_EngineDisplacement = i_EngineDisplacement;
                m_LicenseType = i_LicenseType;
            }
        }
        public class ElectricMotorCycle : ElectricVehicle
        {
            private eLicenseType m_LicenseType;
            private int m_EngineDisplacement;

            public ElectricMotorCycle(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, float i_MaxHoursOfPower, eLicenseType i_LicenseType, int i_EngineDisplacement)
                : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_MaxHoursOfPower)
            {
                m_EngineDisplacement = i_EngineDisplacement;
                m_LicenseType = i_LicenseType;
            }
            public ElectricMotorCycle(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, float i_MaxHoursOfPower, float i_InitalHoursOfPower, eLicenseType i_LicenseType, int i_EngineDisplacement)
                : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_MaxHoursOfPower, i_InitalHoursOfPower)
            {
                m_EngineDisplacement = i_EngineDisplacement;
                m_LicenseType = i_LicenseType;
            }
        }
    }
}
