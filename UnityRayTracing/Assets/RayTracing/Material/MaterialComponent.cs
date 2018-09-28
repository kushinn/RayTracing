using Unity.Entities;
using UnityEngine;

namespace lycoris
{
    public interface IMaterialData : IComponentData
    {

    }

    public interface IMaterialComponent
    {
        bool Scatter(RayComponent ray, ref HitInfo result, ref ScatterInfo info);
        Vector3 Emmitted(RayComponent rayIn, ref HitInfo result, float u, float v, Vector3 point);
    }

    public abstract class MaterialComponent<TMaterialData> : ComponentDataWrapper<TMaterialData>, IMaterialData
        where TMaterialData : struct, IMaterialData
    {
        public virtual bool Scatter(RayComponent ray, ref HitInfo result, ref ScatterInfo info)
        {
            return false;
        }

        public virtual Vector3 Emmitted(RayComponent rayIn, ref HitInfo result, float u, float v, Vector3 point)
        {
            return Vector3.zero;
        }


    }
}
