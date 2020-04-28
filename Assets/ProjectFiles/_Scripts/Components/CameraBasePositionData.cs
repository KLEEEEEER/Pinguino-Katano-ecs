using Unity.Entities;

namespace PinguinoKatano.CameraBase
{
    [GenerateAuthoringComponent]
    public struct CameraBasePositionData : IComponentData
    {
        public float MovementSpeed;
    }
}
