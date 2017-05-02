using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject titleCover;
	public Text scoreText;

	public GameObject prefabPlayer;
	public GameObject prefabMaster;
	public GameObject prefabScorer;

	private float highScore;
	private bool pressed;
	private GameObject player;
	private GameObject master;
	private GameObject scorer;

	void Start () {
		highScore = 0.0f;
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
		titleCover.SetActive (true);
		scoreText.text = Scorer.Format (highScore);

		pressed = false;

		while (!pressed) {
			yield return null;
		}
	}

	IEnumerator Play () {
		titleCover.SetActive (false);

		player = Instantiate (prefabPlayer);
		master = Instantiate (prefabMaster);
		scorer = Instantiate (prefabScorer);
		scorer.GetComponent<Scorer> ().scoreText = scoreText;

		yield return null;

		while (player.activeInHierarchy) {
			yield return null;
		}
	}

	IEnumerator End () {
		Destroy (player);
		Destroy (master);
		float lastScore = scorer.GetComponent<Scorer> ().Score;
		Destroy (scorer);

		if (lastScore > highScore) {
			highScore = lastScore;
		}

		yield return new WaitForSeconds (3.0f);
	}
}