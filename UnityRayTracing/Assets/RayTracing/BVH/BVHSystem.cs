using Unity.Entities;
using System.Collections.Generic;
using Unity.Collections;

namespace lycoris
{
    public class BVHSystem : ComponentSystem
    {
        private ComponentGroup bvhGroup;

        protected override void OnCreateManager()
        {
            base.OnCreateManager();
            bvhGroup = GetComponentGroup(
                ComponentType.ReadOnly(typeof(BVHNodeData)));

            

        }

        /// <summary>
        /// Called once per frame on the main thread.
        /// </summary>
        protected override void OnUpdate()
        {


            Enabled = false;
        }
    }
}
