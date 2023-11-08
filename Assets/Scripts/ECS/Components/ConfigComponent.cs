using Unity.Entities;

namespace ECS.Components
{
    public struct ConfigComponent : IComponentData
    {
        public Entity Prefab;
        public float SpawnRadius;
        public int SpawnCount;
        public uint RandomSeed;
    }
}