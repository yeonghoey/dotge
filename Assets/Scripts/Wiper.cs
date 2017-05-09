using UnityEngine;

namespace Dotge
{
    public class Wiper : MonoBehaviour {
        void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }
    }
}
