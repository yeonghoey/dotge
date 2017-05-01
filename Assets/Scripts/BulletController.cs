using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float speed;

	private Vector2 direction;

	void Start () {
		GameObject player = GameObject.FindWithTag ("Player");
		direction = (player.transform.position - transform.position).normalized;
	}

	void FixedUpdate() {
		transform.Translate (direction * speed * Time.fixedDeltaTime);
	}
}
