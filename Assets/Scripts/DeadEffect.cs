using UnityEngine;

namespace Dotge
{
    public class DeadEffect : MonoBehaviour
    {
        const float Duration = 0.3f;

        [SerializeField]
        private SpriteRenderer player;

        [SerializeField]
        private ParticleSystem particle;

        private float startedAt;

        void Start()
        {
            startedAt = Time.realtimeSinceStartup;
            Time.timeScale = 0.0f;
        }

        void Update()
        {
            float delta = Time.realtimeSinceStartup - startedAt;
            if (delta >= Duration)
            {
                Time.timeScale = 1.0f;
                player.enabled = false;
                particle.Play();
                this.enabled = false;
            }
        }
    }
}
