using Unity.Entities;
using Unity.Mathematics;

namespace ECS.Components
{
    public struct WalkerComponent : IComponentData
    {
        public float ForwardSpeed;
        public float AngularSpeed;
        
        public static WalkerComponent Random(uint seed)
        {
            Random random = new (seed);
            return new WalkerComponent(){ ForwardSpeed = random.NextFloat(0.1f, 0.8f),
                AngularSpeed = random.NextFloat(0.5f, 4) };
        }
    }
}