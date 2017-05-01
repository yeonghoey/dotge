using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody2D body;
	private Vector2 direction;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		direction = new Vector2 (h, v).normalized;
	}

	void FixedUpdate() {
		transform.Translate (direction * speed * Time.fixedDeltaTime);
	}
}
