using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Tier
    {
        private const int k_MinValueAllowed = 0;
        private readonly string r_ManufacturerName;
    
        public string ManufacturerName
        {
            get
            {
                return r_ManufacturerName;
            }
        }

        private float m_CurrentAirPressure =0f;

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        private readonly float r_MaxAllowedAirPressure;

        public Tier(string i_ManufacturerName, float i_MaxAllowedAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaxAllowedAirPressure = i_MaxAllowedAirPressure;
        }

        public Tier(string i_ManufacturerName, float i_MaxAllowedAirPressure,float i_StartingAirPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            r_MaxAllowedAirPressure = i_MaxAllowedAirPressure;
            m_CurrentAirPressure = 0;
            AddAirPressure(i_StartingAirPressure);
        }

        public void AddAirPressure(float i_AirToAdd)
        {
            float newAirPressure = i_AirToAdd + m_CurrentAirPressure;
            if (newAirPressure > r_MaxAllowedAirPressure)
            {
                m_CurrentAirPressure = newAirPressure;
            }
            else
            {
                float maxValueAllowd = r_MaxAllowedAirPressure - m_CurrentAirPressure;
                throw new ValueOutOfRangeException(k_MinValueAllowed, maxValueAllowd);
            }
        }

        public Tier Clone()
        {
            return MemberwiseClone() as Tier;
        }
    }
}
