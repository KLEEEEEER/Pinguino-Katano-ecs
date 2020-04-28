using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;

public class PlayerMovementSystem : SystemBase
{
    [BurstCompile]
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation pos, in MovementData moveData) => 
        {
            float3 normalizedDir = math.normalizesafe(moveData.Direction);
            pos.Value += normalizedDir * moveData.Speed * deltaTime;
        }).Run();
    }
}
