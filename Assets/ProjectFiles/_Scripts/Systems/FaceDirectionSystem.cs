using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class FaceDirectionSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotation rot, in Translation pos, in MovementData moveData) =>
        {
            if (!moveData.Direction.Equals(float3.zero))
            {
                quaternion targetRotation = quaternion.LookRotation(moveData.Direction, math.up());
                rot.Value = math.slerp(rot.Value, targetRotation, moveData.TurnSpeed);
            }
        }).Run();
    }
}
