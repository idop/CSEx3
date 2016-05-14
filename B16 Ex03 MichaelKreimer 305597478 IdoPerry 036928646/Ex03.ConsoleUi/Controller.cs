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
                    input = Console.ReadLine();
                    option = MainMenu.GetOption(input);
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
            m_Garage.getVehicleData(getPlateNumberFromUser());
        }

        private void chargeVehicle()
        {
            string plateNumber = getPlateNumberFromUser();
            float minutesToCharage = UI.GetFloatFromUser(0, float.MaxValue - 1);
            m_Garage.ChargeElectricVehicle(plateNumber, minutesToCharage);
        }

        private void enterNewVehicle()
        {
            string msg = "please enter car license plate number";
            UI.PrintMessage(msg);
            Vehicle vehicle = getVehicleInput();
            if (m_Garage.IsVehicleAlreadyExists(vehicle.LicensePlate))
            {
                m_Garage.InsertVehicle(vehicle);
            }
            else
            {
                Costumer costumer = getCostumerInput();
                m_Garage.InsertVehicle(vehicle, costumer);
            }
            
        }

        private Costumer getCostumerInput()
        {
            string msg = "Insert name: ";
            UI.PrintMessage(msg);
            string name = UI.GetStringFromUser();
            msg = "insert phone number: ";
            UI.PrintMessage(msg);
            string phoneNumber = UI.GetStringFromUser();
            return new Costumer(name, phoneNumber);
        }

        private Vehicle getVehicleInput()
        {
            string msg = string.Format("What kind of vehicle do you own?{0}", Environment.NewLine);

            UI.PrintMessage(msg);
            UI.PrintMessage(VehicleCatalog.GetVehicleCatalogUiDisplay());
            string input = Console.ReadLine();
            VehicleCatalog.eVehicleCatalog option = VehicleCatalog.GetOption(input);
            throw new NotImplementedException();
        }

        private void showFindVehicleByLicencePlateSubMenu()
        {
            throw new NotImplementedException();
        }

        private void changeVehicleStatus()
        {
            string plateNumber = getPlateNumberFromUser();
            string msg = String.Format(
@"What is the new status of the car?
0 - In repair
1 - Repaired
2 - Paid
");
            UI.PrintMessage(msg);
            Vehicle.eStatus vehicleStatus = (Vehicle.eStatus)UI.GetIntegerFromUser(0, 2);
            m_Garage.ChangeVehicleStatus(plateNumber, vehicleStatus);
        }
        private void inflateVehicleTiresToMax()
        {
            m_Garage.InflateVehicleTiresToMax(getPlateNumberFromUser());
        }
        private void fillFuelToVehicle()
        {
            string plateNumber = getPlateNumberFromUser();
            FuelVehicle.eFuelType fuelType = (FuelVehicle.eFuelType)UI.GetIntegerFromUser(0, 3); // TODO: change to 0 - v_MaxFuelTypes-1
            float fuelToFill = UI.GetFloatFromUser(0, m_Garage.calcFuelLeftToFill(plateNumber) - 1);
            m_Garage.addGasToVehicle(plateNumber, fuelType, fuelToFill);
        }
        private string getPlateNumberFromUser()
        {
            string msg = "Please enter the license plate number: ";
            UI.PrintMessage(msg);
            return UI.GetStringFromUser();
        }


    }
}
