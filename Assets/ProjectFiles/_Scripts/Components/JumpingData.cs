using Unity.Entities;

namespace PinguinoKatano.Movement
{
    [GenerateAuthoringComponent]
    public struct JumpingData : IComponentData
    {
        public float Force;
    }
}
