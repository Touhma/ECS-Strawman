using Unity.Mathematics;
using UnityEngine;

namespace GameObjectWay.Mono
{
    public class WalkerMono : MonoBehaviour
    {
        public float ForwardSpeed = 0.5f;
        public float AngularSpeed = 2;
        
        public void Update()
        {
            quaternion rotateY = quaternion.RotateY(AngularSpeed * Time.deltaTime);
            float3 forward = math.mul(rotateY, transform.forward);

            float3 position = (float3)transform.position + (forward * ForwardSpeed * Time.deltaTime);
            
            transform.SetPositionAndRotation(position,quaternion.LookRotation(forward, transform.up));
        }
    }
}
