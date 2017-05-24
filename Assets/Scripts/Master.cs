using System.Collections;
using System.Reflection;
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
        public Jukebox jukebox;
        [System.NonSerialized]
        public Transform player;

        readonly float Sqrt2 = Mathf.Sqrt(2.0f);

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

        Vector2 TL { get { return new Vector2(-Half, +Half); } }
        Vector2 TR { get { return new Vector2(+Half, +Half); } }
        Vector2 BL { get { return new Vector2(-Half, -Half); } }
        Vector2 BR { get { return new Vector2(+Half, -Half); } }

        Vector2 PLAYER { get { return player.position; } }

        void Start()
        {
            Half = mainCameraPrefab.orthographicSize;
            Side = Half * 2;
            Radius = Half * Sqrt2;

            // Keep player wihtin the screen
            BuildBorders(wallPrefab, Half, thickness: 2.0f);
            // Prevent from leaking GameObjects
            BuildBorders(wiperPrefab, Half * 2.0f, thickness: 10.0f);

            StartCoroutine(GameLoop());
        }

        IEnumerator GameLoop()
        {
            while (true)
            {
                yield return NextPhase();
            }
        }

        IEnumerator NextPhase()
        {
            int n = 0;
#if UNITY_EDITOR
            n = DevSettings.PhaseAt;
#endif
            jukebox.PlayMain(n);
            while (true)
            {
#if UNITY_EDITOR
                if (DevSettings.RepeatPhase)
                {
                    n = DevSettings.PhaseAt;
                    jukebox.PlayMain(n);
                }
#endif
                yield return StartCoroutine(Phase(n));
                n++;
            }
        }

        IEnumerator Phase(int n)
        {
            string name = string.Format("Phase{0:00}", n);
            BindingFlags bf = BindingFlags.Instance | BindingFlags.NonPublic;
            MethodInfo m = typeof(Master).GetMethod(name, bf);
            if (m == null)
            {
                m = typeof(Master).GetMethod("PhaseXX", bf);
            }
            return (IEnumerator)m.Invoke(this, null);
        }

        IEnumerator Phase00()
        {
            P.Line(TL, TR, 0.0f, (int)(Half * 0.5f), _ => SS, BasicBullet);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 0, 180, p => OO - p, FastBullet);
            yield return T();
            yield return T();

            P.Line(TR, BR, 2.0f, (int)(Half * 0.5f), _ => WW, BasicBullet);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 90, 180, p => OO - p, FastBullet);
            yield return T();
            yield return T();

            P.Line(BL, BR, 2.0f, (int)(Half * 0.5f), _ => NN, BasicBullet);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 0, 180, p => OO - p, FastBullet);
            yield return T();
            yield return T();

            P.Line(TL, BL, 0.0f, (int)(Half * 0.5f), _ => EE, BasicBullet);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 90, 180, p => OO - p, FastBullet);
            yield return T();
            P.Circle(OO, Radius, 0, 180, p => OO - p, FastBullet);
            yield return T(0.5f);
            P.Circle(OO, Radius, 90, 180, p => OO - p, FastBullet);
            yield return T(0.5f);
        }

        IEnumerator Phase01()
        {
            P.Line(NN * Radius * Sqrt2, EE * Radius * Sqrt2, 0.0f, (int)(Half * 0.75f), _ => SW, BasicBullet);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 45, 180, p => OO - p, FastBullet);
            yield return T();
            yield return T();

            P.Line(WW * Radius * Sqrt2, NN * Radius * Sqrt2, 2.0f, (int)(Half * 0.75f), _ => SE, BasicBullet);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 135, 180, p => OO - p, FastBullet);
            yield return T();
            yield return T();

            P.Line(WW * Radius * Sqrt2, SS * Radius * Sqrt2, 2.0f, (int)(Half * 0.75f), _ => NE, BasicBullet);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 45, 180, p => OO - p, FastBullet);
            yield return T();
            yield return T();

            P.Line(SS * Radius * Sqrt2, EE * Radius * Sqrt2, 2.0f, (int)(Half * 0.75f), _ => NW, BasicBullet);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 135, 180, p => OO - p, FastBullet);
            yield return T();
            P.Circle(OO, Radius, 45, 180, p => OO - p, FastBullet);
            yield return T(0.5f);
            P.Circle(OO, Radius, 135, 180, p => OO - p, FastBullet);
            yield return T(0.5f);
        }

        IEnumerator Phase02()
        {
            BasicBullet(TL + SS*(Half * 0.25f), EE);
            P.Circle(OO, Radius, 0, 90, p => OO - p, AccelBullet);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 45, 90, p => OO - p, FastBullet);
            yield return T();
            yield return T();

            BasicBullet(TR + SS*(Half * 0.25f + Half * 0.5f), WW);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 0, 90, p => OO - p, FastBullet);
            yield return T();
            yield return T();

            BasicBullet(TL + SS*(Half * 0.25f + Half * 0.5f * 2.0f), EE);
            P.Circle(OO, Radius,  18, 72, p => OO - p, AccelBullet);
            yield return T(0.333f);
            P.Circle(OO, Radius,  36, 72, p => OO - p, AccelBullet);
            yield return T(0.333f);
            P.Circle(OO, Radius,  54, 72, p => OO - p, AccelBullet);
            yield return T(0.333f);
            yield return T();
            P.Circle(OO, Radius, 45, 90, p => OO - p, FastBullet);
            P.Circle(OO, Radius,  0, 72, p => OO - p, AccelBullet);
            yield return T(0.5f);
            P.Circle(OO, Radius,  18, 72, p => OO - p, AccelBullet);
            yield return T(0.5f);
            yield return T();

            BasicBullet(TR + SS*(Half * 0.25f + Half * 0.5f * 3.0f), WW);
            yield return T();
            yield return T();
            P.Circle(OO, Radius, 45, 90, p => OO - p, FastBullet);
            yield return T();
            P.Circle(OO, Radius, 0, 90, p => OO - p, FastBullet);
            yield return T(0.5f);
            P.Circle(OO, Radius, 45, 90, p => OO - p, FastBullet);
            yield return T(0.5f);
        }

        IEnumerator PhaseXX()
        {
            P.Line(NW*Radius + NN*7, NE*Radius + NN*7, 3.0f, 3, _ => SS,
                   (p, d) => P.Circle(p, 6, 0, 60, _ => d,
                                      (pp, dd) => SwirlBullet(pp, dd, p, true)));
            P.Circle(OO, 10, 0, 60, p => OO - p, BasicBullet);
            P.Diamond(SS*Radius, 10.0f, 10.0f, 4, _ => NN, BasicBullet);
            P.Circle(NW*Radius, 5, 0, 60, _ => SE, (p, d) => SwirlBullet(p, d, NW*Radius, true));
            P.Circle(SE*Radius, 5, 0, 60, _ => NW, (p, d) => SwirlBullet(p, d, SE*Radius, true));
            P.Circle(NE*Radius, 5, 0, 60, _ => SW, (p, d) => SwirlBullet(p, d, NE*Radius, true));
            P.Circle(SW*Radius, 5, 0, 60, _ => NE, (p, d) => SwirlBullet(p, d, SW*Radius, true));
            yield return new WaitForSeconds(1);
            P.Circle(OO, Radius, 0, 36, pos => OO - pos, BasicBullet);
            yield return new WaitForSeconds(1);
            P.Circle(OO, Radius, 0, 72, pos => OO - pos, FastBullet);
            yield return new WaitForSeconds(1);
            P.Circle(OO, Radius, 0, 36, pos => OO - pos, AccelBullet);
            yield return new WaitForSeconds(1);
            P.Circle(OO, Radius, 36, 72, pos => OO - pos, WhizBullet);
            yield return new WaitForSeconds(1);
            P.Circle(OO, Radius, 0, 72, pos => OO - pos, HomingBullet);
            yield return new WaitForSeconds(1);
            P.RandomOnCircle(OO, Radius, 10, pos => OO - pos, AccelBullet);
            P.RandomOnCircle(OO, Radius, 2, pos => OO - pos, WhizBullet);
            P.RandomOnCircle(OO, Radius, 1, pos => OO - pos, HomingBullet);
        }

        WaitForSeconds T(float ratio = 1.0f)
        {
            float t = Jukebox.Tempo * ratio - Time.deltaTime;
            if (t > 0.01)
            {
                return new WaitForSeconds(t);
            }
            else
            {
                return null;
            }
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
