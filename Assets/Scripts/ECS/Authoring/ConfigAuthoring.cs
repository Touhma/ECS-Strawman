using ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace ECS.Authoring
{
    public class ConfigAuthoring : MonoBehaviour
    {
        public GameObject Prefab = null;
        public float SpawnRadius = 1;
        public int SpawnCount = 10;
        public uint RandomSeed = 100;

        class Baker : Baker<ConfigAuthoring>
        {
            public override void Bake(ConfigAuthoring src)
            {
                ConfigComponent data = new ConfigComponent()
                {
                    Prefab = GetEntity(src.Prefab, TransformUsageFlags.Dynamic),
                    SpawnRadius = src.SpawnRadius,
                    SpawnCount = src.SpawnCount,
                    RandomSeed = src.RandomSeed
                };
                AddComponent(GetEntity(TransformUsageFlags.None), data);
            }
        }
    }
}
