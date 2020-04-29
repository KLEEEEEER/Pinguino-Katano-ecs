using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Physics;

public class PlayerMovementSystem : SystemBase
{
    [BurstCompile]
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;

        Entities.WithAll<MainPlayerTag>().ForEach((ref PhysicsVelocity velocity, in MovementData moveData) =>
        {
            float3 normalizedDir = math.normalizesafe(moveData.Direction);
            velocity.Linear.xz = new float2(normalizedDir.x, normalizedDir.z) * moveData.Speed * deltaTime;
            //pos.Value += normalizedDir * moveData.Speed * deltaTime;
        }).Run();
    }
}
