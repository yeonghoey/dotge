﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Vector2 direction;
	public float speed;

	void FixedUpdate() {
		transform.Translate (direction * speed * Time.fixedDeltaTime);
	}
}