using System.Collections;
using UnityEngine;

namespace Dotge
{
    public class Jukebox : MonoBehaviour
    {
        public const float Tempo = 60.0f / 144.0f;
        public const float Faster = 60.0f / 192.0f;

        public float Bar(float tempo)
        {
            return 16 * tempo;
        }

        public AudioSource bgmMain;

        public void PlayMain(int n)
        {
            StopAll();
            float start = n * Bar(Tempo);
            bgmMain.time = start;
            bgmMain.Play();
        }

        public void StopAll()
        {
            bgmMain.Stop();;
        }
    }
}
