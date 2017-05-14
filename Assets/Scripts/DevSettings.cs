using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR
namespace Dotge
{
  public static class DevSettings
  {
      public static bool Invincible
      {
          get { return PlayerPrefs.GetInt("editor." + MethodBase.GetCurrentMethod().Name.Substring(4)) != 0; }
          set { PlayerPrefs.SetInt("editor." + MethodBase.GetCurrentMethod().Name.Substring(4), value ? 1 : 0); }
      }

      public static bool SkipPressAnyKey
      {
          get { return PlayerPrefs.GetInt("editor." + MethodBase.GetCurrentMethod().Name.Substring(4)) != 0; }
          set { PlayerPrefs.SetInt("editor." + MethodBase.GetCurrentMethod().Name.Substring(4), value ? 1 : 0); }
      }

      public static bool SkipDeadEffect
      {
          get { return PlayerPrefs.GetInt("editor." + MethodBase.GetCurrentMethod().Name.Substring(4)) != 0; }
          set { PlayerPrefs.SetInt("editor." + MethodBase.GetCurrentMethod().Name.Substring(4), value ? 1 : 0); }
      }

      public static bool SkipAfterDead
      {
          get { return PlayerPrefs.GetInt("editor." + MethodBase.GetCurrentMethod().Name.Substring(4)) != 0; }
          set { PlayerPrefs.SetInt("editor." + MethodBase.GetCurrentMethod().Name.Substring(4), value ? 1 : 0); }
      }

      public static bool SkipHighscore
      {
          get { return PlayerPrefs.GetInt("editor." + MethodBase.GetCurrentMethod().Name.Substring(4)) != 0; }
          set { PlayerPrefs.SetInt("editor." + MethodBase.GetCurrentMethod().Name.Substring(4), value ? 1 : 0); }
      }
  }
}
#endif
