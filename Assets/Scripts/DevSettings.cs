using UnityEngine;

#if UNITY_EDITOR
namespace Dotge
{
  public static class DevSettings
  {
      public static bool Invincible
      {
          get { return PlayerPrefs.GetInt("editor.Invincible") != 0; }
          set { PlayerPrefs.SetInt("editor.Invincible", value ? 1 : 0); }
      }

      public static bool SkipPressAnyButton
      {
          get { return PlayerPrefs.GetInt("editor.SkipPressAnyButton") != 0; }
          set { PlayerPrefs.SetInt("editor.SkipPressAnyButton", value ? 1 : 0); }
      }

      public static bool SkipDeadAnim
      {
          get { return PlayerPrefs.GetInt("editor.SkipDeadAnim") != 0; }
          set { PlayerPrefs.SetInt("editor.SkipDeadAnim", value ? 1 : 0); }
      }

      public static bool SkipAfterDead
      {
          get { return PlayerPrefs.GetInt("editor.SkipAfterDead") != 0; }
          set { PlayerPrefs.SetInt("editor.SkipAfterDead", value ? 1 : 0); }
      }

      public static bool SkipHighscore
      {
          get { return PlayerPrefs.GetInt("editor.SkipHighscore") != 0; }
          set { PlayerPrefs.SetInt("editor.SkipHighscore", value ? 1 : 0); }
      }
  }
}
#endif
