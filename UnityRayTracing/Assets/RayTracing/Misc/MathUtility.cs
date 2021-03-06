﻿using Unity.Mathematics;
using UnityEngine;

namespace lycoris
{
    public static class MathUtility
    {
        /// <summary>
        /// F_schlick = F0 + (1 - F0)*((1 - NDotL)^5)
        /// F0 = ((1-n)/(1+n))^2;
        /// </summary>
        /// <param name="NDotL"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static float FresnelSchlick(float NDotL, float n)
        {
            float F0 = (1 - n) / (1 + n);
            F0 = F0 * F0;
            return F0 + (1 - F0) * math.pow(1 - NDotL, 5.0f);
        }

        /// <summary>
        /// Refract
        /// </summary>
        /// <param name="v"></param>
        /// <param name="n"></param>
        /// <param name="ni_over_nt"></param>
        /// <param name="refracted"></param>
        /// <returns></returns>
        public static bool Refract(float3 v, float3 n, float ni_over_nt, out Vector3 refracted)
        {
            float3 normalizedV = math.normalize(v);
            float dt = math.dot(normalizedV, n);
            float discriminant = 1.0f - ni_over_nt * ni_over_nt * (1 - dt * dt);
            if (discriminant > 0.0f)
            {
                refracted = ni_over_nt * ((normalizedV) - n * dt) - n * math.sqrt(discriminant);
                return true;
            }

            refracted = Vector3.zero;
            return false;
        }

        public static bool Hit(RayComponent r, float min, float max, AABB aabb, ref HitInfo info)
        {

            return false;
        }
    }
}
