using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct LockXZRotationTag : IComponentData {
    public bool LockX;
    public bool LockY;
    public bool LockZ;
}
