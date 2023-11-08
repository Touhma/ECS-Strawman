using Unity.Entities;

namespace ECS.Components
{
    public struct WalkerComponent : IComponentData
    {
        public float ForwardSpeed;
        public float AngularSpeed;
    }
}