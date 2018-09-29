using System;
using Unity.Mathematics;
using UnityEngine;

namespace lycoris
{
    [Serializable]
    public struct MetalMaterialData : IMaterialData
    {
        public Color albedo;
        public float fuzz;
    }

    public class MetalMaterialComponent : MaterialComponent<MetalMaterialData>
    {
        public override bool Scatter(RayComponent ray, ref HitInfo result, ref ScatterInfo info)
        {
            float fuzz = Value.fuzz;
            Color albedo = Value.albedo;

            Vector3 reflected = math.reflect(ray.Value.direction, result.normal);
            info.direction = reflected + fuzz * RandomUtility.RandomInUnitSphere();
            info.attenuation = albedo;
            info.position = result.position;
            return false;
        }
    }
}
