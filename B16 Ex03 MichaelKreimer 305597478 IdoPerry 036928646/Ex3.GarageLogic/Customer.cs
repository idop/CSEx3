namespace Ex03.GarageLogic
{
    public class Customer
    {
        private string m_Name;
        private string m_PhoneNumber;
        private Vehicle m_CustomerVehicle;
        private eVehicleStatus m_Status;

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Paid,
            All
        }

        public eVehicleStatus Status
        {
            get
            {
                return m_Status;
            }

            set
            {
                m_Status = value;
            }
        }

        public override int GetHashCode()
        {
            return m_CustomerVehicle.GetHashCode();
        }

        public Customer(string i_Name, string i_PhoneNumber, eVehicleStatus i_Stauts, Vehicle i_Vehicle)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
            m_Status = i_Stauts;
            m_CustomerVehicle = i_Vehicle;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }

            set
            {
                m_Name = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return m_PhoneNumber;
            }

            set
            {
                m_PhoneNumber = value;
            }
        }

        public Vehicle CustomerVehicle
        {
            get
            {
                return m_CustomerVehicle;
            }

            set
            {
                m_CustomerVehicle = value;
            }
        }
    }
}