using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.CarModels
{
    public sealed class CarProperties
    {
        public const int k_NumberOfDoorsMinEnumValue = 2;
        public const int k_NumberOfDoorsMaxEnumValue = 5;
        public const int k_ColorMinEnumValue = 0;
        public const int k_ColorMaxEnumValue = 3;
        public const int k_NumberOfTires = 4;
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

        public static string GetColorsUiDisplay()
        {
            string colorUiDisplay = string.Format(
@"{0} - Yellow
{1} - White
{2} - Red
{3} - Black",
(int)eColors.Yellow,
(int)eColors.White,
(int)eColors.Red,
(int)eColors.Black);

            return colorUiDisplay;
        }

        public static string GetNumberOfDoorsUiDisplay()
        {
            string numberOfDoorsUiDisplay = string.Format(
@"{0} - Two Doors
{1} - Three Doors
{2} - Four Doors
{3} - Five Doors",
(int)eNumberOfDoors.TwoDoors,
(int)eNumberOfDoors.ThreeDoors,
(int)eNumberOfDoors.FourDoors,
(int)eNumberOfDoors.FiveDoors);

            return numberOfDoorsUiDisplay;
        }
    }
}
