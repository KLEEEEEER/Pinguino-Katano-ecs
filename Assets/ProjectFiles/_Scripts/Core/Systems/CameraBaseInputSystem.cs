using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;

namespace PinguinoKatano.CameraBase
{
    public class CameraBaseInputSystem : ComponentSystem
    {

        protected override void OnUpdate()
        {
            float deltaTime = Time.DeltaTime;

            Entities.ForEach((ref CameraBaseInputData inputData) =>
            {
                inputData.inputX = Input.GetAxisRaw("Mouse X") * deltaTime;
                inputData.inputZ = Input.GetAxisRaw("Mouse Y") * deltaTime;
            });
        }
    }
}
