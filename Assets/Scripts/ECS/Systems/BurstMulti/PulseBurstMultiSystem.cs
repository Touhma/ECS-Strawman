using ECS.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Systems.BurstMulti
{
    [BurstCompile]
    public partial struct PulseBurstMultiSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BurstMultiComponent>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            PulseUpdateJob job = new() { Time = (float)SystemAPI.Time.ElapsedTime };
            job.ScheduleParallel();
        }
        
        [BurstCompile]
        private partial struct PulseUpdateJob : IJobEntity
        {
            public float Time;

            [BurstCompile]
            void Execute(in DancerComponent dancer, in WalkerComponent walker, ref LocalTransform transform)
            {
                float roSpeed = dancer.Speed * Time;
                transform.Scale = 1.1f - 0.3f * math.abs(math.cos(roSpeed));
            }
        }
    }
}