using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {

	public GameObject bullet;

	void Start () {
		// TODO: Make count parameter other than magic number 30
		// TODO: Use camera size other than magic number 16;
		for (int i = 0; i < 30; ++i) {
			Vector2 pos = Random.insideUnitCircle.normalized * 16;
			Instantiate (bullet, pos, Quaternion.identity, transform);
		}
	}
}
