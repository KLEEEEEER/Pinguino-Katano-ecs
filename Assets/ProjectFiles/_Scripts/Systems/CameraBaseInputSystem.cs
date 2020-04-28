using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace PinguinoKatano.CameraBase
{
    public class CameraBaseInputSystem : ComponentSystem
    {
        protected override void OnStartRunning()
        {
            base.OnStartRunning();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

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
