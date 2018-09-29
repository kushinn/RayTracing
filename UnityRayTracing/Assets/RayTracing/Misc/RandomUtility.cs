using UnityEngine;
using Random = System.Random;

namespace lycoris
{
    public static class RandomUtility
    {
        private static readonly System.Random random = new Random();

        public static float RandomNDF()
        {
            return (float)random.NextDouble();
        }

        public static float Random01()
        {
            return (float)random.NextDouble();
        }

        public static Vector3 RandomInUnitSphere()
        {
            return new Vector3(Random01(), Random01(), Random01()).normalized;
        }
    }
}
