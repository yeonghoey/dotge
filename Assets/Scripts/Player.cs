using UnityEngine;

namespace Dotge
{
    public class Player : MonoBehaviour
    {
        public float speed;
        public SpriteRenderer sprite;
        public AudioSource dyingSound;
        public GameObject dyingEffect;

        [System.NonSerialized]
        public bool dying = false;

        private Vector2 direction = Vector2.zero;

        void Update()
        {
            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            direction = new Vector2(h, v).normalized;
        }

        void FixedUpdate()
        {
            transform.Translate(direction * speed * Time.fixedDeltaTime);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
#if UNITY_EDITOR
            if (DevSettings.Invincible) return;
#endif

            if (dying)
            {
                return;
            }

            if (other.CompareTag("Shot"))
            {
                dying = true;
                this.enabled = false;
                sprite.enabled = false;
                dyingSound.Play();
                dyingEffect.SetActive(true);
            }
        }
    }
}
