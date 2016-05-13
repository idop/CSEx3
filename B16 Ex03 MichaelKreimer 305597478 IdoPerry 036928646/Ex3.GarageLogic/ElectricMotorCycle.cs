

namespace Ex03.GarageLogic.MotorCycleModels
{
    public class ElectricMotorCycle : ElectricVehicle
    {
        private MotorCycleProperties m_MotorCycleProperties;

        public ElectricMotorCycle(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, float i_MaxHoursOfPower, MotorCycleProperties.eLicenseType i_LicenseType, int i_EngineDisplacement)
            : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_MaxHoursOfPower)
        {
            m_MotorCycleProperties = new MotorCycleProperties(i_LicenseType, i_EngineDisplacement);
        }
        public ElectricMotorCycle(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, float i_MaxHoursOfPower, float i_InitalHoursOfPower, MotorCycleProperties.eLicenseType i_LicenseType, int i_EngineDisplacement)
            : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier, i_MaxHoursOfPower, i_InitalHoursOfPower)
        {
            m_MotorCycleProperties = new MotorCycleProperties(i_LicenseType, i_EngineDisplacement);
        }
    }
}
