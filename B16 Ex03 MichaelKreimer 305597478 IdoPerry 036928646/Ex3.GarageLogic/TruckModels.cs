using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.GarageLogic
{
    public static class TruckModels 
    {
        public class FuelTruck : FuelVehicle
        {
            bool m_IsCarryingDangerousMaterials;
            float m_MaxCarryLoad;

            public FuelTruck()
            {

            }
        }
    }
}
