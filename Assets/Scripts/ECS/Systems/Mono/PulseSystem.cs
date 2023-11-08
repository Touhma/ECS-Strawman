using ECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Systems
{
    public partial struct PulseSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MonoComponent>();
        }

        public void OnUpdate(ref SystemState state)
        {
            float elapsed = (float)SystemAPI.Time.ElapsedTime;

            foreach ((RefRO<DancerComponent> dancer, RefRO<WalkerComponent> walker, RefRW<LocalTransform> transform) in
                     SystemAPI.Query<RefRO<DancerComponent>,
                         RefRO<WalkerComponent>,
                         RefRW<LocalTransform>>())
            {
                float roSpeed = dancer.ValueRO.Speed * elapsed;
                transform.ValueRW.Scale = 1.1f - 0.3f * math.abs(math.cos(roSpeed));
            }
        }
    }
}