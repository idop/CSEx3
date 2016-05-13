using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.CarModels
{
    public sealed class CarProperties
    {
        public enum eColors
        {
            Yellow,
            White,
            Red,
            Black
        }

        public enum eNumberOfDoors
        {
            TwoDoors = 2,
            ThreeDoors = 3,
            FourDoors = 4,
            FiveDoors = 5
        }

        private eNumberOfDoors m_NumberOfDoors;
        private eColors m_Color;

        public CarProperties(eNumberOfDoors i_NumberOfDoors ,eColors i_Color)
        {
            m_NumberOfDoors = i_NumberOfDoors;
            m_Color = i_Color;
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumberOfDoors;
            }
        }

        public eColors Color
        {
            get
            {
                return m_Color;
            }
        }
    }
}
