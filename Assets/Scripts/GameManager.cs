using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dotge
{
	public class GameManager : MonoBehaviour
	{

		public GameObject titleCover;
		public Text scoreText;

		public Player prefabPlayer;
		public Master prefabMaster;
		public Scorer prefabScorer;

		private float highScore;
		private bool pressed;
		private Player player;
		private Master master;
		private Scorer scorer;

		void Start ()
		{
			highScore = 0.0f;
			StartCoroutine (GameLoop ());
		}

		void Update ()
		{
			pressed = pressed || Input.anyKey;
		}

		IEnumerator GameLoop ()
		{
			while (true) {
				yield return StartCoroutine (Wait ());
				yield return StartCoroutine (Play ());
				yield return StartCoroutine (End ());
			}
		}

		IEnumerator Wait ()
		{
			titleCover.SetActive (true);
			scoreText.text = Scorer.Format (highScore);

			pressed = false;

			while (!pressed) {
				yield return null;
			}
		}

		IEnumerator Play ()
		{
			titleCover.SetActive (false);

			player = Instantiate (prefabPlayer);
			master = Instantiate (prefabMaster);
			scorer = Instantiate (prefabScorer);
			scorer.scoreText = scoreText;

			yield return null;

			while (player.gameObject.activeInHierarchy) {
				yield return null;
			}

			yield return new WaitForSeconds(1);
		}

		IEnumerator End ()
		{
			Destroy (player.gameObject);
			Destroy (master.gameObject);
			Destroy (scorer.gameObject);

			float lastScore = scorer.Score;
			if (lastScore > highScore) {
				highScore = lastScore;
			}

			yield return new WaitForSeconds (1.5f);
		}
	}
}