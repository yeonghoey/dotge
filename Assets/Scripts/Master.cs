﻿using System.Collections;
using UnityEngine;

namespace Dotge
{
    public class Master : MonoBehaviour
    {
        public Camera mainCameraPrefab;
        public Transform wallPrefab;
        public ConstShot basicBulletPrefab;
        public ConstShot fastBulletPrefab;

        // Values relating the screen
        // Used as units of pattern's spawn points
        private float side;   // Side of the screen
        private float radius; // Radius of the circumscribed circle about the screen

        readonly Vector2 OO = Vector2.zero;
        readonly Vector2 NN = Vector2.up;
        readonly Vector2 NE = (Vector2.up + Vector2.right).normalized;
        readonly Vector2 EE = Vector2.right;
        readonly Vector2 SE = (Vector2.down + Vector2.right).normalized;
        readonly Vector2 SS = Vector2.down;
        readonly Vector2 SW = (Vector2.down + Vector2.left).normalized;
        readonly Vector2 WW = Vector2.left;
        readonly Vector2 NW = (Vector2.up + Vector2.left).normalized;

        void Start()
        {
            side = mainCameraPrefab.orthographicSize * 2;
            radius = mainCameraPrefab.orthographicSize * Mathf.Sqrt(2);

            BuildWalls();
            StartCoroutine(GameLoop());
        }

        IEnumerator GameLoop()
        {
            yield return StartCoroutine(Phase1());
            yield return StartCoroutine(Phase2());
            yield return StartCoroutine(Phase3());

            for (int i = 0; ; i++)
            {
                yield return StartCoroutine(PhaseX(i));
            }
        }

        IEnumerator Phase1()
        {
            // for (int i = 0; i < 4; i++)
            // {
            //     Patterns.Circle(OO, radius, i * 6.0f, 36, BasicBullet, pos => OO - pos);
            //     yield return new WaitForSeconds(1);
            //     Patterns.Circle(OO, radius, i * 6.0f, 18, BasicBullet, pos => OO - pos);
            //     yield return new WaitForSeconds(1);
            // }

            // yield return new WaitForSeconds(5);

            Patterns.Circle(WW*radius, side/3, 0, 30, BasicBullet, _ => EE);
            Patterns.Circle(EE*radius, side/3, 0, 30, BasicBullet, _ => WW);
            yield return new WaitForSeconds(1);
            Patterns.Circle(NN*radius, side/3, 0, 30, BasicBullet, _ => SS);
            Patterns.Circle(SS*radius, side/3, 0, 30, BasicBullet, _ => NN);
            yield return new WaitForSeconds(2);
            Patterns.Circle(OO, radius, 0, 10, BasicBullet, pos => OO - pos);
            yield return null;
        }

        IEnumerator Phase2()
        {
            yield return null;
        }

        IEnumerator Phase3()
        {
            yield return null;
        }

        IEnumerator PhaseX(int n)
        {
            yield return null;
        }

        void BasicBullet(Vector2 pos, Vector2 dir)
        {
            SpawnConstShot(basicBulletPrefab, pos, dir);
        }

        void FastBullet(Vector2 pos, Vector2 dir)
        {
            SpawnConstShot(fastBulletPrefab, pos, dir);
        }

        void SpawnConstShot(ConstShot prefab, Vector2 pos, Vector2 dir)
        {
            ConstShot s = Instantiate(prefab, pos, Quaternion.identity, this.transform);
            s.direction = dir;
        }

        void BuildWalls()
        {
            // Build Walls to keep player wihtin the screen
            float offset = mainCameraPrefab.orthographicSize + 0.5f;
            float size = offset * 2;
            float[,] walls = new float[,] {
                {0, offset, size, 1}, {0, -offset, size, 1},
                {offset, 0, 1, size}, {-offset, 0, 1, size}
            };

            for (int i = 0; i < walls.GetLength(0); i++)
            {
                Transform wall = Instantiate(wallPrefab, parent: this.transform);
                var position = new Vector3(walls[i, 0], walls[i, 1], 0.0f);
                var scale = new Vector3(walls[i, 2], walls[i, 3], 1.0f);
                wall.position = position;
                wall.localScale = scale;
            }
        }
    }
}
