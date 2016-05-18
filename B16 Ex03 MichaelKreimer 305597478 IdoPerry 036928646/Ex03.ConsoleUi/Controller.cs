using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using Ex03.ConsoleUi.Menus;

namespace Ex03.ConsoleUi
{
    public class Controller
    {
        private const string k_InvalidMessage = "Invalid Input {0} Please try again.";
        private const string k_ReturnToMainMenuMessage = "press any key to return to the main menu.";
        private const int v_NumOfMenuOptions = 8;
        private Garage m_Garage = new Garage();
        private bool m_UserWantsToUseProgram = true;
    
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
                    UI.PrintMessage(string.Format(k_InvalidMessage, ex.Message));
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
            UI.PrintMessage(k_ReturnToMainMenuMessage);
            UI.GetInput();
        }

        private void fillFuelToVehicle()
        {
            float fuelAfterCharging = 0f;
            string plateNumber = getLicensePlateNumberFromUser();
            UI.PrintMessage("Please Select the fuel Type");
            UI.PrintMessage(FuelTypes.GetFuelTypesUiDisplay());
            string input = UI.GetInput();
            FuelTypes.eFuelType fuelType = GarageUtils.GetEnumOption<FuelTypes.eFuelType>(input, FuelTypes.k_MinEnumValue, FuelTypes.k_MaxEnumValue);

            UI.PrintMessage("Please enter the amount of hours you wish to charge the vehicle");
            input = UI.GetInput();

            try
            {
                fuelAfterCharging = m_Garage.addGasToVehicle(plateNumber, fuelType, input);
                UI.PrintMessage(string.Format("Vehicle fuel tank was fuuled with {0:f}. Current Fuel in the fuel tank is {1:f} liters", input, fuelAfterCharging));
            }
            catch (ValueOutOfRangeException ex)
            {
                UI.PrintMessage(string.Format(k_InvalidMessage, ex.Message));
            }
            catch (FormatException ex)
            {
                UI.PrintMessage(string.Format(k_InvalidMessage, ex.Message));
            }
            catch (ArgumentException ex)
            {
                UI.PrintMessage(string.Format(k_InvalidMessage, ex.Message));
            }
            finally
            {
                UI.PrintMessage(k_ReturnToMainMenuMessage);
                UI.GetInput();
            }
        }

        private void chargeVehicle()
        {
            string plateNumber = getLicensePlateNumberFromUser();
            string input;
            float powerAfterCharging = 0f;

            UI.PrintMessage("Please enter the amount of hours you wish to charge the vehicle");
            input = UI.GetInput();
            
            try
            {
                powerAfterCharging = m_Garage.ChargeElectricVehicle(plateNumber, input);
                UI.PrintMessage(string.Format("Vehicle Battery was charged with {0:f} hours. Current power is {1:f} hours", input, powerAfterCharging));
            }
            catch (ValueOutOfRangeException ex)
            {
                UI.PrintMessage(string.Format(k_InvalidMessage, ex.Message));
            }
            catch (FormatException ex)
            {
                UI.PrintMessage(string.Format(k_InvalidMessage, ex.Message));
            }
            catch (ArgumentException ex)
            {
                UI.PrintMessage(string.Format(k_InvalidMessage, ex.Message));
            }
            finally
            {
                UI.PrintMessage(k_ReturnToMainMenuMessage);
                UI.GetInput();
            }
        }

        private void enterNewVehicle()
        {
            string licensePlate = getLicensePlateNumberFromUser();
            if (m_Garage.IsVehicleAlreadyExists(licensePlate))
            {
                m_Garage.ChangeVehicleStatus(licensePlate, Customer.eVehicleStatus.InRepair);
            }
            else
            {
                Customer costumer = getCustomerInput(licensePlate);
                m_Garage.InsertCustomer(costumer);
                UI.PrintMessage("New customer vehicle added succesfully.");
                UI.PrintMessage(k_ReturnToMainMenuMessage);
                UI.GetInput();
            }
        }

