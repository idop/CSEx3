using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.MotorCycleModels
{
    public class ElectricMotorCycle : ElectricVehicle
    {
        private MotorCycleProperties m_MotorCycleProperties;

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + m_MotorCycleProperties.ToString();
        }

        public ElectricMotorCycle(string i_LicensePlate, string i_ModelName, List<Tire> i_Tiers, float i_MaxHoursOfPower, float i_InitalHoursOfPower, MotorCycleProperties.eLicenseType i_LicenseType, int i_EngineDisplacement)
            : base(i_LicensePlate, i_ModelName, i_Tiers, i_MaxHoursOfPower, i_InitalHoursOfPower)
        {
            m_MotorCycleProperties = new MotorCycleProperties(i_LicenseType, i_EngineDisplacement);
        }
    }
}
