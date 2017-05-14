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
            DevSettings.SkipPressAnyButton = EditorGUILayout.Toggle("SkipPressAnyButton", DevSettings.SkipPressAnyButton);
            DevSettings.SkipDeadAnim = EditorGUILayout.Toggle("SkipDeadAnim", DevSettings.SkipDeadAnim);
            DevSettings.SkipAfterDead = EditorGUILayout.Toggle("SkipAfterDead", DevSettings.SkipAfterDead);
            DevSettings.SkipHighscore = EditorGUILayout.Toggle("SkipHighscore", DevSettings.SkipHighscore);
        }
    }
}
