using UnityEngine;

namespace Dotge
{
    public static class MathHelper
    {
        public static Vector2 RadianToVector2(float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }

        public static Vector2 DegreeToVector2(float degree)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad);
        }

        public static Vector2 RotateVector2(Vector2 v, float degree)
        {
            float rad = degree * Mathf.Deg2Rad;
            float sin = Mathf.Sin(rad);
            float cos = Mathf.Cos(rad);
            float x = (v.x * cos) - (v.y * sin);
            float y = (v.x * sin) + (v.y * cos);
            return new Vector2(x, y);
        }
    }
}
