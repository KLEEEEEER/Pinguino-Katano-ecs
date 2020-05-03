using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct MovementData : IComponentData
{
    public float3 Direction;
    public float Speed;
    public float TurnSpeed;
}
