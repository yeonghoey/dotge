using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector2 direction;
	public float speed;

	void Start () {
		GameObject player = GameObject.FindWithTag ("Player");
		direction = (player.transform.position - transform.position).normalized;
	}

	void FixedUpdate() {
		transform.Translate (direction * speed * Time.fixedDeltaTime);
	}
}
