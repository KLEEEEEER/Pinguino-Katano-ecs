using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Physics;
using Unity.Mathematics;
using PinguinoKatano.Movement;
using Unity.Physics.Systems;
using Unity.Transforms;

//namespace PinguinoKatano.Movement
//{
[BurstCompile]
    public class PlayerJumpingSystem : SystemBase
    {
        private BuildPhysicsWorld _buildPhysicsWorldSystem;

        protected override void OnStartRunning()
        {
            _buildPhysicsWorldSystem = World.GetExistingSystem<BuildPhysicsWorld>();
        }
        protected override void OnUpdate()
        {
            float deltaTime = Time.DeltaTime;

            Entities.WithAll<MainPlayerTag>().ForEach((ref PhysicsVelocity velocity, ref JumpingData jumpingData, in Translation pos) =>
            {
                if (Input.GetKeyDown(KeyCode.Space) && checkGround(pos.Value))
                {
                    float3 newVelocity = velocity.Linear.xyz;
                    newVelocity += jumpingData.Force * new float3(0, 1f, 0);

                    velocity.Linear.xyz = newVelocity;
                }
            }).WithoutBurst()
            .Run();
        }

        private bool checkGround(float3 currentPosition)
        {
            RaycastInput raycastInput = new RaycastInput
            {
                Start = currentPosition,
                End = currentPosition + new float3(0, -0.1f, 0),
                Filter = new CollisionFilter
                {
                    BelongsTo = ~0u,
                    CollidesWith = ~0u,
                    GroupIndex = 0
                }
            };
            Debug.Log($"Start = {currentPosition}");
            Debug.Log($"End = {currentPosition + new float3(0, -1f, 0)}");

            if (_buildPhysicsWorldSystem.PhysicsWorld.CollisionWorld.CastRay(raycastInput))
            {
                Debug.Log("On the ground!");
                return true;
            }
            Debug.Log("Not on the ground!");
            return false;
        }
    }
//}
