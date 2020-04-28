using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Burst;

namespace PinguinoKatano.CameraBase
{
    [BurstCompile]
    public class CameraBasePositionSystem : ComponentSystem
    {
        private float3 targetPosition;

        /*protected override void OnStartRunning()
        {
            base.OnStartRunning();

        }*/

        protected override void OnUpdate()
        {
            float deltaTime = Time.DeltaTime;

            Entities.WithAll<MainPlayerTag>().ForEach((ref LocalToWorld position) =>
            {
                targetPosition = position.Position;
            });

            Entities.ForEach((ref Translation position, ref CameraBasePositionData positionData, ref CameraBaseOffsetData offsetData) =>
            {
                var newPosition = Vector3.MoveTowards(
                    position.Value,
                    targetPosition + offsetData.Value,
                    positionData.MovementSpeed * deltaTime);

                position.Value = newPosition;
            });
        }
    }
}
