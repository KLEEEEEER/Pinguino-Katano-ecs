using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace PinguinoKatano.Attacking
{
    public class SwordSwingSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.WithoutBurst().ForEach((ref AttackDamageData damage, in MovementData movement) =>
            {
                damage.Value = math.clamp((damage.Max - damage.Min) * (movement.TurnSpeed / movement.SpeedMaxRotationPerFrame), damage.Min, damage.Max);
                //damage.Value = movement.TurnSpeed / movement.SpeedMaxRotationPerFrame;
                //damage.Value = Mathf.Clamp(damage.Max - damage.Min * (movement.TurnSpeed / movement.SpeedMaxRotationPerFrame), damage.Min, damage.Max);
                Debug.Log(movement.TurnSpeed / movement.SpeedMaxRotationPerFrame);
            }).Run();
        }
    }
}
