using System;
using UnityEngine;

namespace Dotge
{
	public static class Patterns

	{
		public delegate void  CreateShot(Vector2 position);

		public static void Circle(float degreeInit, float degreeTerm, float radius, CreateShot createShot)
		{
			Debug.Assert (degreeInit >= 0.0f && degreeInit <= 360.0f);
			Debug.Assert (degreeTerm >= 0.0f && degreeTerm <= 360.0f);
			Debug.Assert (radius >= 0.0f);

			for (float degree = degreeInit; degree <= 360.0f; degree += degreeTerm) {
				var v = MathHelper.DegreeToVector2 (degree);
				var pos = v * radius;
				createShot (pos);
			}
		}
	}
}