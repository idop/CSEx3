namespace Ex03.GarageLogic
{
    public class Costumer
    {
        string m_Name;
        string m_PhoneNumber;
        public Costumer(string name, string phoneNumber)
        {
            m_Name = name;
            m_PhoneNumber = phoneNumber;
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
    }

}