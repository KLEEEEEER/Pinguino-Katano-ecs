using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using PinguinoKatano.CameraBase;
using Unity.Physics;
using Unity.Physics.Systems;

public class FaceDirectionSystem : SystemBase
{
    //private BuildPhysicsWorld _buildPhysicsWorldSystem;
    //private EndFramePhysicsSystem _endFramePhysicsSystem;
    //public Vector3 mouseHitPosition;
    //Unity.Physics.RaycastHit hit;

    protected override void OnStartRunning()
    {
        //_buildPhysicsWorldSystem = World.GetExistingSystem<BuildPhysicsWorld>();
        //_endFramePhysicsSystem = World.GetOrCreateSystem<EndFramePhysicsSystem>();
    }
    protected override void OnUpdate()
    {

        /*var screenRay = MonoBehaviourECSBridge.Instance.mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastInput raycastInput = new RaycastInput
        {
            Start = screenRay.origin,
            End = screenRay.GetPoint(1000),
            Filter = new CollisionFilter
            {
                BelongsTo = ~0u,
                CollidesWith = ~0u,
                GroupIndex = 0
            }
        };*/
        Vector3 mousePosition = Input.mousePosition;

        Entities.ForEach((ref Rotation rot, in Translation pos, in MovementData moveData) => //  in CameraBaseInputData cameraBaseInputData
        {
            Vector3 entityCameraPosition = MonoBehaviourECSBridge.Instance.mainCamera.WorldToScreenPoint(pos.Value);
            //var newPosition = mousePosition - entityCameraPosition;
            //newPosition.y = 0;

            //quaternion targetRotation = quaternion.LookRotation(newPosition.normalized, math.up());

            //mousePosition.z = 5.23f;
            mousePosition.x = mousePosition.x - entityCameraPosition.x;
            mousePosition.y = mousePosition.y - entityCameraPosition.y;
            float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            angle -= 90f;

            quaternion targetRotation = Quaternion.Euler(new Vector3(0, -angle, 0));


           // Debug.Log($"newPosition.normalized = {newPosition.normalized}");
            rot.Value = math.slerp(rot.Value, targetRotation, moveData.TurnSpeed);
        }).WithoutBurst().Run();
    }
}
