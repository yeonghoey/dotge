using UnityEngine;

namespace Dotge
{
    public class AccelShot : MonoBehaviour
    {
        public Rigidbody2D body;
        public float power;

        [System.NonSerialized]
        public Vector2 direction = Vector2.zero;

        void Start()
        {
            direction = direction.normalized;
        }

        void FixedUpdate()
        {
            body.AddForce(direction * power * Time.fixedDeltaTime);
        }

        void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }

}
