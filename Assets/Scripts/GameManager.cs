using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dotge
{
    public class GameManager : MonoBehaviour
    {
        public Player playerPrefab;
        public Master masterPrefab;
        public Scorer scorerPrefab;

        public GameObject titleCover;
        public Text scoreText;
        public Jukebox jukebox;

        private float highscore;
        private bool pressed;

        private Player player;
        private Master master;
        private Scorer scorer;

        void Start()
        {
            highscore = 0.0f;
            StartCoroutine(GameLoop());
        }

        void Update()
        {
            pressed = pressed || Input.anyKey;
        }

        IEnumerator GameLoop()
        {
            while (true)
            {
                yield return StartCoroutine(Wait());
                yield return StartCoroutine(Play());
                yield return StartCoroutine(End());
            }
        }

        IEnumerator Wait()
        {
            titleCover.SetActive(true);
            scoreText.text = Scorer.Format(highscore);

            pressed = false;

#if UNITY_EDITOR
            if (DevSettings.SkipPressAnyKey) yield break;
#endif

            while (!pressed)
            {
                yield return null;
            }
        }

        IEnumerator Play()
        {
            titleCover.SetActive(false);
            player = Instantiate(playerPrefab);
            master = Instantiate(masterPrefab);
            master.player = player.transform;
            master.jukebox = jukebox;
            scorer = Instantiate(scorerPrefab);
            scorer.scoreText = scoreText;

            yield return null;

            while (!player.dying)
            {
                yield return null;
            }

            scorer.gameObject.SetActive(false);
            jukebox.StopAll();

#if UNITY_EDITOR
            if (DevSettings.SkipDyingEffect) yield break;
#endif
            yield return new WaitForSeconds(2.0f);
        }

        IEnumerator End()
        {
            Destroy(player.gameObject);
            Destroy(master.gameObject);
            Destroy(scorer.gameObject);

            float lastScore = scorer.Score;
            if (lastScore > highscore)
            {
                highscore = lastScore;
            }

#if UNITY_EDITOR
            if (DevSettings.SkipHighscore) yield break;
#endif
            yield return new WaitForSeconds(1.0f);
        }
    }
}
