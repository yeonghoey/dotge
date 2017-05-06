using UnityEngine;

namespace Dotge
{
	public static class Patterns
	{
		public delegate void Spawn(Vector2 pos, Vector2 dir);
		public delegate void SpawnAt(Vector2 pos);

		public static void Circle(Vector2 center, float radius, float offset, float interval, SpawnAt spawnAt)
		{
			for (float degree = offset; degree <= 360.0f; degree += interval) {
				var v = MathHelper.DegreeToVector2 (degree);
				var position = center + (v * radius);
				spawnAt (position);
			}
		}

		public static void RandomOnCircle(Vector2 center, float radius, int count, SpawnAt spawnAt)
		{
			for (int i = 0; i < count; i++) {
				var v = Random.insideUnitCircle.normalized;
				var position = center + (v * radius);
				spawnAt (position);
			}
		}

		public static void Nway(Vector2 center, Vector2 front, float interval, int count, Spawn spawn)
		{
			float degree = -(interval * (count / 2));

			if (count % 2 == 0) {
				degree += interval / 2.0f;
			}

			for (int i = 0; i < count; i++) 
			{
				var pos = center;
				var dir = MathHelper.RotateVector2 (front, degree).normalized;
				spawn (pos, dir);
				degree += interval;
			}
		}
	}
}