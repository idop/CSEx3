using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Costumer> m_Costumers = new Dictionary<string, Costumer>();
        private VehicleFactory m_Factory = new VehicleFactory();
        public void InsertCostumer(Costumer i_Costumer)
        {
            m_Costumers.Add(i_Costumer.CostumerVehicle.LicensePlate, i_Costumer);
        }
        public bool IsVehicleAlreadyExists(string i_VehiclePlateNumber)
        {
            return m_Costumers.ContainsKey(i_VehiclePlateNumber);
        }
        public List<string> DisplayVehiclesById(string i_VehicleId, Costumer.eVehicleStatus i_VehicleStatus)
        {
            List<string> listOfVehiclesPlates = new List<string>();
            foreach (Costumer costumer in m_Costumers.Values)
            {

                if (i_VehicleStatus.Equals(Costumer.eVehicleStatus.All) || costumer.Status.Equals(i_VehicleStatus))
                {
                    listOfVehiclesPlates.Add(costumer.CostumerVehicle.LicensePlate);
                }
                
            }
     
            return listOfVehiclesPlates;
        }
        public void ChangeVehicleStatus(string i_VehiclePlateNumber, Costumer.eVehicleStatus i_NewVehicleStatus)
        {
            // notes : a) maybe change to private
            //         b) reconsider for throw exception
            Costumer costumerToChange;
            bool carExists;
            carExists = m_Costumers.TryGetValue(i_VehiclePlateNumber, out costumerToChange);
            if (carExists)
            {
                costumerToChange.Status = i_NewVehicleStatus;
            }
        }
        public void InflateVehicleTiresToMax(string i_VehiclePlateNumber)
        {
            Costumer costumer;
            bool carExists;
            carExists = m_Costumers.TryGetValue(i_VehiclePlateNumber, out costumer);
            if (carExists)
            {
                foreach (Tire tire in costumer.CostumerVehicle.Tires)
                {
                    tire.AddAirPressure(tire.calcAirPressureLeftToFill());
                }
            }
        }
        public void addGasToVehicle(string i_VehiclePlateNumber, FuelTypes.eFuelType i_FuelType, float i_FuelToAdd)
        {
            // note: * add range exception
            Costumer costumer;
            bool carExists;
            carExists = m_Costumers.TryGetValue(i_VehiclePlateNumber, out costumer);
            if (carExists)
            {
                if (costumer.CostumerVehicle is FuelVehicle)
                {
                    ((FuelVehicle)costumer.CostumerVehicle).Refuel(i_FuelToAdd, i_FuelType);
                }
                else
                {
                    throw new ArgumentException(string.Format("Vehicle with license Plate {0} does not run on fuel", i_VehiclePlateNumber));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("could not find Vehicle with license Plate {0} ", i_VehiclePlateNumber));
            }
        }
        public void ChargeElectricVehicle(string i_VehiclePlateNumber, float i_MinutesForCharging)
        {
            // note: * add range exception
            Costumer costumer;
            bool carExists;
            carExists = m_Costumers.TryGetValue(i_VehiclePlateNumber, out costumer);
            if (carExists)
            {
                if (costumer.CostumerVehicle is ElectricVehicle)
                {
                    ((ElectricVehicle)costumer.CostumerVehicle).Charge(i_MinutesForCharging);
                }
                else
                {
                    throw new ArgumentException(string.Format("Vehicle with license Plate {0} does not run on Electricity", i_VehiclePlateNumber));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("could not find Vehicle with license Plate {0} ", i_VehiclePlateNumber));
            }
        }
    
        public string GetVehicleData(string i_VehiclePlateNumber)
        {
            Costumer costumer;
            string vehicleData = null;
            bool carExists;
            carExists = m_Costumers.TryGetValue(i_VehiclePlateNumber, out costumer);
            if (carExists)
            {
                vehicleData = costumer.CostumerVehicle.ToString();
            }
            else
            {
                throw new ArgumentException(string.Format("could not find Vehicle with license Plate {0} ", i_VehiclePlateNumber));
            }
            return vehicleData;
        }
    }
}
