using ECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Systems.Multi
{
    public partial struct WalkerMultiSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<MultiComponent>();
        }

        public void OnUpdate(ref SystemState state)
        {
            WalkerUpdateJob job = new() { DeltaTime = SystemAPI.Time.DeltaTime };
            job.ScheduleParallel();
        }

        private partial struct WalkerUpdateJob : IJobEntity
        {
            public float DeltaTime;

            void Execute(in WalkerComponent walker, ref LocalTransform transform)
            {
                quaternion rotateY = quaternion.RotateY(walker.AngularSpeed * DeltaTime);
                float3 forward = math.mul(rotateY, transform.Forward());
                transform.Position += forward * walker.ForwardSpeed * DeltaTime;
                transform.Rotation = quaternion.LookRotation(forward, transform.Up());
            }
        }
    }
}