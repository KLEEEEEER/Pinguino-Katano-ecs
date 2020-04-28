using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class LockXZRotationSystem : ComponentSystem
{
    protected override void OnStartRunning()
    {
        base.OnStartRunning();

        Entities.ForEach((ref Rotation rotation, ref LockXZRotationTag lockXZRotation) => {
            lockXZRotation.InitialRotationValue = rotation.Value;
        });
    }

    protected override void OnUpdate()
    {
        /*Entities.ForEach((ref Rotation rotation, ref LockXZRotationTag lockXZRotation) => {
            rotation.Value.value.x = lockXZRotation.InitialRotationValue.value.x;
            rotation.Value.value.z = lockXZRotation.InitialRotationValue.value.z;
        });*/
    }
}
