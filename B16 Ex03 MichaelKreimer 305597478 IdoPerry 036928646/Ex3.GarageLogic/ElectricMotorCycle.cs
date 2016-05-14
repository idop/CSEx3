using Ex03.GarageLogic;
using System.Collections.Generic;

namespace Ex03.GarageLogic.MotorCycleModels
{
    public class ElectricMotorCycle : ElectricVehicle
    {
        private MotorCycleProperties m_MotorCycleProperties;

        public ElectricMotorCycle(string i_LicensePlate, string i_ModelName, List<Tire> i_Tiers, float i_MaxHoursOfPower, MotorCycleProperties.eLicenseType i_LicenseType, int i_EngineDisplacement)
            : base(i_LicensePlate, i_ModelName, i_Tiers, i_MaxHoursOfPower)
        {
            m_MotorCycleProperties = new MotorCycleProperties(i_LicenseType, i_EngineDisplacement);
        }
        public ElectricMotorCycle(string i_LicensePlate, string i_ModelName, List<Tire> i_Tiers, float i_MaxHoursOfPower, float i_InitalHoursOfPower, MotorCycleProperties.eLicenseType i_LicenseType, int i_EngineDisplacement)
            : base(i_LicensePlate, i_ModelName, i_Tiers, i_MaxHoursOfPower, i_InitalHoursOfPower)
        {
            m_MotorCycleProperties = new MotorCycleProperties(i_LicenseType, i_EngineDisplacement);
        }
    }
}
