using ECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Systems.Multi
{
    public partial struct PulseMultiSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MultiComponent>();
        }

        public void OnUpdate(ref SystemState state)
        {
            PulseUpdateJob job = new() { Time = (float)SystemAPI.Time.ElapsedTime };
            job.ScheduleParallel();
        }

        private partial struct PulseUpdateJob : IJobEntity
        {
            public float Time;

            void Execute(in DancerComponent dancer, in WalkerComponent walker, ref LocalTransform transform)
            {
                float roSpeed = dancer.Speed * Time;
                transform.Scale = 1.1f - 0.3f * math.abs(math.cos(roSpeed));
            }
        }
    }
}