using ECS.Components;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace ECS.Authoring
{
    public class DancerAuthoring : MonoBehaviour
    {
        public float Speed = 1;

        private class Baker : Baker<DancerAuthoring>
        {
            public override void Bake(DancerAuthoring src)
            {
                DancerComponent data = new (){ Speed = src.Speed };
                AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
            }
        }
    }
}
