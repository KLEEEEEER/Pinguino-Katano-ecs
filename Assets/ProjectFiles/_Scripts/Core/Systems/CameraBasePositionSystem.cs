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

        protected override void OnUpdate()
        {
            float deltaTime = Time.DeltaTime;

            Entities.WithAll<MainPlayerTag>().ForEach((ref LocalToWorld position) =>
            {
                targetPosition = position.Position;
            });

            var newPosition = Vector3.MoveTowards(
                    MonoBehaviourECSBridge.Instance.mainCamera.transform.position,
                    targetPosition + new float3(MonoBehaviourECSBridge.Instance.mainCameraOffset),
                    10f * deltaTime);

            MonoBehaviourECSBridge.Instance.mainCamera.transform.position = newPosition;
        }
    }
}
