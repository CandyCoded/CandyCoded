using UnityEngine;

namespace CandyCoded
{

    public class Math
    {

        public static float Clerp(float start, float end, float value)
        {
            float max = 360;
            float half = max / 2;
            float diff = end - start;

            if (diff < -half)
            {
                return start + ((max - start) + end) * value;
            }

            if (diff > half)
            {
                return start - ((max - end) + start) * value;
            }

            return start + (end - start) * value;
        }

        public static Vector3 Clerp(Vector3 start, Vector3 end, float value)
        {

            return new Vector3(
                Clerp(start.x, end.x, value),
                Clerp(start.y, end.y, value),
                Clerp(start.z, end.z, value)
            );

        }

    }

}
