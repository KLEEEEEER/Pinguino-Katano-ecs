using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Physics;
using Unity.Mathematics;
using PinguinoKatano.Movement;

//namespace PinguinoKatano.Movement
//{
    [BurstCompile]
    public class PlayerJumpingSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            float deltaTime = Time.DeltaTime;

            Entities.WithAll<MainPlayerTag>().ForEach((ref PhysicsVelocity velocity, ref JumpingData jumpingData) =>
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    float3 newVelocity = velocity.Linear.xyz;
                    newVelocity += jumpingData.Force * new float3(0, 1f, 0);

                    velocity.Linear.xyz = newVelocity;
                }
            });
        }
    }
//}
