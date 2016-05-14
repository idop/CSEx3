using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class GarageUtils
    {
        public static T GetEnumOption<T>(int i_MinValue, int i_maxValue)
        {
            int input = int.Parse(Console.ReadLine());
            if (!IntegerInRange(input, i_MinValue, i_maxValue))
            {
                throw new ValueOutOfRangeException(i_MinValue, i_maxValue);
            }

            return (T)Enum.ToObject(typeof(T), input);
        }

        public static bool IntegerInRange(int input, int i_MinValue, int i_maxValue)
        {
            return (input >= i_MinValue && input <= i_maxValue);
        }
    }
}
