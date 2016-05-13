using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.CarModels
{

    public class ElectricCar : ElectricVehicle
    {
        private CarProperties m_CarProperties;

        public ElectricCar(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tire, float i_MaxHoursOfPower, CarProperties.eNumberOfDoors i_NumberOfDoors, CarProperties.eColors i_Color)
        : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tire, i_MaxHoursOfPower)
        {
            m_CarProperties = new CarProperties(i_NumberOfDoors, i_Color);
        }
        public ElectricCar(string i_ModelName, string i_LicensePlate, int i_NumberOfTires, Tire i_Tire, float i_MaxHoursOfPower, float i_InitialHoursOfPower, CarProperties.eNumberOfDoors i_NumberOfDoors, CarProperties.eColors i_Color)
        : base(i_ModelName, i_LicensePlate, i_NumberOfTires, i_Tire, i_MaxHoursOfPower, i_InitialHoursOfPower)
        {
            m_CarProperties = new CarProperties(i_NumberOfDoors, i_Color);
        }
    }
}
