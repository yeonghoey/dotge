using System.Reflection;
using UnityEditor;

namespace Dotge
{
    public class DevSettingsWindow : EditorWindow
    {
        [MenuItem("Custom/DevSettings")]
        public static void Open()
        {
            GetWindow<DevSettingsWindow>();
        }

        void OnGUI()
        {
            DevSettings.Invincible = EditorGUILayout.Toggle("Invincible", DevSettings.Invincible);
            DevSettings.QuickMode = EditorGUILayout.Toggle("QuickMode", DevSettings.QuickMode);
        }
    }
}
