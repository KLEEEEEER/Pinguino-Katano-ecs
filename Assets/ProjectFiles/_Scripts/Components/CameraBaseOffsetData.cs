using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace PinguinoKatano.CameraBase
{
    [GenerateAuthoringComponent]
    public struct CameraBaseOffsetData : IComponentData
    {
        public float3 Value;
    }
}
