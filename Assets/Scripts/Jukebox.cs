using UnityEngine;

namespace Dotge
{
    public class Jukebox : MonoBehaviour
    {
        public AudioSource bgmProgressive;

        public void PlayProgressive()
        {
            StopAll();
            bgmProgressive.Play();
        }

        public void StopAll()
        {
            bgmProgressive.Stop();;
        }
    }
}
