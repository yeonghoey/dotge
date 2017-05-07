using System.Collections;
using UnityEngine;

namespace Dotge
{
    public class Master : MonoBehaviour
    {
        public ConstShot basicShotPrefab;

        readonly Vector2 Z = Vector2.zero;
        readonly Vector2 U = Vector2.up;
        readonly Vector2 D = Vector2.down;
        readonly Vector2 L = Vector2.left;
        readonly Vector2 R = Vector2.right;

        void Start()
        {
            StartCoroutine(GameLoop());
        }

        IEnumerator GameLoop()
        {
            while (true)
            {
                yield return StartCoroutine(One(5));
                yield return StartCoroutine(Two(5));
                yield return StartCoroutine(Three(5));
            }
        }

        IEnumerator One(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Patterns.Circle(Z, 20, 0, 36, BasicShot, pos => Z - pos);
                yield return new WaitForSeconds(1);
            }
        }

        IEnumerator Two(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Patterns.Nway(U*20, D, 30, 5, BasicShot);
                Patterns.Nway(D*20, U, 30, 5, BasicShot);
                Patterns.Nway(L*20, R, 30, 5, BasicShot);
                Patterns.Nway(R*20, L, 30, 5, BasicShot);
                yield return new WaitForSeconds(1);
            }
        }

        IEnumerator Three(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Patterns.Circle(U*20, 10, 0, 36, BasicShot, _ => D);
                Patterns.Circle(D*20, 10, 0, 36, BasicShot, _ => U);
                Patterns.Circle(L*20, 10, 0, 36, BasicShot, _ => R);
                Patterns.Circle(R*20, 10, 0, 36, BasicShot, _ => L);
                yield return new WaitForSeconds(1);
            }
        }

        void BasicShot(Vector2 pos, Vector2 dir)
        {
            ConstShot s = Instantiate(basicShotPrefab, parent: this.transform);
            s.transform.position = pos;
            s.direction = dir;
        }
    }
}
