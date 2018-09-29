using Unity.Entities;
using UnityEngine;

namespace lycoris
{
    public interface IHitableData : IComponentData
    {
    }

    public interface IHitableComponent
    {
        bool Hit(RayComponent ray, float min, float max, ref HitInfo info);
    }

    [UnityEngine.DisallowMultipleComponent]
    public abstract class HitableComponent<THitableData> : ComponentDataWrapper<THitableData>, IHitableComponent
        where THitableData : struct, IHitableData
    {
        public abstract bool Hit(RayComponent ray, float min, float max, ref HitInfo info);
    }
}
