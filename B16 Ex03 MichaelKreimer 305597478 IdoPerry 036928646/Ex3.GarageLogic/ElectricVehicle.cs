using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle : Vehicle
    {
        public const int k_MinValueAllowed = 0;
        private float m_CurrentHoursOfPower = 0;
        private readonly float r_MaxHoursOfPower;

        public float HoursOfPower
        {
            get
            {
                return m_CurrentHoursOfPower;
            }
        }
        public override string ToString()
        {
            StringBuilder toString = new StringBuilder(base.ToString());
            toString.Append(Environment.NewLine);
            toString.AppendFormat(
@"Current Power in hours: {0}
Maxmium hours of power: {1}
Power Precentage {2:P1}",
m_CurrentHoursOfPower,
r_MaxHoursOfPower,
EnergyMeterPercentage);

            return toString.ToString();
        }

        public ElectricVehicle(string i_LicensePlate, string i_ModelName, List<Tire> i_Tiers, float i_MaxHoursOfPower, float i_InitalHoursOfPower)
            : base(i_LicensePlate, i_ModelName, i_Tiers)
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
            float newPowerAmount = i_HoursOfPowerToAdd + m_CurrentHoursOfPower;
            if (newPowerAmount <= r_MaxHoursOfPower)
            {
                m_CurrentHoursOfPower = newPowerAmount;
            }
            else
            {
                float maxValueAllowd = r_MaxHoursOfPower - m_CurrentHoursOfPower;
                throw new ValueOutOfRangeException(k_MinValueAllowed, maxValueAllowd);
            }
        }
    }
}
