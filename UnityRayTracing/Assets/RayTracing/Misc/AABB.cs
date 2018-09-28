using UnityEngine;

namespace lycoris
{
    public struct AABB
    {
        public Vector2 min;
        public Vector3 max;

        public float Area
        {
            get
            {
                var x = max.x - min.x;
                var y = max.x - min.x;
                var z = max.x - min.x;
                return 2.0f * (x * y + y * z + x * z);
            }
        }

        public Asix LongestAsix
        {
            get
            {
                var x = max.x - min.x;
                var y = max.x - min.x;
                var z = max.x - min.x;
                if (x > y && x > z)
                    return Asix.Right;
                else if (y > z)
                    return Asix.Up;
                return Asix.Forward;

            }
        }
    }
}
