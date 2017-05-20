using UnityEngine;

namespace Dotge
{
    public class Jukebox : MonoBehaviour
    {
        public AudioSource bgmProgressive;

        public void PlayProgressive()
        {
            StopAll();
            // bgmProgressive.time = 6.0f;
            bgmProgressive.Play();
        }

        public void StopAll()
        {
            bgmProgressive.Stop();;
        }
    }
}
