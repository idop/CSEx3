using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    public static class MotorCycleModels 
    {
        public enum eLicenseType
        {
            A,
            A1,
            AB,
            B1
        }

        public class FuelMotorCycle : FuelVehicle
        {
            private eLicenseType m_LicenseType;
            private int m_EngineDisplacement;
        }
        public class ElectricMotorCycle : ElectricVehicle
        {
            private eLicenseType m_LicenseType;
            private int m_EngineDisplacement;
        }
    }
}
