using ECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Systems
{
    public partial struct WalkerSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            float elapsed = SystemAPI.Time.DeltaTime;

            foreach ((RefRO<WalkerComponent> walker, RefRW<LocalTransform> transform) in
                     SystemAPI.Query<RefRO<WalkerComponent>,
                         RefRW<LocalTransform>>())
            {
                quaternion rotateY = quaternion.RotateY(walker.ValueRO.AngularSpeed * elapsed);
                float3 forward = math.mul(rotateY, transform.ValueRO.Forward());
                transform.ValueRW.Position += forward * walker.ValueRO.ForwardSpeed * elapsed;
                transform.ValueRW.Rotation = quaternion.LookRotation(forward, transform.ValueRO.Up());
            }
        }
    }
}
