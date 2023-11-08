using Unity.Mathematics;
using UnityEngine;

namespace GameObject.Mono
{
    public class DancerMono : MonoBehaviour
    {
        public float Speed = 1f;

        private float _elapsedTime;

        private void Update()
        {
            _elapsedTime +=  Time.deltaTime;
            float roSpeed = Speed * _elapsedTime;
            float positionY = math.abs(math.sin(roSpeed)) * 0.1f;
            float bank = math.cos(roSpeed) * 0.5f;

            float3 forward = transform.forward;
            quaternion axisAngle = quaternion.AxisAngle(forward, bank);
            float3 up = math.mul(axisAngle, math.float3(0, 1, 0));

            float3 position = transform.position;
            position.y = positionY;
            transform.SetPositionAndRotation(position,quaternion.LookRotation(forward, up));
        }
    }
}
