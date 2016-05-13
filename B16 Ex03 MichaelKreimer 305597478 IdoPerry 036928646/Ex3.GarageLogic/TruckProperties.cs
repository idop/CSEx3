
namespace Ex03.GarageLogic.TruckModels
{
    public sealed class TruckProperties
    {
        bool m_IsCarryingDangerousMaterials;
        float m_MaxCarryLoad;

        public TruckProperties(bool i_IsCarryingDangerousMaterials, float i_MaxCarryLoad)
        {
            m_IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials;
            m_MaxCarryLoad = i_MaxCarryLoad;
        }
    }
}
