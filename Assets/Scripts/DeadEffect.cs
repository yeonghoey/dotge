using UnityEngine;

namespace Dotge
{
    public class DeadEffect : MonoBehaviour
    {
        const float Duration = 1.0f;

        [SerializeField]
        private GameObject player;

        private float activatedAt;

        void Start()
        {
            activatedAt = Time.time;
        }

        void Update()
        {
            if (Time.time - activatedAt > Duration)
            {
                player.SetActive(false);
            }
        }
    }
}
