using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Garage
    {
        public enum eVehicleStatus
        {

        }
        private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();

        public void InsertVehicle(Vehicle io_Vehicle)
        {
            //1 - TODO
        }
        public void DisplayVehiclesById()
        {
            //2 - TODO 
            // change signature
        }
        public void ChangeVehicleStatus(Vehicle io_Vehicle)
        {
            //3 - TODO
            // change signature
        }
        public void FillTires(string i_VehicleID, )
        {
            //4 - TODO
            // change signature
        }
        public void FillGasVehicle()
        {
            //5 - TODO
            // change signature
        }
        public void ChargeElectricVehicle()
        {
            //6 - TODO
            // change signature
        }
        public void DisplayVehicleData()
        {
            //7 - TODO
            // change signature
        }

    }
}
