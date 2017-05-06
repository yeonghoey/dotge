using System;
using UnityEngine;
using Patterns = Dotge.Patterns;

public class Master : MonoBehaviour {
	public ShotNormal shotNormal;

	[NonSerialized]
	public Transform player;

	private float startTime;
	private float areaRadius;

	void Start () {
		Patterns.Circle (0.0f, 36.0f, 16, (pos) => CreateShotNormal (pos, Vector2.zero, 5.0f));
		Patterns.Circle (12.0f, 36.0f, 16, (pos) => CreateShotNormal (pos, Vector2.zero, 5.0f));
		Patterns.Circle (24.0f, 36.0f, 16, (pos) => CreateShotNormal (pos, Vector2.zero, 5.0f));
	}

	void CreateShotNormal (Vector2 pos, Vector2 target, float speed) {
		ShotNormal s = Instantiate (shotNormal, pos, Quaternion.identity, transform);
		s.direction = (target - pos).normalized;
		s.speed = speed;
	}
}
