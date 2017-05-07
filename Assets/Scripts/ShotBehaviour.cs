using UnityEngine;

namespace Dotge
{
    public class ShotBehaviour : MonoBehaviour
    {
        private bool shownUp = false;

        void OnBecameVisible()
        {
            shownUp = true;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (shownUp && !other.CompareTag("Shot"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
