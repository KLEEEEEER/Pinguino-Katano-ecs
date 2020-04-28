using UnityEngine;
using Unity.Entities;
using System;

public class PlayerInputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref MovementData moveData, in InputData inputData) => 
        {
            bool isRightKeyPressed = Input.GetKey(inputData.rightKey);
            bool isLeftKeyPressed = Input.GetKey(inputData.leftKey);
            bool isUpKeyPressed = Input.GetKey(inputData.upKey);
            bool isDownKeyPressed = Input.GetKey(inputData.downKey);

            moveData.Direction.x = Convert.ToInt32(isRightKeyPressed);
            moveData.Direction.x -= Convert.ToInt32(isLeftKeyPressed);
            moveData.Direction.z = Convert.ToInt32(isUpKeyPressed);
            moveData.Direction.z -= Convert.ToInt32(isDownKeyPressed);

        }).Run();
    }
}
