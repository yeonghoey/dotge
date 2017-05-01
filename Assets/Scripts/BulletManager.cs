using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

	public GameObject bullet;
	public int count;

	void Start () {
		for (int i = 0; i < count; ++i) {
			Vector2 pos = Random.insideUnitCircle.normalized * 16;
			Instantiate (bullet, pos, Quaternion.identity);
		}
	}
}
