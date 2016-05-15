﻿using Ex03.GarageLogic;
using System;
using Ex03.ConsoleUi.Menus;
namespace Ex03.ConsoleUi
{
    class Controller
    {// here is the logic manager of the garage
        private const int v_NumOfMenuOptions = 8;
        private Garage m_Garage = new Garage();
        private bool m_UserWantsToUseProgram = true;
        private const string k_InvalidMsg = "Invalid Input {0} Please try again";
       
        public Controller()
        {
            ControlMainMenu();
        }

        private void ControlMainMenu()
        {
            MainMenu.eMainMenu option;
            string input;
            while (m_UserWantsToUseProgram)
            {
                UI.ClearConsle();
                UI.DisplayMainMenu();
                try
                {
                    input = UI.GetInput();
                    option = GarageUtils.GetEnumOption<MainMenu.eMainMenu>(input, MainMenu.k_MinEnumValue, MainMenu.k_MaxEnumValue); 
                    doMainMainOption(option);
                }
                catch (ValueOutOfRangeException ex)
                {
                    UI.PrintMessage(string.Format(k_InvalidMsg, ex.Message));
                }
            }
        }

        private void doMainMainOption(MainMenu.eMainMenu i_Option)
        {
            UI.ClearConsle();
            switch (i_Option)
            {
                case MainMenu.eMainMenu.EnterNewVehicle:
                    enterNewVehicle();
                    break;
                case MainMenu.eMainMenu.ShowFindVehicleByLicencePlateSubMenu:
                    showFindVehicleByLicencePlateSubMenu();
                    break;
                case MainMenu.eMainMenu.ChangeVehicleStatus:
                    changeVehicleStatus();
                    break;
                case MainMenu.eMainMenu.InflateVehicleTiresToMax:
                    inflateVehicleTiresToMax();
                    break;
                case MainMenu.eMainMenu.FuelVehicle:
                    fillFuelToVehicle();
                    break;
                case MainMenu.eMainMenu.ChargeVehicle:
                    chargeVehicle();
                    break;
                case MainMenu.eMainMenu.PrintFullVehicleDetails:
                    printFullVehicleDetails();
                    break;
                case MainMenu.eMainMenu.Exit:
                    m_UserWantsToUseProgram = false;
                    break;
                default:
                    throw new ValueOutOfRangeException(MainMenu.k_MinEnumValue, MainMenu.k_MaxEnumValue);
            }
        }



        private void printFullVehicleDetails()
        {
            string msg = m_Garage.GetVehicleData(getLicensePlateNumberFromUser());
            UI.PrintMessage(msg);

        }

        private void chargeVehicle()
        {
            string plateNumber = getLicensePlateNumberFromUser();
            float minutesToCharage = UI.GetFloatFromUser(0, float.MaxValue - 1);
            m_Garage.ChargeElectricVehicle(plateNumber, minutesToCharage);
        }

        private void enterNewVehicle()
        {
            string licensePlate = getLicensePlateNumberFromUser();
            if (m_Garage.IsVehicleAlreadyExists(licensePlate))
            {
                m_Garage.ChangeVehicleStatus(licensePlate , Customer.eVehicleStatus.InRepair);
            }
            else
            {
                Customer costumer = getCustomerInput(licensePlate);
                m_Garage.InsertCustomer(costumer);
                UI.PrintMessage("New customer vehicle added succesfully. press any key to return to the main menu");
                UI.GetInput();
            }
            
        }

        private Customer getCustomerInput(string i_LicensePlate) // TODO GET VEHICLE INP
        {
            string msg = "Please enter the costumer name: ";
            UI.PrintMessage(msg);
            string name = UI.GetInput();
            msg = "Please enter the customer phone number: ";
            UI.PrintMessage(msg);
            string phoneNumber = UI.GetInput();
            Vehicle vehicle = getVehicleInput(i_LicensePlate);
            return new Customer(name, phoneNumber, Customer.eVehicleStatus.InRepair , vehicle);
        }

        private Vehicle getVehicleInput(string i_LicensePlate)
        {
            string msg = string.Format("What kind of vehicle do you own?{0}", Environment.NewLine);

            UI.PrintMessage(msg);
            UI.PrintMessage(VehicleCatalog.GetVehicleCatalogUiDisplay());
            string input = UI.GetInput();
            VehicleCatalog.eVehicleCatalog option = GarageUtils.GetEnumOption<VehicleCatalog.eVehicleCatalog>(input, VehicleCatalog.k_MinEnumValue , VehicleCatalog.k_MaxEnumValue);
            return createSpcificVehicleFromOption(i_LicensePlate, option);
        }

        private Vehicle createSpcificVehicleFromOption(string i_LicensePlate, VehicleCatalog.eVehicleCatalog i_Option)
        {
            int numberOfInputParameters = m_Garage.GetNumberOfInputParametersForSpecificVehicle(i_Option);
            bool invalidInput;
            m_Garage.StartNewVehicleInputSequence(i_LicensePlate);
            for (int i = 0; i < numberOfInputParameters; ++i)
            {
                invalidInput = true;
                while (invalidInput)
                {
                    UI.PrintMessage("Please Eneter " +m_Garage.GetInputDisplayMessageForParameter(i_Option, i));
                    try
                    {
                        m_Garage.TakeInputForParameter(i_Option, i, UI.GetInput());
                        invalidInput = false;
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        UI.PrintMessage(string.Format(k_InvalidMsg, ex.Message));
                    }
                    catch (FormatException ex)
                    {
                        UI.PrintMessage(string.Format(k_InvalidMsg, ex.Message));
                    }
                    catch (ArgumentException ex)
                    {
                        UI.PrintMessage(string.Format(k_InvalidMsg, ex.Message));
                    }
                }
            }
            return m_Garage.GetNewVehicle(i_Option);
        }

        private void showFindVehicleByLicencePlateSubMenu()
        {
            throw new NotImplementedException();
        }

        private void changeVehicleStatus()
        {
            string plateNumber = getLicensePlateNumberFromUser();
            string msg = String.Format(
@"What is the new status of the car?
0 - In repair
1 - Repaired
2 - Paid
");
            UI.PrintMessage(msg);
            Customer.eVehicleStatus vehicleStatus = (Customer.eVehicleStatus)UI.GetIntegerFromUser(0, 2);
            m_Garage.ChangeVehicleStatus(plateNumber, vehicleStatus);
        }
        private void inflateVehicleTiresToMax()
        {
            m_Garage.InflateVehicleTiresToMax(getLicensePlateNumberFromUser());
        }
        private void fillFuelToVehicle() // hnadle Exceptions
        {
            string plateNumber = getLicensePlateNumberFromUser();
            UI.PrintMessage("Please Select the fuel Type");
            UI.PrintMessage(FuelTypes.GetFuelTypesUiDisplay());
            string input = UI.GetInput();
            FuelTypes.eFuelType fuelType = GarageUtils.GetEnumOption<FuelTypes.eFuelType>(input, FuelTypes.k_MinEnumValue, FuelTypes.k_MaxEnumValue);
            float fuelToFill = float.Parse(UI.GetInput());
            m_Garage.addGasToVehicle(plateNumber, fuelType, fuelToFill);
        }
        private string getLicensePlateNumberFromUser()
        {
            string msg = "Please enter the license plate number: ";
            UI.PrintMessage(msg);
            return UI.GetInput();
        }


    }
}
