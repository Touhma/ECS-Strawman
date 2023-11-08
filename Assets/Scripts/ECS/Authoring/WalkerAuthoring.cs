using ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace ECS.Authoring
{
    public class WalkerAuthoring : MonoBehaviour
    {
        public float ForwardSpeed = 0.5f;
        public float AngularSpeed = 2;

        class Baker : Baker<WalkerAuthoring>
        {
            public override void Bake(WalkerAuthoring src)
            {
                WalkerComponent data = new ()
                {
                    ForwardSpeed = src.ForwardSpeed,
                    AngularSpeed = src.AngularSpeed
                };
                AddComponent(GetEntity(TransformUsageFlags.Dynamic), data);
            }
        }
    }
}
