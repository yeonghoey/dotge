using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {

	public Bullet bullet;

	private Transform player;
	private float startTime;
	private float areaRadius;

	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<Transform> ();
		startTime = Time.time;

		GameObject mainCamera = GameObject.FindWithTag ("MainCamera");
		float orthSize = mainCamera.GetComponent<Camera> ().orthographicSize;
		const float padding = 0.5f;
		areaRadius = orthSize - padding;
		Debug.Assert (areaRadius > 0);
	}

	void Update () {
		float elapsed = Mathf.Round (Time.time - startTime);
		int additional = (int)Mathf.Pow (elapsed, 1.05f);
		int maxCount = 30 + additional;
		for (int i = transform.childCount; i < maxCount; i++) {
			CreateBullet ();
		}
	}

	void CreateBullet () {
		
		Vector2 pos = Random.insideUnitCircle.normalized * areaRadius;
		Bullet b = Instantiate (bullet, pos, Quaternion.identity, transform);
		Vector2 direction = (player.position - b.transform.position).normalized;
		b.direction = direction;		
	}
}
