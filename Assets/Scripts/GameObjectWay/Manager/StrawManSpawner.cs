using GameObjectWay.Mono;
using UnityEngine;
using Utils;
using Random = Unity.Mathematics.Random;

namespace GameObjectWay.Manager
{
    public class StrawManSpawner : MonoBehaviour
    {
        public GameObject Pulse;
        
        public float SpawnRadius;
        public int SpawnNumber;
        public uint Seed;
        
        private Random _rand;

        public void Start()
        {
            _rand = new Random(Seed);

            for (int i = 0; i < SpawnNumber; i++)
            {
                GameObject dancerGameObject = Instantiate(Pulse);
                DancerMono dancerInstance = dancerGameObject.GetComponent<DancerMono>();
                dancerInstance.Speed = new Random(_rand.NextUInt()).NextFloat(1, 8);
                dancerGameObject.transform.SetPositionAndRotation(_rand.NextOnDisk() * SpawnRadius, _rand.NextYRotation());
            }
        }
    }
}