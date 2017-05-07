using UnityEngine;
using UnityEditor;

namespace Dotge
{
    public class TestHelperWindow : EditorWindow
    {
        bool invincible = false;
        bool quickMode = false;

        [MenuItem("Custom/Test Helper")]
        public static void Open()
        {
            GetWindow<TestHelperWindow>();
        }

        void OnGUI()
        {
            PrefBool("invincible", ref invincible);
            PrefBool("quickMode", ref quickMode);
        }

        void PrefBool(string name, ref bool value)
        {
            var key = "Dotge." + name;
            value = EditorPrefs.GetBool(key);
            invincible = EditorGUILayout.Toggle(key, value);
            EditorPrefs.SetBool(key, invincible);
        }
    }
}