        private Customer getCustomerInput(string i_LicensePlate)
        {
            string msg = "Please enter the costumer name: ";
            UI.PrintMessage(msg);
            string name = UI.GetInput();
            msg = "Please enter the customer phone number: ";
            UI.PrintMessage(msg);
            string phoneNumber = UI.GetInput();
            Vehicle vehicle = getVehicleInput(i_LicensePlate);
            return new Customer(name, phoneNumber, Customer.eVehicleStatus.InRepair, vehicle);
        }

        private Vehicle getVehicleInput(string i_LicensePlate)
        {
            string msg = string.Format("What kind of vehicle do you own?{0}", Environment.NewLine);

            UI.PrintMessage(msg);
            UI.PrintMessage(VehicleCatalog.GetVehicleCatalogUiDisplay());
            string input = UI.GetInput();
            VehicleCatalog.eVehicleCatalog option = GarageUtils.GetEnumOption<VehicleCatalog.eVehicleCatalog>(input, VehicleCatalog.k_MinEnumValue, VehicleCatalog.k_MaxEnumValue);
            return createSpecificVehicleFromOption(i_LicensePlate, option);
        }

        private Vehicle createSpecificVehicleFromOption(string i_LicensePlate, VehicleCatalog.eVehicleCatalog i_Option)
        {
            int numberOfInputParameters = m_Garage.GetNumberOfInputParametersForSpecificVehicle(i_Option);
            bool invalidInput;
            m_Garage.StartNewVehicleInputSequence(i_LicensePlate);
            for (int i = 0; i <= numberOfInputParameters; ++i)
            {
                invalidInput = true;
                while (invalidInput)
                {
                    UI.PrintMessage("Please Enter " + m_Garage.GetInputDisplayMessageForParameter(i_Option, i));
                    try
                    {
                        m_Garage.TakeInputForParameter(i_Option, i, UI.GetInput());
                        invalidInput = false;
                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        UI.PrintMessage(string.Format(k_InvalidMessage, ex.Message));
                    }
                    catch (FormatException ex)
                    {
                        UI.PrintMessage(string.Format(k_InvalidMessage, ex.Message));
                    }
                    catch (ArgumentException ex)
                    {
                        UI.PrintMessage(string.Format(k_InvalidMessage, ex.Message));
                    }
                }
            }

            return m_Garage.GetNewVehicle(i_Option);
        }

        private void showFindVehicleByLicencePlateSubMenu()
        {
            Customer.eVehicleStatus vehicleStatus = getVehicleStatusFromUser();
            List<string> vehiclesPlateNumbers = m_Garage.DisplyVehiclesByStatus(vehicleStatus);
            foreach (string plateNumbr in vehiclesPlateNumbers)
            {
                UI.PrintMessage(plateNumbr);
            }

            UI.PrintMessage(k_ReturnToMainMenuMessage);
            UI.GetInput();
        }

        private Customer.eVehicleStatus getVehicleStatusFromUser()
        {
            string input;
            string msg = string.Format(
@"What cars would you like to display?
0 - In repair
1 - Repaired
2 - Paid
3 - All
");
            UI.PrintMessage(msg);
            input = UI.GetInput();
            Customer.eVehicleStatus vehicleStatus = GarageUtils.GetEnumOption<Customer.eVehicleStatus>(input, 0, 3);
            return vehicleStatus;
        }

        private void changeVehicleStatus()
        {
            string plateNumber = getLicensePlateNumberFromUser();
            string input;
            string msg = string.Format(
@"What is the new status of the car?
0 - In repair
1 - Repaired
2 - Paid
");
            UI.PrintMessage(msg);
            input = UI.GetInput();
            Customer.eVehicleStatus vehicleStatus = GarageUtils.GetEnumOption<Customer.eVehicleStatus>(input, 0, 2);
            m_Garage.ChangeVehicleStatus(plateNumber, vehicleStatus);
        }

        private void inflateVehicleTiresToMax()
        {
            m_Garage.InflateVehicleTiresToMax(getLicensePlateNumberFromUser());
            UI.PrintMessage("Vehicle Tires were inflated to the maxmium allowed by the tire manufacturer");
            UI.PrintMessage(k_ReturnToMainMenuMessage);
            UI.GetInput();
        }

        private string getLicensePlateNumberFromUser()
        {
            string msg = "Please enter the license plate number: ";
            UI.PrintMessage(msg);
            return UI.GetInput();
        }
    }
}
