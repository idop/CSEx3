using Ex03.GarageLogic;
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
            UI.ClearConsle();
            UI.DisplayMainMenu();
            MainMenu.eMainMenu option;
            string input;
            while (m_UserWantsToUseProgram)
            {
                try
                {
                    input = UI.GetInput();
                    option = GarageUtils.GetEnumOption<MainMenu.eMainMenu>(input, MainMenu.k_MinEnumValue, MainMenu.k_MaxEnumValue)
                    doMainMainOption(option);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(k_InvalidMsg, ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(k_InvalidMsg, ex.Message);
                }
           
            }
        }

        private void doMainMainOption(MainMenu.eMainMenu i_Option)
        {
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
                    break;
            }
        }



        private void printFullVehicleDetails()
        {
            m_Garage.getVehicleData(getLicensePlateNumberFromUser());
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
                m_Garage.ChangeVehicleStatus(licensePlate , Costumer.eVehicleStatus.InRepair);
            }
            else
            {
                Costumer costumer = getCostumerInput(licensePlate);
                m_Garage.InsertCostumer(costumer);
            }
            
        }

        private Costumer getCostumerInput(string i_LicensePlate) // TODO GET VEHICLE INP
        {
            string msg = "Insert name: ";
            UI.PrintMessage(msg);
            string name = UI.GetInput();
            msg = "insert phone number: ";
            UI.PrintMessage(msg);
            string phoneNumber = UI.GetInput();
            Vehicle vehicle = getVehicleInput(i_LicensePlate);
            return new Costumer(name, phoneNumber, Costumer.eVehicleStatus.InRepair , vehicle);
        }

        private Vehicle getVehicleInput(string i_LicensePlate)
        {
            string msg = string.Format("Please choose the vehicle type you wish to add {0}", Environment.NewLine);

            UI.PrintMessage(msg);
            UI.PrintMessage(VehicleCatalog.GetVehicleCatalogUiDisplay());
            string input = UI.GetInput();
            bool invalidinput = true;
            VehicleCatalog.eVehicleCatalog option = 0;
            while (invalidinput)
            {
                try
                {
                    option = GarageUtils.GetEnumOption<VehicleCatalog.eVehicleCatalog>(input, VehicleCatalog.k_MinEnumValue, VehicleCatalog.k_MaxEnumValue);
                    invalidinput = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(k_InvalidMsg, ex.Message);
                }
            }

            return getSpecificVehicle(i_LicensePlate, option);
        }

        private Vehicle getSpecificVehicle(string i_LicensePlate,VehicleCatalog.eVehicleCatalog i_Option)
        {
            bool invalidinput = true;
            Vehicle specificVehicle = null;
            //string[] vehicleProperties = m_Garage.GetInputVhiecleProperties 
            while (invalidinput)
            {
            }

            return specificVehicle;
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
            Costumer.eVehicleStatus vehicleStatus = (Costumer.eVehicleStatus)UI.GetIntegerFromUser(0, 2);
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
