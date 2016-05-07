using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        private string m_ModelName;

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
        }

        private string m_LicensePlate;

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
        }

        public virtual float EnergyMeterPercentage
        {
            get;
        }

        private List<Tier> m_Tiers;

        public int NumberOfTiers
        {
            get
            {
                return m_Tiers.Count;
            }
        }

        public List<Tier> Tiers 
        {
            get
            {
                return m_Tiers;
            }
        }

        public override int GetHashCode()
        {
            return m_LicensePlate.GetHashCode();
        }

        public Vehicle (string i_ModelName , string i_LicensePlate , int i_NumberOfTires, Tier i_Tier)
        {
            m_ModelName = i_ModelName;
            m_LicensePlate = i_LicensePlate;
            m_Tiers = new List<Tier>(i_NumberOfTires);
            for (int i = 0; i < i_NumberOfTires; ++i)
            {
                m_Tiers.Add(i_Tier.Clone()) ;
            }

        }
        public override bool Equals(object obj)
        {
            bool equals = false;
            Vehicle vehicleToCompereTo = obj as Vehicle;

            if (vehicleToCompereTo != null)
            {
                equals = this.m_LicensePlate == vehicleToCompereTo.LicensePlate;
            }

            return equals;
        }

        public static bool operator ==(Vehicle a , Vehicle b)
        {
            bool equals = false;
            if (System.Object.ReferenceEquals(a, b))
            {
                equals= true;
            }
            else if (((object)a == null) || ((object)b == null))
            {
                equals = false;
            }
            else
            {
                equals = a.LicensePlate == b.LicensePlate;
            }

            return equals;
        }
        public static bool operator !=(Vehicle a, Vehicle b)
        {
            return !(a == b);
        }
    }
}
