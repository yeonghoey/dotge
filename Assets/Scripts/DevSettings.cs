using UnityEngine;

#if UNITY_EDITOR
namespace Dotge
{
  public static class DevSettings
  {
      public static bool Invincible
      {
          get { return PlayerPrefs.GetInt("Invincible") != 0; }
          set { PlayerPrefs.SetInt("Invincible", value ? 1 : 0); }
      }

      public static bool QuickMode
      {
          get { return PlayerPrefs.GetInt("QuickMode") != 0; }
          set { PlayerPrefs.SetInt("QuickMode", value ? 1 : 0); }
      }
  }
}
#endif
