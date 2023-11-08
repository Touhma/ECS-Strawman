using ECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Systems
{
    public partial struct WalkerSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MonoComponent>();
        }

        public void OnUpdate(ref SystemState state)
        {
            foreach ((RefRO<WalkerComponent> walker, RefRW<LocalTransform> transform) in
                     SystemAPI.Query<RefRO<WalkerComponent>,
                         RefRW<LocalTransform>>())
            {
                quaternion rotateY = quaternion.RotateY(walker.ValueRO.AngularSpeed * SystemAPI.Time.DeltaTime);
                float3 forward = math.mul(rotateY, transform.ValueRO.Forward());
                transform.ValueRW.Position += forward * walker.ValueRO.ForwardSpeed * SystemAPI.Time.DeltaTime;
                transform.ValueRW.Rotation = quaternion.LookRotation(forward, transform.ValueRO.Up());
            }
        }
    }
}