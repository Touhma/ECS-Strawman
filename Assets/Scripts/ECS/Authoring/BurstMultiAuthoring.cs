using ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace ECS.Authoring
{
    public class BurstMultiAuthoring : MonoBehaviour
    {
        private class Baker : Baker<BurstMultiAuthoring>
        {
            public override void Bake(BurstMultiAuthoring src)
            {
                AddComponent(GetEntity(TransformUsageFlags.Dynamic), new BurstMultiComponent());
            }
        }
    }
}