using UnityEngine;

namespace Dotge
{
    public class Jukebox : MonoBehaviour
    {
        public const float Tempo = 60.0f / 144.0f;

        public AudioSource bgmProgressive;

        public void PlayProgressive()
        {
            StopAll();
            bgmProgressive.time = 60.0f / 144.0f * 32;
            bgmProgressive.Play();
        }

        public void StopAll()
        {
            bgmProgressive.Stop();;
        }
    }
}
