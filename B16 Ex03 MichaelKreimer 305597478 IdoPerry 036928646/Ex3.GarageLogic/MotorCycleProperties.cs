using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic.MotorCycleModels
{
    public sealed class MotorCycleProperties
    {
        public const int k_NumberOfTires = 2;
        public enum eLicenseType
        {
            A,
            A1,
            AB,
            B1
        }

        private eLicenseType m_LicenseType;
        private int m_EngineDisplacement;

        public MotorCycleProperties(eLicenseType i_LicenseType, int i_EngineDisplacement)
        {
            m_LicenseType = i_LicenseType;
            m_EngineDisplacement = i_EngineDisplacement;
        }


    }
}
