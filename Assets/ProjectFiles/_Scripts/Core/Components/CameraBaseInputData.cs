using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace PinguinoKatano.CameraBase
{
    [GenerateAuthoringComponent]
    public struct CameraBaseInputData : IComponentData
    {
        [HideInInspector] public float inputX;
        [HideInInspector] public float inputZ;
        [HideInInspector] public Vector3 LookPoint;
    }
}
