using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;

namespace PinguinoKatano.Movement
{
    [BurstCompile]
    public class PlayerJumpingSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                /*Entities.WithAll<MainPlayerTag>().ForEach((ref PhysicsBody) => {
                    
                });*/
            }
        }
    }
}
