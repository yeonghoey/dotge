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
            var ps = typeof(DevSettings).GetProperties();
            foreach (var p in ps)
            {
                UIForProperty(p);
            }
        }

        void UIForProperty(PropertyInfo p)
        {
            if (p.PropertyType == typeof(bool))
            {
                ToggleForProperty(p);
            }
            else if (p.PropertyType == typeof(int))
            {
                IntFieldForProperty(p);
            }
            else if (p.PropertyType == typeof(string))
            {
                TextFieldForProperty(p);
            }
        }

        void ToggleForProperty(PropertyInfo p)
        {
            bool value = (bool)p.GetValue(null, null);
            bool updated = EditorGUILayout.Toggle(p.Name, value);
            p.SetValue(null, updated, null);
        }

        void IntFieldForProperty(PropertyInfo p)
        {
            int value = (int)p.GetValue(null, null);
            int updated = EditorGUILayout.IntField(p.Name, value);
            p.SetValue(null, updated, null);
        }

        void TextFieldForProperty(PropertyInfo p)
        {
            string value = (string)p.GetValue(null, null);
            string updated = EditorGUILayout.TextField(p.Name, value);
            p.SetValue(null, updated, null);
        }
    }
}
