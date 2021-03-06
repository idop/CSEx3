﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelVehicle : Vehicle
    {
        public const int k_MinValueAllowed = 0;
        private const string k_InvalidArgumentMessage = "Entered fuel type of {0} does not match allowed fuel type of {1}.";
        private readonly float r_MaxFuelTankCapacity;
        private readonly FuelTypes.eFuelType r_FuelType;
        private float m_CurrentFuelAmount;

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder(base.ToString());
            toString.Append(Environment.NewLine);
            toString.AppendFormat(
@"Fuel Type: {0}
Current fuel Amount: {1}
Maximum fuel tank capcity: {2}
Power Precentage {3:P1}",
r_FuelType,
m_CurrentFuelAmount,
r_MaxFuelTankCapacity,
EnergyMeterPercentage);

            return toString.ToString();
        }

        public FuelVehicle(string i_LicensePlate, string i_ModelName, List<Tire> i_Tiers, FuelTypes.eFuelType i_FuelType, float i_MaxFuelTankCapacity, float i_InitalFuelAmount) 
            : base(i_LicensePlate, i_ModelName, i_Tiers)
        {
            r_FuelType = i_FuelType;
            r_MaxFuelTankCapacity = i_MaxFuelTankCapacity;
            m_CurrentFuelAmount = 0;
            Refuel(i_InitalFuelAmount, i_FuelType);
        }

        public float CurrentFuelAmount
        {
            get
            {
                return m_CurrentFuelAmount;
            }
        }

        public override float EnergyMeterPercentage
        {
            get
            {
                return m_CurrentFuelAmount / r_MaxFuelTankCapacity;
            }
        }

        public void Refuel(float i_FuelToAdd, FuelTypes.eFuelType i_FuelType)
        {
            if (i_FuelType == r_FuelType)
            {
                float newFuelAmount = i_FuelToAdd + m_CurrentFuelAmount;
                if(newFuelAmount <= r_MaxFuelTankCapacity)
                {
                    m_CurrentFuelAmount = newFuelAmount;
                }
                else
                {
                    float maxValueAllowd = r_MaxFuelTankCapacity - m_CurrentFuelAmount;
                    throw new ValueOutOfRangeException(k_MinValueAllowed, maxValueAllowd);
                }
            }
            else
            {
                throw new ArgumentException(string.Format(k_InvalidArgumentMessage, i_FuelType, r_FuelType));
            }
        }

        public float calcFuelLeftToMax()
        {
            return r_MaxFuelTankCapacity - m_CurrentFuelAmount;
        }
    }
}