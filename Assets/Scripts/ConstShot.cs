using UnityEngine;

namespace Dotge
{
    public class ConstShot : ShotBehaviour {

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
    }
}
