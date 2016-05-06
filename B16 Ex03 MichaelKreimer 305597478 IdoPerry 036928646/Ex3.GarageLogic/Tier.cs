﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    public class Tier
    {
        private const string k_ValueOutOfRangeMessage = "Adding {0} to current {1} air pressure excceds {3) the maximum allowed";
        private string m_ManufacturerName;

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
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
            m_ManufacturerName = i_ManufacturerName;
            r_MaxAllowedAirPressure = i_MaxAllowedAirPressure;
        }

        public void AddAirPressure(float i_AirToAdd)
        {
            float newAirPressure = i_AirToAdd + m_CurrentAirPressure;
            if(newAirPressure > r_MaxAllowedAirPressure)
            {
                m_CurrentAirPressure = newAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(string.Format(k_ValueOutOfRangeMessage, i_AirToAdd ,m_CurrentAirPressure, r_MaxAllowedAirPressure));
            }

        }
    }
}
