using System.Collections;
using UnityEngine;

namespace Dotge
{
    public class HomingShot : MonoBehaviour
    {
        public float speed;
        public float angularSpeed;

        [System.NonSerialized]
        public Transform player;

        [System.NonSerialized]
        public Vector2 direction;

        void Start()
        {
            direction = direction.normalized;
        }

        void Update()
        {
            Vector2 to = player.position - transform.position;
            float degree = Vector2.Angle(direction, to);
            bool clockwise = (direction.x * to.y - direction.y * to.x) < 0;
            if (clockwise) {
                degree = -degree;
            }
            float angular = angularSpeed * Time.deltaTime;
            degree = Mathf.Clamp(degree, -angular, angular);
            direction = MathHelper.RotateVector2(direction, degree);
        }

        void FixedUpdate()
        {
            transform.Translate(direction * Time.fixedDeltaTime * speed);
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }
}
