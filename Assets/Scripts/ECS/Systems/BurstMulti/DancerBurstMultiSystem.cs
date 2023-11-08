using ECS.Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Systems
{
    public partial struct DancerBurstMultiSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BurstMultiComponent>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            DancerUpdateJob job = new() { Elapsed = (float)SystemAPI.Time.ElapsedTime };
            job.ScheduleParallel();
        }
        
        [BurstCompile]
        private partial struct DancerUpdateJob : IJobEntity
        {
            public float Elapsed;

            void Execute(in DancerComponent dancer, ref LocalTransform transform)
            {
                float roSpeed = dancer.Speed * Elapsed;
                float positionY = math.abs(math.sin(roSpeed)) * 0.1f;
                float bank = math.cos(roSpeed) * 0.5f;

                float3 forward = transform.Forward();
                quaternion axisAngle = quaternion.AxisAngle(forward, bank);
                float3 up = math.mul(axisAngle, math.float3(0, 1, 0));

                transform.Position.y = positionY;
                transform.Rotation = quaternion.LookRotation(forward, up);
            }
        }
    }
}