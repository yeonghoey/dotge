using System.Collections;
using UnityEngine;

namespace Dotge
{
    public class HomingShot : MonoBehaviour
    {
        public float speed;

        [System.NonSerialized]
        public Transform player;

        [System.NonSerialized]
        public Vector2 direction;

        void Start()
        {
            direction = direction.normalized;
            StartCoroutine(Homing());
        }

        IEnumerator Homing()
        {
            while (true)
            {
              Vector2 to = player.position - transform.position;
              float degree = Vector2.Angle(to, direction);
              // if (degree >= 0)
              // {
              //     degree = Mathf.Min(degree, 30);
              // }
              // else
              // {
              //     degree = Mathf.Max(degree, -30);
              // }
              Debug.Log(degree);
              direction = MathHelper.RotateVector2(direction, degree);
              yield return new WaitForSeconds(1);
            }
        }

        void Update()
        {
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
