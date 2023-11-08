using ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace ECS.Authoring
{
    public class MonoAuthoring : MonoBehaviour
    {
        private class Baker : Baker<MonoAuthoring>
        {
            public override void Bake(MonoAuthoring src)
            {
                AddComponent(GetEntity(TransformUsageFlags.Dynamic), new MonoComponent());
            }
        }
    }
}