using UnityEngine;

namespace Dotge
{
    public static class Patterns
    {
        public delegate void SpawnShot(Vector2 pos, Vector2 dir);
        public delegate Vector2 FromTo(Vector2 pos);

        public static void Circle(Vector2 center, float radius, float offset, float interval, SpawnShot spawnShot, FromTo fromTo)
        {
            for (float degree = offset; degree <= 360.0f; degree += interval)
            {
                var v = MathHelper.DegreeToVector2(degree);
                var pos = center + (v * radius);
                var dir = fromTo(pos);
                spawnShot(pos, dir);
            }
        }

        public static void RandomOnCircle(Vector2 center, float radius, int count, SpawnShot spawnShot, FromTo fromTo)
        {
            for (int i = 0; i < count; i++)
            {
                var v = Random.insideUnitCircle.normalized;
                var pos = center + (v * radius);
                var dir = fromTo(pos);
                spawnShot(pos, dir);
            }
        }

        public static void Line(Vector2 a, Vector2 b, float padding, int count, SpawnShot spawnShot, FromTo fromTo)
        {
            Vector2 d = (b - a).normalized;
            Vector2 aa = a + (d * padding);
            Vector2 bb = b - (d * padding);

            Debug.Assert(count > 1);
            Vector2 unit = d * ((bb - aa).magnitude / (count - 1));

            var pos = aa;
            for (int i = 0; i < count; i++)
            {
                var dir = fromTo(pos);
                spawnShot(pos, dir);
                pos += unit;
            }
        }

        public static void Nway(Vector2 center, Vector2 front, float interval, int count, SpawnShot spawnShot)
        {
            float degree = -(interval * (count / 2));

            if (count % 2 == 0)
            {
                degree += interval / 2.0f;
            }

            for (int i = 0; i < count; i++)
            {
                var pos = center;
                var dir = MathHelper.RotateVector2(front, degree).normalized;
                spawnShot(pos, dir);
                degree += interval;
            }
        }
    }
}
