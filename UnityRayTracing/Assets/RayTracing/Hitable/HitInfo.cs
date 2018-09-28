using UnityEngine;

namespace lycoris
{
    public struct HitInfo
    {
        public float t;
        public float u;
        public float v;
        public Vector3 position;
        public Vector3 normal;
        public IMaterialComponent material;
    }
}
