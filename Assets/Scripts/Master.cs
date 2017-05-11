using System.Collections;
using UnityEngine;

using P = Dotge.Patterns;

namespace Dotge
{
    public class Master : MonoBehaviour
    {
        public Camera mainCameraPrefab;
        public Transform wallPrefab;
        public Transform wiperPrefab;
        public ConstShot basicBulletPrefab;
        public ConstShot fastBulletPrefab;
        public AccelShot accelBulletPrefab;
        public AccelShot whizBulletPrefab;
        public HomingShot homingBulletPrefab;
        public SwirlShot swrilBulletPrefab;

        [System.NonSerialized]
        public Transform player;

        // Values relating the screen
        // Used as units of pattern's spawn points
        private float Half;   // Side of the screen
        private float Side;   // Side of the screen
        private float Radius; // Radius of the circumscribed circle about the screen

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
            Half = mainCameraPrefab.orthographicSize;
            Side = Half * 2;
            Radius = Half * Mathf.Sqrt(2);

            // Keep player wihtin the screen
            BuildBorders(wallPrefab, Half, thickness: 2.0f);
            // Prevent from leaking GameObjects
            BuildBorders(wiperPrefab, Half * 2.0f, thickness: 10.0f);

            StartCoroutine(GameLoop());
        }

        IEnumerator GameLoop()
        {
            // yield return StartCoroutine(Phase1());
            // yield return StartCoroutine(Phase2());
            // yield return StartCoroutine(Phase3());

            for (int i = 0; ; i++)
            {
                yield return StartCoroutine(PhaseX(i));
            }
        }

        IEnumerator Phase1()
        {
            // for (int i = 0; i < 4; i++)
            // {
            //     P.Circle(OO, Radius, i * 6.0f, 36, pos => OO - pos, BasicBullet);
            //     yield return new WaitForSeconds(1);
            //     P.Circle(OO, Radius, i * 6.0f, 18, pos => OO - pos, BasicBullet);
            //     yield return new WaitForSeconds(1);
            // }

            // yield return new WaitForSeconds(5);

            // P.Circle(WW*Radius, Side/3, 0, 30, _ => EE, BasicBullet);
            // P.Circle(EE*Radius, Side/3, 0, 30, _ => WW, BasicBullet);
            // yield return new WaitForSeconds(1);
            // P.Circle(NN*Radius, Side/3, 0, 30, _ => SS, BasicBullet);
            // P.Circle(SS*Radius, Side/3, 0, 30, _ => NN, BasicBullet);
            // yield return new WaitForSeconds(2);
            // P.Circle(OO, Radius, 0, 10, BasicBullet, pos => OO - pos);
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
            // P.Line(NW*Radius, NE*Radius, 3.0f, 5, _ => SS,
            //               (p, d) => P.Rect(p, 3.0f, 3.0f, 4, _ => d, BasicBullet));

            P.Line(NW*Radius + NN*7, NE*Radius + NN*7, 3.0f, 3, _ => SS,
                   (p, d) => P.Circle(p, 6, 0, 60, _ => d,
                                      (pp, dd) => SwirlBullet(pp, dd, p, true)));
            // P.Diamond(SS*Radius, 10.0f, 10.0f,- Replace: {{c5::L drag}} 4, _ => NN, BasicBullet);

            // P.Circle(NW*Radius, 5, 0, 60, _ => SE, (p, d) => SwirlBullet(p, d, NW*Radius, true));
            // P.Circle(SE*Radius, 5, 0, 60, _ => NW, (p, d) => SwirlBullet(p, d, SE*Radius, true));
            // P.Circle(NE*Radius, 5, 0, 60, _ => SW, (p, d) => SwirlBullet(p, d, NE*Radius, true));
            // P.Circle(SW*Radius, 5, 0, 60, _ => NE, (p, d) => SwirlBullet(p, d, SW*Radius, true));
            // yield return new WaitForSeconds(1);
            // P.Circle(OO, Radius, 0, 36, pos => OO - pos, BasicBullet);
            // yield return new WaitForSeconds(1);
            // P.Circle(OO, Radius, 0, 72, pos => OO - pos, FastBullet);
            // yield return new WaitForSeconds(1);
            // P.Circle(OO, Radius, 0, 36, pos => OO - pos, AccelBullet);
            // yield return new WaitForSeconds(1);
            // P.Circle(OO, Radius, 36, 72, pos => OO - pos, WhizBullet);
            // yield return new WaitForSeconds(1);
            // P.Circle(OO, Radius, 0, 72, pos => OO - pos, HomingBullet);
            yield return new WaitForSeconds(1);
            // P.RandomOnCircle(OO, Radius, 10, pos => OO - pos, AccelBullet);
            // P.RandomOnCircle(OO, Radius, 2, pos => OO - pos, WhizBullet);
            // P.RandomOnCircle(OO, Radius, 1, pos => OO - pos, HomingBullet);
        }

        // ConstShots
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

        // AccelShots
        void AccelBullet(Vector2 pos, Vector2 dir)
        {
            SpawnAccelShot(accelBulletPrefab, pos, dir);
        }

        void WhizBullet(Vector2 pos, Vector2 dir)
        {
            SpawnAccelShot(whizBulletPrefab, pos, dir);
        }

        void SpawnAccelShot(AccelShot prefab, Vector2 pos, Vector2 dir)
        {
            AccelShot s = Instantiate(prefab, pos, Quaternion.identity, this.transform);
            s.direction = dir;
        }

        // HomingShots
        void HomingBullet(Vector2 pos, Vector2 dir)
        {
            SpawnHomingShot(homingBulletPrefab, pos, dir);
        }

        void SpawnHomingShot(HomingShot prefab, Vector2 pos, Vector2 dir)
        {
            HomingShot s = Instantiate(prefab, pos, Quaternion.identity, this.transform);
            s.direction = dir;
            s.player = player;
        }

        // SwrilShots
        void SwirlBullet(Vector2 pos, Vector2 dir, Vector2 center, bool clockwise = false)
        {
            SpawnSwirlShot(swrilBulletPrefab, pos, dir, center, clockwise);
        }

        void SpawnSwirlShot(SwirlShot prefab, Vector2 pos, Vector2 dir, Vector2 center, bool clockwise)
        {
            SwirlShot s = Instantiate(prefab, pos, Quaternion.identity, this.transform);
            s.direction = dir;
            s.center = center;
            s.clockwise = clockwise;
        }

        void BuildBorders(Transform prefab, float unit, float thickness)
        {
            float offset = unit + (thickness * 0.5f);
            float[,] values = new float[,] {
                {0, offset, offset*2, thickness},  // Up
                {0, -offset, offset*2, thickness}, // Down
                {-offset, 0, thickness, offset*2}, // Left
                {offset, 0, thickness, offset*2}   // Right
            };

            for (int i = 0; i < values.GetLength(0); i++)
            {
                Transform wall = Instantiate(prefab, this.transform);
                var position = new Vector3(values[i, 0], values[i, 1], 0.0f);
                var scale = new Vector3(values[i, 2], values[i, 3], 1.0f);
                wall.position = position;
                wall.localScale = scale;
            }
        }
    }
}
