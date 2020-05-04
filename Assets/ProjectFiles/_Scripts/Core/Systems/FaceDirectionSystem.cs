using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using PinguinoKatano.CameraBase;
using Unity.Physics;
using Unity.Physics.Systems;

public class FaceDirectionSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        
        Vector3 mousePosition = Input.mousePosition;

        Entities.ForEach((ref Rotation rot, ref MovementData moveData, in Translation pos) =>
        {
            Vector3 entityCameraPosition = MonoBehaviourECSBridge.Instance.mainCamera.WorldToScreenPoint(pos.Value);

            mousePosition.x = mousePosition.x - entityCameraPosition.x;
            mousePosition.y = mousePosition.y - entityCameraPosition.y;
            float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            angle -= 90f;

            quaternion targetRotation = Quaternion.Euler(new Vector3(0, -angle, 0));

            if (moveData.LastRotationY != 0)
            {
                moveData.TurnSpeed = math.abs(rot.Value.value.y - moveData.LastRotationY) * 100f * deltaTime;
            }
            moveData.LastRotationY = rot.Value.value.y;
            MonoBehaviourECSBridge.Instance.SetSwingText(moveData.TurnSpeed.ToString());
            rot.Value = math.slerp(rot.Value, targetRotation, 1f);
        }).WithoutBurst().Run();
    }
}
