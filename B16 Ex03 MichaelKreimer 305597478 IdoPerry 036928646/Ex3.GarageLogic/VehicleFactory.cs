using System;
using System.Collections.Generic;
using System.Reflection;
using Ex03.GarageLogic.TruckModels;
using Ex03.GarageLogic.CarModels;
using Ex03.GarageLogic.MotorCycleModels;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        private const string k_VehicleModelNameDisplay = "model name";
        private const string k_TireManufcturerNameDisplay = "tire manufacturer name";
        private const string k_TireMaxmiumAirPressureDisplay = "tire maxmium allowed air pressure";
        private const string k_TireCurrentAirPressureDisplay = "tire current air pressure";
        private const string k_FuelTypeDisplay = "fuel type";
        private const string k_MaxFuelCapcityDisplay = "maximum fuel capcity";
        private const string k_CurrentFuelDisplay = "current fuel in vehicle";
        private const string k_LicenseTypeDisplay = "License type";
        private const string k_EngineDisplacementDisplay = "Engine Displacement";
        private const string k_ColorDisplay = "Color";
        private const string k_NumberOfDoorsDisplay = "Number Of Doors";
        private const string k_CarryingDangerousMaterialsDisplay = "Does the truck Carries Dangerous Materials? (True/False)";
        private const string k_MaxCarryLoadDisplay = "Max Carry Load";
        private const string k_MaxHoursOfPowerDisplay = "Max Hours Of Power";
        private const string k_CurrentHoursOfPowerDisplay = "Current Hours Of Power";
        
        ////Vehicle Protperties
        private string m_InputLicensePlate;
        private string m_InputModelName;

        ////Tire Properties
        private string m_InputManufacturerName;
        private float m_InputMaxAllowedAirPressure;
        private float m_InputStartingAirPressure;

        ////Fuel Vehicele Properties
        private FuelTypes.eFuelType m_InputFuelType;
        private float m_InputMaxFuelCapacity;
        private float m_InputinitialFuel;
        
        ////Electric Vehicle Properties
        private float m_InputMaxHoursOfPower;
        private float m_InputCurrentHoursOfPower;

        ////MotorCycle Properties
        private MotorCycleProperties.eLicenseType m_InputLicenseType;
        private int m_InputEngineDisplacement;
        
        ////Car Properties
        private CarProperties.eNumberOfDoors m_InputNumberOfDoors;
        private CarProperties.eColors m_InputColor;
        
        ////Truck Properties
        private bool m_InputIsCarryingDangerousMaterials;
        private float m_InputMaxCarryLoad;

        public void StartNewVehicleInputSequence(string i_LicensePlate) // Consider Params Build Helpers Cleanup
        {
            m_InputLicensePlate = i_LicensePlate;
        }

        public int GetNumberOfInputParametersForSpecificVehicle(VehicleCatalog.eVehicleCatalog i_Option)
        {
            int numberOfInputParameters = 0;

            switch (i_Option)
            {
                case VehicleCatalog.eVehicleCatalog.FuelMotorCycle:
                    numberOfInputParameters = typeof(FuelMotorCycle).GetConstructors()[0].GetParameters().Length;
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelTruck:
                    numberOfInputParameters = typeof(FuelTruck).GetConstructors()[0].GetParameters().Length;
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelCar:
                    numberOfInputParameters = typeof(FuelCar).GetConstructors()[0].GetParameters().Length;
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricCar:
                    numberOfInputParameters = typeof(ElectricCar).GetConstructors()[0].GetParameters().Length;
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricMotorCycle:
                    numberOfInputParameters = typeof(ElectricMotorCycle).GetConstructors()[0].GetParameters().Length;
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
                    inputDisplayMessage = getFuelTruckDisplayMessageForParameter(i);
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelCar:
                    inputDisplayMessage = getFuelCarDisplayMessageForParameter(i);
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricCar:
                    inputDisplayMessage = getElectricCarDisplayMessageForParameter(i);
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricMotorCycle:
                    inputDisplayMessage = getElectricMotorCycleDisplayMessageForParameter(i);
                    break;
                default:
                    break;
            }

            return inputDisplayMessage;
        }

        private string getElectricMotorCycleDisplayMessageForParameter(int i)
        {
            string inputDisplayMessage = string.Empty;
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    inputDisplayMessage = getVehicleDispleyMessageForParamater(i);
                    break;
                case 4:
                case 5:
                    inputDisplayMessage = getElectircVehicleDisplayMessageForParameter(i);
                    break;
                case 6:
                    inputDisplayMessage = k_LicenseTypeDisplay + Environment.NewLine + MotorCycleProperties.GetLicenseTypeUiDisplay();
                    break;
                case 7:
                    inputDisplayMessage = k_EngineDisplacementDisplay;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            return inputDisplayMessage;
        }

        private string getElectricCarDisplayMessageForParameter(int i)
        {
            string inputDisplayMessage = string.Empty;
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    inputDisplayMessage = getVehicleDispleyMessageForParamater(i);
                    break;
                case 4:
                case 5:
                    inputDisplayMessage = getElectircVehicleDisplayMessageForParameter(i);
                    break;
                case 6:
                    inputDisplayMessage = k_NumberOfDoorsDisplay + Environment.NewLine + CarProperties.GetNumberOfDoorsUiDisplay();
                    break;
                case 7:
                    inputDisplayMessage = k_ColorDisplay + Environment.NewLine + CarProperties.GetColorsUiDisplay();
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            return inputDisplayMessage;
        }

        private string getElectircVehicleDisplayMessageForParameter(int i)
        {
            string inputDisplayMessage = string.Empty;
            switch (i)
            {
                case 4:
                    inputDisplayMessage = k_MaxHoursOfPowerDisplay;
                    break;
                case 5:
                    inputDisplayMessage = k_CurrentHoursOfPowerDisplay;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            return inputDisplayMessage;
        }

        private string getFuelTruckDisplayMessageForParameter(int i)
        {
            string inputDisplayMessage = string.Empty;
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    inputDisplayMessage = getVehicleDispleyMessageForParamater(i);
                    break;
                case 4:
                case 5:
                case 6:
                    inputDisplayMessage = getFuelVehicleDisplayMessageForParameter(i);
                    break;
                case 7:
                    inputDisplayMessage = k_CarryingDangerousMaterialsDisplay;
                    break;
                case 8:
                    inputDisplayMessage = k_MaxCarryLoadDisplay;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            return inputDisplayMessage;
        }

        private string getFuelCarDisplayMessageForParameter(int i)
        {
            string inputDisplayMessage = string.Empty;
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    inputDisplayMessage = getVehicleDispleyMessageForParamater(i);
                    break;
                case 4:
                case 5:
                case 6:
                    inputDisplayMessage = getFuelVehicleDisplayMessageForParameter(i);
                    break;
                case 7:
                    inputDisplayMessage = k_NumberOfDoorsDisplay + Environment.NewLine + CarProperties.GetNumberOfDoorsUiDisplay();
                    break;
                case 8:
                    inputDisplayMessage = k_ColorDisplay + Environment.NewLine + CarProperties.GetColorsUiDisplay();
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            return inputDisplayMessage;
        }

        private string getFuelMotorCycleDisplayMessageForParameter(int i)
        {
            string inputDisplayMessage = string.Empty;
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    inputDisplayMessage = getVehicleDispleyMessageForParamater(i);
                    break;
                case 4:
                case 5:
                case 6:
                    inputDisplayMessage = getFuelVehicleDisplayMessageForParameter(i);
                    break;
                case 7:
                    inputDisplayMessage = k_LicenseTypeDisplay + Environment.NewLine + MotorCycleProperties.GetLicenseTypeUiDisplay();
                    break;
                case 8:
                    inputDisplayMessage = k_EngineDisplacementDisplay;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            return inputDisplayMessage;
        }

        private string getFuelVehicleDisplayMessageForParameter(int i)
        {
            string inputDisplayMessage = string.Empty;
            switch (i)
            {
                case 4:
                    inputDisplayMessage = k_FuelTypeDisplay + Environment.NewLine + FuelTypes.GetFuelTypesUiDisplay();
                    break;
                case 5:
                    inputDisplayMessage = k_MaxFuelCapcityDisplay;
                    break;
                case 6:
                    inputDisplayMessage = k_CurrentFuelDisplay;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            return inputDisplayMessage;
        }

        private string getVehicleDispleyMessageForParamater(int i)
        {
            string inputDisplayMessage = string.Empty;
            switch (i)
            {
                case 0:
                    inputDisplayMessage = k_VehicleModelNameDisplay;
                    break;
                case 1:
                    inputDisplayMessage = k_TireManufcturerNameDisplay;
                    break;
                case 2:
                    inputDisplayMessage = k_TireMaxmiumAirPressureDisplay;
                    break;
                case 3:
                    inputDisplayMessage = k_TireCurrentAirPressureDisplay;
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            return inputDisplayMessage;
        }

        public void TakeInputForParameter(VehicleCatalog.eVehicleCatalog i_Option, int i, string i_input)
        {
            switch (i_Option)
            {
                case VehicleCatalog.eVehicleCatalog.FuelMotorCycle:
                    takeFuelMotorCycleInputParameter(i, i_input);
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelTruck:
                    takeFuelTruckInputParameter(i, i_input);
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelCar:
                    takeFuelCarInputParameter(i, i_input);
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricCar:
                    takeElectricCarInputParameter(i, i_input);
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricMotorCycle:
                    takeElectricMotorCycleInputParameter(i, i_input);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void takeElectricMotorCycleInputParameter(int i, string i_input)
        {
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    takeVehicleInputParameter(i, i_input);
                    break;
                case 4:
                case 5:
                    takeElectircVehicleInputParameter(i, i_input);
                    break;
                case 6:
                    m_InputLicenseType = GarageUtils.GetEnumOption<MotorCycleProperties.eLicenseType>(i_input, MotorCycleProperties.k_LicenseTypeMinEnumValue, MotorCycleProperties.k_LicenseTypeMaxEnumValue);
                    break;
                case 7:
                    m_InputEngineDisplacement = int.Parse(i_input);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void takeElectricCarInputParameter(int i, string i_input)
        {
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    takeVehicleInputParameter(i, i_input);
                    break;
                case 4:
                case 5:
                    takeElectircVehicleInputParameter(i, i_input);
                    break;
                case 6:
                    m_InputNumberOfDoors = GarageUtils.GetEnumOption<CarProperties.eNumberOfDoors>(i_input, CarProperties.k_NumberOfDoorsMinEnumValue, CarProperties.k_NumberOfDoorsMaxEnumValue);
                    break;
                case 7:
                    m_InputColor = GarageUtils.GetEnumOption<CarProperties.eColors>(i_input, CarProperties.k_ColorMinEnumValue, CarProperties.k_ColorMaxEnumValue);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void takeElectircVehicleInputParameter(int i, string i_input)
        {
            switch (i)
            {
                case 4:
                    m_InputMaxHoursOfPower = float.Parse(i_input);
                    break;
                case 5:
                    m_InputCurrentHoursOfPower = GarageUtils.ParseFloatRangeInput(i_input, ElectricVehicle.k_MinValueAllowed, m_InputMaxHoursOfPower);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void takeFuelTruckInputParameter(int i, string i_input)
        {
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    takeVehicleInputParameter(i, i_input);
                    break;
                case 4:
                case 5:
                case 6:
                    takeFuelVehicleInputParameter(i, i_input);
                    break;
                case 7:
                    m_InputIsCarryingDangerousMaterials = bool.Parse(i_input);
                    break;
                case 8:
                    m_InputMaxCarryLoad = float.Parse(i_input); 
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void takeFuelCarInputParameter(int i, string i_input)
        {
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    takeVehicleInputParameter(i, i_input);
                    break;
                case 4:
                case 5:
                case 6:
                    takeFuelVehicleInputParameter(i, i_input);
                    break;
                case 7:
                    m_InputNumberOfDoors = GarageUtils.GetEnumOption<CarProperties.eNumberOfDoors>(i_input, CarProperties.k_NumberOfDoorsMinEnumValue, CarProperties.k_NumberOfDoorsMaxEnumValue);
                    break;
                case 8:
                    m_InputColor = GarageUtils.GetEnumOption<CarProperties.eColors>(i_input, CarProperties.k_ColorMinEnumValue, CarProperties.k_ColorMaxEnumValue);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void takeFuelMotorCycleInputParameter(int i, string i_input)
        {
            switch (i)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    takeVehicleInputParameter(i, i_input);
                    break;
                case 4:
                case 5:
                case 6:
                    takeFuelVehicleInputParameter(i, i_input);
                    break;
                case 7:
                    m_InputLicenseType = GarageUtils.GetEnumOption<MotorCycleProperties.eLicenseType>(i_input, MotorCycleProperties.k_LicenseTypeMinEnumValue, MotorCycleProperties.k_LicenseTypeMaxEnumValue);
                    break;
                case 8:
                    m_InputEngineDisplacement = int.Parse(i_input);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void takeVehicleInputParameter(int i, string i_input)
        {
            switch(i)
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
                    m_InputStartingAirPressure = GarageUtils.ParseFloatRangeInput(i_input, Tire.k_MinValueAllowed, m_InputMaxAllowedAirPressure);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void takeFuelVehicleInputParameter(int i, string i_input)
        {
            switch (i)
            {
                case 4:
                    m_InputFuelType = GarageUtils.GetEnumOption<FuelTypes.eFuelType>(i_input, FuelTypes.k_MinEnumValue, FuelTypes.k_MaxEnumValue);
                    break;
                case 5:
                    m_InputMaxFuelCapacity = float.Parse(i_input);
                    break;
                case 6:
                    m_InputinitialFuel = GarageUtils.ParseFloatRangeInput(i_input, FuelVehicle.k_MinValueAllowed, m_InputMaxFuelCapacity);
                    break;
                default:
                    throw new IndexOutOfRangeException();
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
                    tires = createNewTiresList(TruckProperties.k_NumberOfTires);
                    newVehicle = new FuelTruck(m_InputLicensePlate, m_InputModelName, tires, m_InputFuelType, m_InputMaxFuelCapacity, m_InputinitialFuel, m_InputIsCarryingDangerousMaterials, m_InputMaxCarryLoad);
                    break;
                case VehicleCatalog.eVehicleCatalog.FuelCar:
                    tires = createNewTiresList(CarProperties.k_NumberOfTires);
                    newVehicle = new FuelCar(m_InputLicensePlate, m_InputModelName, tires, m_InputFuelType, m_InputMaxFuelCapacity, m_InputinitialFuel, m_InputNumberOfDoors, m_InputColor);
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricCar:
                    tires = createNewTiresList(CarProperties.k_NumberOfTires);
                    newVehicle = new ElectricCar(m_InputLicensePlate, m_InputModelName, tires, m_InputMaxHoursOfPower, m_InputCurrentHoursOfPower, m_InputNumberOfDoors, m_InputColor);
                    break;
                case VehicleCatalog.eVehicleCatalog.ElectricMotorCycle:
                    tires = createNewTiresList(MotorCycleProperties.k_NumberOfTires);
                    newVehicle = new ElectricMotorCycle(m_InputLicensePlate, m_InputModelName, tires, m_InputMaxHoursOfPower, m_InputCurrentHoursOfPower, m_InputLicenseType, m_InputEngineDisplacement);
                    break;
                default:
                    throw new IndexOutOfRangeException();
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
    }
}
