using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_Vehicles = new Dictionary<string, Vehicle>();
        private Dictionary<string, Costumer> m_Costumers = new Dictionary<string, Costumer>();
        private VehicleFactory m_Factory = new VehicleFactory();
        public void InsertVehicle(Vehicle i_Vehicle)
        {
            m_Vehicles.Add(i_Vehicle.LicensePlate, i_Vehicle);
        }
        public void InsertVehicle(Vehicle i_Vehicle,Costumer i_Costumer)
        {
            m_Vehicles.Add(i_Vehicle.LicensePlate, i_Vehicle);
            m_Costumers.Add(i_Vehicle.LicensePlate, i_Costumer);
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
        public void InflateVehicleTiresToMax(string i_VehiclePlateNumber)
        {
            Vehicle vehicleToFill;
            bool carExists;
            carExists = m_Vehicles.TryGetValue(i_VehiclePlateNumber, out vehicleToFill);
            if (carExists)
            {
                foreach (Tire tire in vehicleToFill.Tires)
                {
                    tire.AddAirPressure(tire.calcAirPressureLeftToFill());
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
        public float calcFuelLeftToFill(string i_PlateNumber)
        {
            Vehicle vehicle;
            FuelVehicle fuelVehicle;
            m_Vehicles.TryGetValue(i_PlateNumber, out vehicle);
            fuelVehicle = vehicle as FuelVehicle;
            float fuelLeft = fuelVehicle.calcFuelLeftToMax();

            return fuelLeft;
        }

    }
}
