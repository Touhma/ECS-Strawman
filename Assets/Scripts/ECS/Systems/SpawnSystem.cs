using ECS.Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Utils;

namespace ECS.Systems
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
            => state.RequireForUpdate<ConfigComponent>();

        public void OnUpdate(ref SystemState state)
        {
            ConfigComponent config = SystemAPI.GetSingleton<ConfigComponent>();

            NativeArray<Entity> instances = state.EntityManager.Instantiate
                (config.Prefab, config.SpawnCount, Allocator.Temp);

            Random rand = new(config.RandomSeed);

            foreach (Entity entity in instances)
            {
                RefRW<LocalTransform> transform = SystemAPI.GetComponentRW<LocalTransform>(entity);
                RefRW<DancerComponent> dancer = SystemAPI.GetComponentRW<DancerComponent>(entity);
                RefRW<WalkerComponent> walker = SystemAPI.GetComponentRW<WalkerComponent>(entity);

                transform.ValueRW = LocalTransform.FromPositionRotation(rand.NextOnDisk() * config.SpawnRadius, rand.NextYRotation());

                dancer.ValueRW = DancerComponent.Random(rand.NextUInt());
                walker.ValueRW = WalkerComponent.Random(rand.NextUInt());
            }

            state.Enabled = false;
        }
    }
}