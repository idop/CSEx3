
namespace Ex03.GarageLogic.TruckModels
{
    public sealed class TruckProperties
    {
        public const int k_NumberOfTires = 16;
        private bool m_IsCarryingDangerousMaterials;
        private float m_MaxCarryLoad;

        public TruckProperties(bool i_IsCarryingDangerousMaterials, float i_MaxCarryLoad)
        {
            m_IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials;
            m_MaxCarryLoad = i_MaxCarryLoad;
        }
    }
}
