using UnityEngine;

namespace Dotge
{
    public class Player : MonoBehaviour {

        public float speed;

        private Animator animator;
        private Vector2 direction;

        void Start()
        {
            animator = GetComponent<Animator>();
            direction = Vector2.zero;
        }

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

            if (other.CompareTag("Shot"))
            {
#if UNITY_EDITOR
                if (DevSettings.QuickMode) gameObject.SetActive(false);
#endif
                animator.SetTrigger("Die");
            }
        }
    }
}
