using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();

        public void InsertVehicle(Vehicle vehicle)
        {
            m_Vehicles.Add(vehicle.LicensePlate, vehicle);
        }
        public bool IsVehicleAlreadyExists(string i_VehiclePlateNumber)
        {
            return m_Vehicles.ContainsKey(i_VehiclePlateNumber);
        }
        public List<string> DisplayVehiclesById(string i_VehicleId, Vehicle.eStatus i_VehicleStatus)
        {
            List<string> listOfVehiclesPlates = new List<string>();
            if (i_VehicleStatus.Equals(Vehicle.eStatus.All))
            {
                foreach (Vehicle vehicle in m_Vehicles.Values)
                {
                    listOfVehiclesPlates.Add(vehicle.LicensePlate);
                }
            }
            else
            {
                foreach(Vehicle vehicle in m_Vehicles.Values)
                {
                    if (vehicle.Status.Equals(i_VehicleStatus))
                    {
                        listOfVehiclesPlates.Add(vehicle.LicensePlate);
                    }
                }
            }
            return listOfVehiclesPlates;
        }
        public void ChangeVehicleStatus(string i_VehiclePlateNumber, Vehicle.eStatus i_NewVehicleStatus)
        {
            // notes : a) maybe change to private
            //         b) reconsider for throw exception
            Vehicle vehicleToChange;
            bool carExists;
            carExists = m_Vehicles.TryGetValue(i_VehiclePlateNumber, out vehicleToChange);
            if (carExists)
            {
                vehicleToChange.Status = i_NewVehicleStatus;
            }
        }
        public void FillTires(string i_VehiclePlateNumber)
        {
            Vehicle vehicleToFill;
            bool carExists;
            carExists = m_Vehicles.TryGetValue(i_VehiclePlateNumber, out vehicleToFill);
            if (carExists)
            {
                foreach (Tire tire in vehicleToFill.Tires)
                {
                    tire.AddAirPressure(tire.GetPressureLeftToFill());
                }
            }
        }
        public void addGasToVehicle(string i_VehiclePlateNumber, FuelVehicle.eFuelType i_FuelType, float i_FuelToAdd)
        {
            // note: * add range exception
            Vehicle vehicleToFill;
            FuelVehicle fuelVehicleToFill;
            bool carExists;
            carExists = m_Vehicles.TryGetValue(i_VehiclePlateNumber, out vehicleToFill);
            fuelVehicleToFill = (FuelVehicle)vehicleToFill;
            if (carExists)
            {
                fuelVehicleToFill.Refuel(i_FuelToAdd, i_FuelType);
            }
        }
        public void ChargeElectricVehicle(string i_VehiclePlateNumber, float i_MinutesForCharging)
        {
            // note: * add range exception
            Vehicle vehicleToFill;
            ElectricVehicle electricVehicleToAdd;
            bool carExists;
            carExists = m_Vehicles.TryGetValue(i_VehiclePlateNumber, out vehicleToFill);
            electricVehicleToAdd = (ElectricVehicle)vehicleToFill;
            if (carExists)
            {
                electricVehicleToAdd.Charge(i_MinutesForCharging / 60); // TODO: change to const
            }
        }
        public string getVehicleData(string i_VehiclePlateNumber)
        {
            Vehicle vehicle;
            string vehicleData = null;
            bool carExists;
            carExists = m_Vehicles.TryGetValue(i_VehiclePlateNumber, out vehicle);
            if (carExists)
            {
                vehicleData = vehicle.ToString();
            }
            return vehicleData;
        }
    }
}
