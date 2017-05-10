using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dotge
{
    public class SwirlShot : MonoBehaviour
    {
        public float speed;
        public float angularSpeed;

        [System.NonSerialized]
        public Vector2 direction;
        [System.NonSerialized]
        public Vector2 center;
        [System.NonSerialized]
        public bool clockwise;

        void Start ()
        {
            direction = direction.normalized;
        }

        void FixedUpdate()
        {
            Vector2 dv = (Vector2)transform.position - center;
            float degree = angularSpeed * Time.fixedDeltaTime;
            if (clockwise)
            {
                degree = -degree;
            }
            Vector2 ov = MathHelper.RotateVector2(dv, degree);
            center += direction * speed * Time.fixedDeltaTime;
            transform.position = ov + center;
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }
}
