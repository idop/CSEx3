using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class GarageUtils
    {
        public static T GetEnumOption<T>(string i_Input, int i_MinValue, int i_maxValue)
        {
            int intInput = int.Parse(i_Input);
            if (!IntegerInRange(intInput, i_MinValue, i_maxValue))
            {
                throw new ValueOutOfRangeException(i_MinValue, i_maxValue);
            }

            return (T)Enum.ToObject(typeof(T), intInput);
        }

        public static bool IntegerInRange(int i_Input, int i_MinValue, int i_maxValue)
        {
            return (i_Input >= i_MinValue && i_Input <= i_maxValue);
        }
    }
}
