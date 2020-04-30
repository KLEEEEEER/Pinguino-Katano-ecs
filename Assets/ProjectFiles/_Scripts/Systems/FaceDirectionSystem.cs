using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using PinguinoKatano.CameraBase;
using Unity.Physics;
using Unity.Physics.Systems;

public class FaceDirectionSystem : SystemBase
{
    private BuildPhysicsWorld _buildPhysicsWorldSystem;
    //private EndFramePhysicsSystem _endFramePhysicsSystem;
    public Vector3 mouseHitPosition;
    Camera mainCamera;

    protected override void OnStartRunning()
    {
        _buildPhysicsWorldSystem = World.GetExistingSystem<BuildPhysicsWorld>();
        //_endFramePhysicsSystem = World.GetOrCreateSystem<EndFramePhysicsSystem>();
        mainCamera = Camera.main;
    }
    protected override void OnUpdate()
    {
        //if (mainCamera == null) return;
        var screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastInput raycastInput = new RaycastInput
        {
            Start = screenRay.origin,
            End = screenRay.GetPoint(300),
            Filter = new CollisionFilter
            {
                BelongsTo = ~0u,
                CollidesWith = ~0u,
                GroupIndex = 0
            }
        };

        Entities.ForEach((ref Rotation rot, in Translation pos, in MovementData moveData) => //  in CameraBaseInputData cameraBaseInputData
        {
            if (_buildPhysicsWorldSystem.PhysicsWorld.CollisionWorld.CastRay(raycastInput, out var hit))
            {
                quaternion targetRotation = quaternion.LookRotation(hit.Position, math.up());
                rot.Value = math.slerp(rot.Value, targetRotation, moveData.TurnSpeed); //moveData.TurnSpeed
            }
        }).WithoutBurst().Run();
    }
}
