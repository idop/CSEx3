using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    public class Vehicle
    {
        private string m_ModelName;

        private string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        public string m_LicensePlate;

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
        }

        float m_EnergyMeterPercentage;

        public float EnergyMeterPercentage
        {
            get
            {
                return m_EnergyMeterPercentage;
            }
        }

        private List<Tier> Tiers;
        private Engine m_Engine;
    }
}
