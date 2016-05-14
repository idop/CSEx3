using Ex03.GarageLogic.MotorCycleModels;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private const int k_numberofFuelVehicleProperites = 9;
        private const int k_numberofElectricVehicleProperites = 8;
        private const string k_VehicleModelName = "model name";
        private const string k_TireManufcturerName = "tire manufacturer name";
        private const string k_TireMaxmiumAirPressure = "tire maxmium allowed air pressure";
        private const string k_TireCurrentAirPressure = "tire current air pressure";
        private const string k_FuelType = "fuel type";
        private const string k_MaxFuelCapcity = "maximum fuel capcity";
        private const string k_CurrentFuel = "current fuel in vehicle";
        private const string k_LicenseType = "License type";
        private const string k_EngineDisplacement = "Engine Displacement";
        ///Vehicle Protperties
        private string m_InputLicensePlate;
        string m_InputModelName;
        ///Tire Properties
        string m_InputManufacturerName;
        float m_InputMaxAllowedAirPressure;
        float m_InputStartingAirPressure;

        ///Fuel Vehicele Properties
        FuelTypes.eFuelType m_InputFuelType;
        float m_InputMaxFuelCapacity;
        float m_InputinitialFuel;

        ///MotorCycleProperties
        MotorCycleProperties.eLicenseType m_InputLicenseType;
        int m_InputEngineDisplacement;

        public int GetNumberOfInputParametersForSpecificVehicle(VehicleCatalog.eVehicleCatalog i_Option)
        {
            int numberOfInputParameters = 0;

            switch (i_Option)
            {
                case VehicleCatalog.eVehicleCatalog.FuelMotorCycle:
                case VehicleCatalog.eVehicleCatalog.FuelTruck:
                case VehicleCatalog.eVehicleCatalog.FuelCar:
                    numberOfInputParameters = k_numberofFuelVehicleProperites;
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricCar:
                case VehicleCatalog.eVehicleCatalog.ElectricMotorCycle:
                    numberOfInputParameters = k_numberofElectricVehicleProperites;
                    break;
                default:
                    break;
            }

            return numberOfInputParameters;

        }

        public string GetInputDisplayMessageForParameter(VehicleCatalog.eVehicleCatalog i_Option, int i)
        {
            string inputDisplayMessage = string.Empty;

            switch (i_Option)
            {
                case VehicleCatalog.eVehicleCatalog.FuelMotorCycle:
                    inputDisplayMessage = getFuelMotorCycleDisplayMessageForParameter(i);
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelTruck:
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelCar:
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricCar:
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricMotorCycle:
                    break;
                default:
                    break;
            }

            return inputDisplayMessage;
        }

        private string getFuelMotorCycleDisplayMessageForParameter(int i)
        {
            string inputDisplayMessage = string.Empty;
            switch (i)
            {
                case 0:
                    inputDisplayMessage = k_VehicleModelName;
                    break;
                case 1:
                    inputDisplayMessage = k_TireManufcturerName;
                    break;
                case 2:
                    inputDisplayMessage = k_TireMaxmiumAirPressure;
                    break;
                case 3:
                    inputDisplayMessage = k_TireCurrentAirPressure;
                    break;
                case 4:
                    inputDisplayMessage = k_FuelType + Environment.NewLine + FuelTypes.GetFuelTypesUiDisplay();
                    break;
                case 5:
                    inputDisplayMessage = k_MaxFuelCapcity;
                    break;
                case 6:
                    inputDisplayMessage = k_CurrentFuel;
                    break;
                case 7:
                    inputDisplayMessage = k_LicenseType + Environment.NewLine + MotorCycleProperties.GetLicenseTypeUiDisplay();
                    break;
                case 8:
                    inputDisplayMessage = k_EngineDisplacement;
                    break;
                default:
                    break;
            }
            return inputDisplayMessage;
        }

        public void StartNewVehicleInputSequence(string i_LicensePlate) // Consider Params Build Helpers Cleanup
        {
            m_InputLicensePlate = i_LicensePlate;
        }

        public void TakeInputForParameter(VehicleCatalog.eVehicleCatalog i_Option, int i, string i_input)
        {
            switch (i_Option)
            {
                case VehicleCatalog.eVehicleCatalog.FuelMotorCycle:
                    takeFuelMotorCycleInputParameter(i, i_input);
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelTruck:
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelCar:
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricCar:
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricMotorCycle:
                    break;
                default:
                    break;
            }
        }

        public Vehicle GetNewVehicle(VehicleCatalog.eVehicleCatalog i_Option)
        {
            Vehicle newVehicle = null;
            List<Tire> tires;
            switch (i_Option)
            {
                case VehicleCatalog.eVehicleCatalog.FuelMotorCycle:
                    tires = createNewTiresList(MotorCycleProperties.k_NumberOfTires);
                    newVehicle = new FuelMotorCycle(m_InputLicensePlate, m_InputModelName, tires, m_InputFuelType, m_InputMaxFuelCapacity, m_InputinitialFuel, m_InputLicenseType, m_InputEngineDisplacement);
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelTruck:
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelCar:
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricCar:
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricMotorCycle:
                    break;
                default:
                    break;
            }

            return newVehicle;
        }

        private List<Tire> createNewTiresList(int k_NumberOfTires)
        {
            List<Tire> tires = new List<Tire>(k_NumberOfTires);
            for (int i = 0; i < k_NumberOfTires; ++i)
            {
                tires.Add(new Tire(m_InputManufacturerName, m_InputMaxAllowedAirPressure, m_InputStartingAirPressure));
            }
            return tires;
        }

        private void takeFuelMotorCycleInputParameter(int i, string i_input)
        {
            switch (i)
            {
                case 0:
                    m_InputModelName = i_input;
                    break;
                case 1:
                    m_InputManufacturerName = i_input;
                    break;
                case 2:
                    m_InputMaxAllowedAirPressure = float.Parse(i_input);
                    break;
                case 3:
                    m_InputStartingAirPressure = float.Parse(i_input);
                    break;
                case 4:
                    m_InputFuelType = GarageUtils.GetEnumOption<FuelTypes.eFuelType>(i_input, FuelTypes.k_MinEnumValue, FuelTypes.k_MaxEnumValue);
                    break;
                case 5:
                    m_InputMaxFuelCapacity = float.Parse(i_input);
                    break;
                case 6:
                    m_InputinitialFuel = float.Parse(i_input);
                    break;
                case 7:
                    m_InputLicenseType = GarageUtils.GetEnumOption<MotorCycleProperties.eLicenseType>(i_input, MotorCycleProperties.k_LicenseTypeMinEnumValue, MotorCycleProperties.k_LicenseTypeMaxEnumValue);
                    break;
                case 8:
                    m_InputEngineDisplacement = int.Parse(i_input);
                    break;
                default:
                    break;
            }
        }
    }
}
