using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct LockXZRotationTag : IComponentData {
    public quaternion InitialRotationValue;
}
