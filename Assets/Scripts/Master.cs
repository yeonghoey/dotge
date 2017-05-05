using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {

	public ShotNormal prefabShotNormal;
	public ShotAccel prefabShotAccel;
	public ShotHoming prefabShotHoming;

	private Transform player;
	private float startTime;
	private float areaRadius;

	private float DesiredMaxTime = 60.0f;

	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<Transform> ();
		startTime = Time.time;

		GameObject mainCamera = GameObject.FindWithTag ("MainCamera");
		float orthSize = mainCamera.GetComponent<Camera> ().orthographicSize;
		const float padding = 0.5f;
		const float margin = 10f; // TODO: Make meaningful;
		areaRadius = orthSize + margin;
		Debug.Assert (areaRadius > 0);
	}

	void Update () {
		float elapsed = Mathf.Round (Time.time - startTime);
		int additional = (int)Mathf.Pow (elapsed, 1.02f);
		int maxCount = 30 + additional;
		for (int i = transform.childCount; i < maxCount; i++) {
			float v = GaussianRandom (0, 1);
			float t = Mathf.Min(elapsed / DesiredMaxTime, 2.0f);
			if (Mathf.Abs (v) < 2.5f - t) {
				// CreateShotHoming ();
				CreateShotNormal ();
			} else {
				float v2 = GaussianRandom (0, 1);
				float t2 = Mathf.Min(elapsed / (DesiredMaxTime), 2.0f);
				if (Mathf.Abs (v2) < 2.5f - t2) {
					CreateShotAccel ();
				} else {
					CreateShotHoming ();
				}
			}
		}
	}

	void CreateShotNormal () {
		Vector2 pos = Random.insideUnitCircle.normalized * areaRadius;
		ShotNormal s = Instantiate (prefabShotNormal, pos, Quaternion.identity, transform);
		Vector2 direction = (player.position - s.transform.position).normalized;
		s.direction = direction;		
	}

	void CreateShotAccel () {
		Vector2 pos = Random.insideUnitCircle.normalized * areaRadius;
		ShotAccel s = Instantiate (prefabShotAccel, pos, Quaternion.identity, transform);
		Vector2 direction = (player.position - s.transform.position).normalized;
		s.direction = direction;		
	}

	void CreateShotHoming () {
		Vector2 pos = Random.insideUnitCircle.normalized * areaRadius;
		Instantiate (prefabShotHoming, pos, Quaternion.identity, transform);	
	}

	// Box–Muller transform
	// https://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform
	public static float GaussianRandom(float mu, float sigma)
	{

		float u1 = Random.Range(0.0f, 1.0f);
		float u2 = Random.Range(0.0f, 1.0f);
		float z0 = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Cos((2.0f * Mathf.PI) * u2);
		return (mu + sigma * z0);
	}
}
