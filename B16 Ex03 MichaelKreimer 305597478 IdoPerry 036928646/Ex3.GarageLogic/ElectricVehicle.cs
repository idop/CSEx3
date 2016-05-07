using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle : Vehicle
    {
        private const int k_MinValueAllowed = 0;
        private float m_CurrentHoursOfPower = 0;
        private readonly float r_MaxHoursOfPower;

        public ElectricVehicle(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, float i_MaxHoursOfPower)
            : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier)
        {
            r_MaxHoursOfPower = i_MaxHoursOfPower;
        }

        public ElectricVehicle(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tier, float i_MaxHoursOfPower, float i_InitalHoursOfPower)
            : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tier)
        {
            r_MaxHoursOfPower = i_MaxHoursOfPower;
            Charge(i_InitalHoursOfPower);
        }

        public override float EnergyMeterPercentage
        {
            get
            {
                return m_CurrentHoursOfPower / r_MaxHoursOfPower;
            }
        }

        public void Charge(float i_HoursOfPowerToAdd)
        {
            float newFuelAmount = i_HoursOfPowerToAdd + m_CurrentHoursOfPower;
            if (newFuelAmount > r_MaxHoursOfPower)
            {
                m_CurrentHoursOfPower = newFuelAmount;
            }
            else
            {
                float maxValueAllowd = r_MaxHoursOfPower - m_CurrentHoursOfPower;
                throw new ValueOutOfRangeException(k_MinValueAllowed, maxValueAllowd);
            }
        }
    }
}
