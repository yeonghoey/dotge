using UnityEngine;

namespace Dotge
{
    public class ConstShot : MonoBehaviour {

        public float speed;

        [System.NonSerialized]
        public Vector2 direction = Vector2.zero;

        void Start()
        {
            direction = direction.normalized;
        }

        void FixedUpdate()
        {
            transform.Translate(direction * speed * Time.fixedDeltaTime);
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }
}
