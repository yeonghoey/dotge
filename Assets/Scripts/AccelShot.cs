using UnityEngine;

namespace Dotge
{
    public class AccelShot : ShotBehaviour
    {
        public Vector2 direction;
        public float power;

        private Rigidbody2D body;

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            body.AddForce(direction * power * Time.fixedDeltaTime);
        }
    }

}
