using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(string message) : base(message)
        {
        }
    }
}
