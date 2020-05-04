using Unity.Entities;

namespace PinguinoKatano.Attacking
{
    [GenerateAuthoringComponent]
    public struct AttackDamageData : IComponentData
    {
        public float Value;
        public float Max;
        public float Min;
    }
}
