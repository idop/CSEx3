using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        public float m_MaxValue;
        public float m_MinValue;

        public ValueOutOfRangeException(string message) : base(message)
        {
        }
    }
}
