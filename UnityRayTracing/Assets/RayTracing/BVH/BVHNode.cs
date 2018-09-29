namespace lycoris
{
    public struct BVHNodeData : IHitableData
    {
        public AABB aabb;
        public IHitableComponent left;
        public IHitableComponent right;
    }

    [UnityEngine.DisallowMultipleComponent]
    public class BVHNode : HitableComponent<BVHNodeData>
    {
        public override bool Hit(RayComponent ray, float min, float max, ref HitInfo result)
        {
            AABB aabb = Value.aabb;
            IHitableComponent left = Value.left;
            IHitableComponent right = Value.right;

            HitInfo centerHitInfo = new HitInfo();
            if (MathUtility.Hit(ray, min, max, aabb, ref centerHitInfo))
            {
                HitInfo leftHitInfo = new HitInfo();
                bool hitLeft = left.Hit(ray, min, max, ref leftHitInfo);
                HitInfo rightHitInfo = new HitInfo();
                bool hitRight = right.Hit(ray, min, max, ref rightHitInfo);

                if (hitLeft && hitRight)
                {
                    if (leftHitInfo.t < rightHitInfo.t)
                        result = leftHitInfo;
                    else
                        result = rightHitInfo;
                    return true;
                }

                if (hitLeft)
                {
                    result = leftHitInfo;
                    return true;
                }

                if (hitRight)
                {
                    result = rightHitInfo;
                    return true;
                }
                
                // miss
            }
            return false;
        }
    }
}
