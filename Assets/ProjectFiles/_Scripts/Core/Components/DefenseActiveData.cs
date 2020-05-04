using Unity.Entities;

namespace PinguinoKatano.Attacking
{
    [GenerateAuthoringComponent]
    public struct DefenseActiveData : IComponentData
    {
        public float ProtectionPercent;
    }
}
