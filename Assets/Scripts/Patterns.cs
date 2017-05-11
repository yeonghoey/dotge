using UnityEngine;

namespace Dotge
{
    public static class Patterns
    {
        public delegate void SpawnShot(Vector2 pos, Vector2 dir);
        public delegate Vector2 FromTo(Vector2 pos);

        public static void Circle(Vector2 center, float radius, float offset, float interval, FromTo fromTo, SpawnShot spawnShot)
        {
            for (float degree = offset; degree <= 360.0f; degree += interval)
            {
                var v = MathHelper.DegreeToVector2(degree);
                var pos = center + (v * radius);
                var dir = fromTo(pos);
                spawnShot(pos, dir);
            }
        }

        public static void RandomOnCircle(Vector2 center, float radius, int count, FromTo fromTo, SpawnShot spawnShot)
        {
            for (int i = 0; i < count; i++)
            {
                var v = Random.insideUnitCircle.normalized;
                var pos = center + (v * radius);
                var dir = fromTo(pos);
                spawnShot(pos, dir);
            }
        }

        public static void Rect(Vector2 center, float width, float height, int countBySide, FromTo fromTo, SpawnShot spawnShot)
        {
            Vector2 tl = new Vector2(center.x - (width * 0.5f), center.y - (height * 0.5f));
            Vector2 br = new Vector2(center.x + (width * 0.5f), center.y + (height * 0.5f));
            Vector2 tr = new Vector2(br.x, tl.y);
            Vector2 bl = new Vector2(tl.x, br.y);
            Line(tl, tr, 0, countBySide, fromTo, spawnShot);
            Line(tr, br, 0, countBySide, fromTo, spawnShot);
            Line(bl, br, 0, countBySide, fromTo, spawnShot);
            Line(tl, bl, 0, countBySide, fromTo, spawnShot);
        }

        public static void Diamond(Vector2 center, float width, float height, int countBySide, FromTo fromTo, SpawnShot spawnShot)
        {
            Vector2 t = new Vector2(center.x, center.y - (height * 0.5f));
            Vector2 r = new Vector2(center.x + (width * 0.5f), center.y);
            Vector2 b = new Vector2(center.x, center.y + (height * 0.5f));
            Vector2 l = new Vector2(center.x - (width * 0.5f), center.y);
            Line(t, r, 0, countBySide, fromTo, spawnShot);
            Line(r, b, 0, countBySide, fromTo, spawnShot);
            Line(b, l, 0, countBySide, fromTo, spawnShot);
            Line(l, t, 0, countBySide, fromTo, spawnShot);
        }

        public static void Line(Vector2 a, Vector2 b, float padding, int count, FromTo fromTo, SpawnShot spawnShot)
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
