﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic.MotorCycleModels
{
    public class FuelMotorCycle : FuelVehicle
    {
        private MotorCycleProperties m_MotorCycleProperties;

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + m_MotorCycleProperties.ToString();
        }

        public FuelMotorCycle(string i_LicensePlate, string i_ModelName, List<Tire> i_Tiers, FuelTypes.eFuelType i_FuelType, float i_MaxFuelCapacity, float i_initialFuel, MotorCycleProperties.eLicenseType i_LicenseType, int i_EngineDisplacement)
: base(i_LicensePlate, i_ModelName, i_Tiers, i_FuelType, i_MaxFuelCapacity, i_initialFuel)
        {
            m_MotorCycleProperties = new MotorCycleProperties(i_LicenseType, i_EngineDisplacement);
        }
    }
}
