using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.CarModels
{

    public class ElectricCar : ElectricVehicle
    {
        private CarProperties m_CarProperties;

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + m_CarProperties.ToString();
        }

        public ElectricCar(string i_LicensePlate, string i_ModelName, List<Tire> i_Tiers, float i_MaxHoursOfPower, float i_InitialHoursOfPower, CarProperties.eNumberOfDoors i_NumberOfDoors, CarProperties.eColors i_Color)
        : base(i_LicensePlate, i_ModelName, i_Tiers, i_MaxHoursOfPower, i_InitialHoursOfPower)
        {
            m_CarProperties = new CarProperties(i_NumberOfDoors, i_Color);
        }
    }
}
