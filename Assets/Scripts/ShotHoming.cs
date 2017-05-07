using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHoming : ShotBehaviour {

	public float speed;

	private Transform player;
	private Vector2 direction;

	void Start() {
		GameObject go = GameObject.FindWithTag ("Player");
		if (go != null) {
			player = go.GetComponent<Transform>();
		}
		direction = Vector2.zero;
	}

	void Update() {
		if (player != null) {
			Vector2 to = (player.position - transform.position).normalized;
			direction = (direction + (to * 0.04f)).normalized;
		}
	}

	void FixedUpdate() {
		transform.Translate (direction * Time.fixedDeltaTime * speed);
	}
}
