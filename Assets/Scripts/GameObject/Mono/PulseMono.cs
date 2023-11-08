using Unity.Mathematics;
using UnityEngine;

namespace GameObject.Mono
{
    public class PulseMono : MonoBehaviour
    {
        private float _elapsedTime;
        
        public float Speed = 1f;

        public void Update()
        {
            _elapsedTime +=  Time.deltaTime;
            float roSpeed = Speed * _elapsedTime;
            float scaleRatio = 1.1f - 0.3f * math.abs(math.cos(roSpeed));
            transform.localScale = new Vector3(scaleRatio,scaleRatio,scaleRatio);
        }
    }
}