using UnityEngine;
using Unity.Entities;
using System;
using PinguinoKatano.Attacking;

public class PlayerInputSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, ref MovementData moveData, ref InputData inputData) => 
        {
            bool isRightKeyPressed = Input.GetKey(inputData.rightKey);
            bool isLeftKeyPressed = Input.GetKey(inputData.leftKey);
            bool isUpKeyPressed = Input.GetKey(inputData.upKey);
            bool isDownKeyPressed = Input.GetKey(inputData.downKey);

            moveData.Direction.x = Convert.ToInt32(isRightKeyPressed);
            moveData.Direction.x -= Convert.ToInt32(isLeftKeyPressed);
            moveData.Direction.z = Convert.ToInt32(isUpKeyPressed);
            moveData.Direction.z -= Convert.ToInt32(isDownKeyPressed);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                PostUpdateCommands.AddComponent(entity, new AttackReadyTag());
            }
            else
            {
                PostUpdateCommands.RemoveComponent<AttackReadyTag>(entity);
            }

        });
    }
}
