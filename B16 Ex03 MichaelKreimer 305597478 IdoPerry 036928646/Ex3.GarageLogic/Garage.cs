using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Customer> m_Customers = new Dictionary<string, Customer>();
        private VehicleFactory m_Factory = new VehicleFactory();

        public void InsertCustomer(Customer i_Customer)
        {
            m_Customers.Add(i_Customer.CustomerVehicle.LicensePlate, i_Customer);
        }

        public bool IsVehicleAlreadyExists(string i_VehiclePlateNumber)
        {
            return m_Customers.ContainsKey(i_VehiclePlateNumber);
        }

        public List<string> DisplayVehiclesById(Customer.eVehicleStatus i_VehicleStatus)
        {
            List<string> listOfVehiclesPlates = new List<string>();
            foreach (Customer customer in m_Customers.Values)
            {
                if (i_VehicleStatus.Equals(Customer.eVehicleStatus.All) || customer.Status.Equals(i_VehicleStatus))
                {
                    listOfVehiclesPlates.Add(customer.CustomerVehicle.LicensePlate);
                }
            }
     
            return listOfVehiclesPlates;
        }

        public void ChangeVehicleStatus(string i_VehiclePlateNumber, Customer.eVehicleStatus i_NewVehicleStatus)
        {
            // notes : a) maybe change to private
            //         b) reconsider for throw exception
            Customer costumerToChange;
            bool carExists;
            carExists = m_Customers.TryGetValue(i_VehiclePlateNumber, out costumerToChange);
            if (carExists)
            {
                costumerToChange.Status = i_NewVehicleStatus;
            }
        }

        public void InflateVehicleTiresToMax(string i_VehiclePlateNumber)
        {
            Customer costumer;
            bool carExists;
            carExists = m_Customers.TryGetValue(i_VehiclePlateNumber, out costumer);
            if (carExists)
            {
                foreach (Tire tire in costumer.CustomerVehicle.Tires)
                {
                    tire.AddAirPressure(tire.calcAirPressureLeftToFill());
                }
            }
        }

        public float addGasToVehicle(string i_VehiclePlateNumber, FuelTypes.eFuelType i_FuelType, string i_FuelToAdd)
        {
            float fuelAfterCharge = 0f;
            Customer costumer;
            bool carExists;
            carExists = m_Customers.TryGetValue(i_VehiclePlateNumber, out costumer);
            if (carExists)
            {
                if (costumer.CustomerVehicle is FuelVehicle)
                {
                    ((FuelVehicle)costumer.CustomerVehicle).Refuel(float.Parse(i_FuelToAdd), i_FuelType);
                    fuelAfterCharge = ((FuelVehicle)costumer.CustomerVehicle).CurrentFuelAmount;
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

            return fuelAfterCharge;
        }

        public float ChargeElectricVehicle(string i_VehiclePlateNumber, string i_HoursForCharging)
        {
            float powerAfterCharing = 0f;
            Customer costumer;
            bool carExists;
            carExists = m_Customers.TryGetValue(i_VehiclePlateNumber, out costumer);
            if (carExists)
            {
                if (costumer.CustomerVehicle is ElectricVehicle)
                {
                    ((ElectricVehicle)costumer.CustomerVehicle).Charge(float.Parse(i_HoursForCharging));
                    powerAfterCharing = ((ElectricVehicle)costumer.CustomerVehicle).HoursOfPower;
                }
                else
                {
                    throw new ArgumentException(string.Format("Vehicle with license Plate {0} does not run on Battery", i_VehiclePlateNumber));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("could not find Vehicle with license Plate {0} ", i_VehiclePlateNumber));
            }

            return powerAfterCharing;
        }
    
        public string GetVehicleData(string i_VehiclePlateNumber)
        {
            Customer costumer;
            string vehicleData = null;
            bool carExists;
            carExists = m_Customers.TryGetValue(i_VehiclePlateNumber, out costumer);
            if (carExists)
            {
                vehicleData = costumer.CustomerVehicle.ToString();
            }
            else
            {
                throw new ArgumentException(string.Format("could not find Vehicle with license Plate {0} ", i_VehiclePlateNumber));
            }

            return vehicleData;
        }

        public int GetNumberOfInputParametersForSpecificVehicle(VehicleCatalog.eVehicleCatalog i_Option)
        {
            return m_Factory.GetNumberOfInputParametersForSpecificVehicle(i_Option);
        }

        public string GetInputDisplayMessageForParameter(VehicleCatalog.eVehicleCatalog i_Option, int i)
        {
            return m_Factory.GetInputDisplayMessageForParameter(i_Option, i);
        }

        public void StartNewVehicleInputSequence(string i_LicensePlate)
        {
            m_Factory.StartNewVehicleInputSequence(i_LicensePlate);
        }

        public void TakeInputForParameter(VehicleCatalog.eVehicleCatalog i_Option, int i, string i_input)
        {
            m_Factory.TakeInputForParameter(i_Option, i, i_input);
        }

        public Vehicle GetNewVehicle(VehicleCatalog.eVehicleCatalog i_Option)
        {
            return m_Factory.GetNewVehicle(i_Option);
        }
    }
}
