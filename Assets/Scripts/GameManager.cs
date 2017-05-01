using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject cover;
	public GameObject prefabPlayer;
	public GameObject prefabMaster;

	private bool pressed;
	private GameObject player;
	private GameObject master;

	void Start () {
		StartCoroutine (GameLoop ());
	}

	void Update () {
		pressed = pressed || Input.anyKey;
	}

	IEnumerator GameLoop () {
		while (true) {
			yield return StartCoroutine (Wait ());
			yield return StartCoroutine (Play ());
			yield return StartCoroutine (End ());
		}
	}

	IEnumerator Wait () {
		Reset ();
		while (!pressed) {
			yield return null;
		}
	}

	IEnumerator Play () {
		Init ();
		Debug.Assert (player != null);
		yield return null;

		while (player.activeInHierarchy) {
			yield return null;
		}
	}

	IEnumerator End () {
		Clear ();
		yield return new WaitForSeconds (3.0f);
	}

	void Reset () {
		pressed = false;
		cover.SetActive (true);
	}

	void Init () {
		cover.SetActive (false);
		player = Instantiate (prefabPlayer);
		master = Instantiate (prefabMaster);
	}

	void Clear () {
		Destroy (player);
		Destroy (master);
	}
}