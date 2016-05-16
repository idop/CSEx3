namespace Ex03.GarageLogic.TruckModels
{
    public sealed class TruckProperties
    {
        public const int k_NumberOfTires = 16;
        private bool m_IsCarryingDangerousMaterials;
        private float m_MaxCarryLoad;

        public override string ToString()
        {
            return string.Format(
@"Maxium Carry Load: {0}
The Truck {1} Carrying dangerous materials",
m_MaxCarryLoad,
m_IsCarryingDangerousMaterials ? "is" : "is not");
        }

        public TruckProperties(bool i_IsCarryingDangerousMaterials, float i_MaxCarryLoad)
        {
            m_IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials;
            m_MaxCarryLoad = i_MaxCarryLoad;
        }
    }
}
