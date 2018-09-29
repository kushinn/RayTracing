using System;
using Unity.Mathematics;
using UnityEngine;

namespace lycoris
{
    [Serializable]
    public struct DielectricMaterialData : IMaterialData
    {
        public float refractiveIndex;
    }

    public class DielectricMaterialComponent : MaterialComponent<DielectricMaterialData>
    {
        public override bool Scatter(RayComponent ray, ref HitInfo result, ref ScatterInfo scatterInfo)
        {
            scatterInfo.attenuation = Color.white;
            scatterInfo.position = result.position;

            float refIdx = Value.refractiveIndex;

            float ni_over_nt;
            Vector3 outwardNormal;
            float cosine = math.dot(ray.Value.direction, result.normal);
            if (cosine > 0.0f)
            {
                outwardNormal = -result.normal;
                ni_over_nt = refIdx;
                cosine = ni_over_nt * cosine / math.length(ray.Value.direction);
            }
            else
            {
                outwardNormal = result.normal;
                ni_over_nt = 1.0f / refIdx;
                cosine = -cosine / math.length(ray.Value.direction);
            }

            float reflectProb = 1.0f;
            Vector3 refracted;
            if (MathUtility.Refract(ray.Value.direction, outwardNormal, ni_over_nt, out refracted))
            {
                reflectProb = MathUtility.FresnelSchlick(cosine, refIdx);
            }

            if (RandomUtility.RandomNDF() < reflectProb)
            {
                scatterInfo.direction = math.reflect(ray.Value.direction, result.normal);
            }
            else
            {
                scatterInfo.direction = refracted;
            }

            return true;
        }
    }
}
