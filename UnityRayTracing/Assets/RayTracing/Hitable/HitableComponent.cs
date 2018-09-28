using Unity.Entities;
using UnityEngine;

namespace lycoris
{
    public interface IHitableData : IComponentData
    {
    }

    public interface IHitableComponent
    {
        bool Hit(Ray ray, float min, float max, HitInfo info);
    }

    public abstract class HitableComponent<THitableData> : ComponentDataWrapper<THitableData>, IHitableComponent
        where THitableData : struct, IHitableData
    {
        public abstract bool Hit(Ray ray, float min, float max, HitInfo info);
    }
}
