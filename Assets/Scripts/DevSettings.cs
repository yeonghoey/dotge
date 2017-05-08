using UnityEngine;

#if UNITY_EDITOR
public static class DevSettings {
    // public static bool Invincible
    // {
    //     get { retrun PlayerPrefs.GetInt("invincible"); }
    // }

    public static bool Invincible
    {
        get { return PlayerPrefs.GetInt("invincible") != 0; }
    }
}
#endif
