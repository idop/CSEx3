using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string r_LicensePlate;
        private string r_ModelName;

        public override string ToString()
        {
            int tireIndex = 0;
            StringBuilder toString = new StringBuilder();
            toString.AppendFormat(
@"Model Name: {0}
License Plate: {1}",
r_ModelName,
r_LicensePlate);

            foreach (Tire tire in m_Tiers)
            {
                toString.AppendFormat("{0} Tire {1} informaiton:", Environment.NewLine, ++tireIndex);
                toString.Append(tire.ToString());
            }

            return toString.ToString();
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicensePlate
        {
            get
            {
                return r_LicensePlate;
            }
        }

        public virtual float EnergyMeterPercentage
        {
            get;
        }

        private List<Tire> m_Tiers;

        public int NumberOfTiers
        {
            get
            {
                return m_Tiers.Count;
            }
        }

        public List<Tire> Tires 
        {
            get
            {
                return m_Tiers;
            }
        }

        public override int GetHashCode()
        {
            return r_LicensePlate.GetHashCode();
        }

        public Vehicle ()
        {

        }

        public Vehicle (string i_LicensePlate, string i_ModelName,  List<Tire> i_Tiers)
        {
            r_LicensePlate = i_LicensePlate;
            r_ModelName = i_ModelName;
            m_Tiers = i_Tiers;
        }
        public override bool Equals(object obj)
        {
            bool equals = false;
            Vehicle vehicleToCompereTo = obj as Vehicle;

            if (vehicleToCompereTo != null)
            {
                equals = this.r_LicensePlate == vehicleToCompereTo.LicensePlate;
            }

            return equals;
        }

        public static bool operator ==(Vehicle a , Vehicle b)
        {
            bool equals = false;
            if (object.ReferenceEquals(a, b))
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
