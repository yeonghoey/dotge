using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;

	private Vector2 direction;

	void Update () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		direction = new Vector2 (h, v).normalized;
	}

	void FixedUpdate() {
		transform.Translate (direction * speed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Bullet")) {
			gameObject.SetActive (false);
		}
	}
}
