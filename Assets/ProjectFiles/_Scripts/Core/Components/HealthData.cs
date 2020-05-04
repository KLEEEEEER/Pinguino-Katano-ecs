using Unity.Entities;

namespace PinguinoKatano.Attacking
{
    [GenerateAuthoringComponent]
    public struct HealthData : IComponentData
    {
        public float Value;
        public float MaxHP;
    }
}
