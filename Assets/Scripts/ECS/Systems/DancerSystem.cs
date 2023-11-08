using ECS.Components;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ECS.Systems
{
    public partial struct DancerSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            float elapsed = (float)SystemAPI.Time.ElapsedTime;

            foreach ((RefRO<DancerComponent> dancer, RefRW<LocalTransform> transform) in
                     SystemAPI.Query<RefRO<DancerComponent>,
                         RefRW<LocalTransform>>())
            {
                float roSpeed = dancer.ValueRO.Speed * elapsed;
                float positionY = math.abs(math.sin(roSpeed)) * 0.1f;
                float bank = math.cos(roSpeed) * 0.5f;

                float3 forward = transform.ValueRO.Forward();
                quaternion axisAngle = quaternion.AxisAngle(forward, bank);
                float3 up = math.mul(axisAngle, math.float3(0, 1, 0));

                transform.ValueRW.Position.y = positionY;
                transform.ValueRW.Rotation = quaternion.LookRotation(forward, up);
            }
        }
    }
}
