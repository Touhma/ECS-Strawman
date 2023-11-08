using ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace ECS.Authoring
{
    public class MultiAuthoring : MonoBehaviour
    {
        private class Baker : Baker<MultiAuthoring>
        {
            public override void Bake(MultiAuthoring src)
            {
                AddComponent(GetEntity(TransformUsageFlags.Dynamic), new MultiComponent());
            }
        }
    }
}