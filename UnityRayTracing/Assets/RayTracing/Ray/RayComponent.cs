using System;
using Unity.Entities;
using UnityEngine;

namespace lycoris
{
    [Serializable]
    public struct RayData : IComponentData
    {
        public Vector3 origin;
        public Vector3 direction;
        public float time;
    }

    public class RayComponent : ComponentDataWrapper<RayData>
    {
        public Vector3 GetPointAt(float factor)
        {
            return Value.direction * factor + Value.origin;
        }
    }
}

