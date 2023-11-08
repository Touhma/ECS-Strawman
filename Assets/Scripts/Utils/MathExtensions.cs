using Unity.Mathematics;

namespace Utils
{
    public static class MathExtensions
    {
        public static float3 NextOnDisk(this ref Random self)
        {
            while (true)
            {
                float2 v = self.NextFloat2(-1, 1);
                if (math.length(v) <= 1) return math.float3(v.x, 0, v.y);
            }
        }

        public static quaternion NextYRotation(this ref Random self)
            => quaternion.RotateY(self.NextFloat(math.PI * 2));
    }
}
