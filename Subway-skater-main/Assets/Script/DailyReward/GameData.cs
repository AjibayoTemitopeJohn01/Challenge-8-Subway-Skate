using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameData {
    
    private static int _Coins=0;

    static GameData()
    {
        _Coins = PlayerPrefs.GetInt("Coins", 0);
    }

    public static int Coins
    {
        get { return _Coins; }
        set
        {
            PlayerPrefs.SetInt("Coins", (_Coins = value));
        }
    }
}
