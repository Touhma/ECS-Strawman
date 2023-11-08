using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Components
{
    public struct DancerComponent : IComponentData
    {
        public float Speed;
        
        public static DancerComponent Random(uint seed) => new (){ Speed = new Random(seed).NextFloat(1, 8) };
    }
}
