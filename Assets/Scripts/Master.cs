using System.Collections;
using UnityEngine;
using P = Dotge.Patterns;

namespace Dotge
{
    public class Master : MonoBehaviour
    {
        public ConstShot basicShotPrefab;
        public ConstShot fastShotPrefab;

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
                P.Nway(U*20, D, 30, 5, BasicShot);
                P.Nway(D*20, U, 30, 5, BasicShot);
                P.Nway(L*20, R, 30, 5, BasicShot);
                P.Nway(R*20, L, 30, 5, BasicShot);
                yield return new WaitForSeconds(1);
            }
        }

        IEnumerator Three(int count)
        {
            for (int i = 0; i < count; i++)
            {
                P.Circle(U*20, 10, 0, 36, BasicShot, _ => D);
                P.Circle(D*20, 10, 0, 36, BasicShot, _ => U);
                P.Circle(L*20, 10, 0, 36, BasicShot, _ => R);
                P.Circle(R*20, 10, 0, 36, BasicShot, _ => L);
                yield return new WaitForSeconds(1);
            }
        }

        void BasicShot(Vector2 pos, Vector2 dir)
        {
            MakeConstShot(basicShotPrefab, pos, dir);
        }

        void FastShot(Vector2 pos, Vector2 dir)
        {
            MakeConstShot(fastShotPrefab, pos, dir);
        }

        void MakeConstShot(ConstShot prefab, Vector2 pos, Vector2 dir)
        {
            ConstShot s = Instantiate(prefab, parent: this.transform);
            s.transform.position = pos;
            s.direction = dir;
        }
    }
}
