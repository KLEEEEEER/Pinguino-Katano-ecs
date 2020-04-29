using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Physics;

public class LockXZRotationSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref PhysicsMass physics, ref LockXZRotationTag lockXZRotation) =>
        {
            physics.InverseInertia[0] = lockXZRotation.LockX ? 0 : physics.InverseInertia[0];
            physics.InverseInertia[1] = lockXZRotation.LockY ? 0 : physics.InverseInertia[1];
            physics.InverseInertia[2] = lockXZRotation.LockZ ? 0 : physics.InverseInertia[2];
        });
    }
}
