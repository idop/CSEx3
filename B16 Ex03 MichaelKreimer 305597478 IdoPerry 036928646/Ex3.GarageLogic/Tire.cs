using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        public const float k_MinValueAllowed = 0f;
        private readonly float r_MaxAllowedAirPressure = 0f;
        private readonly string r_ManufacturerName = string.Empty;
        private float m_CurrentAirPressure = 0f;

        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public Tire(string i_ManufacturerName, float i_MaxAllowedAirPressure, float i_StartingAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaxAllowedAirPressure = i_MaxAllowedAirPressure;
            m_CurrentAirPressure = 0;
            AddAirPressure(i_StartingAirPressure);
        }

        public void AddAirPressure(float i_AirToAdd)
        {
            float newAirPressure = i_AirToAdd + m_CurrentAirPressure;
            if (newAirPressure <= r_MaxAllowedAirPressure)
            {
                m_CurrentAirPressure = newAirPressure;
            }
            else
            {
                float maxValueAllowd = r_MaxAllowedAirPressure - m_CurrentAirPressure;
                throw new ValueOutOfRangeException(k_MinValueAllowed, maxValueAllowd);
            }
        }

        public Tire Clone()
        {
            return MemberwiseClone() as Tire;
        }

        internal float calcAirPressureLeftToFill()
        {
            return r_MaxAllowedAirPressure - m_CurrentAirPressure;
        }

        public override string ToString()
        {
            string toString = string.Format(
@"Manufactorer name: {0}
Current air pressure: {1}
Maximum allowed air pressure: {2}",
r_ManufacturerName,
m_CurrentAirPressure,
r_MaxAllowedAirPressure);

            return toString;
        }
    }
}
