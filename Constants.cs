using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants {
    public enum GameModes
    {
        Sprint,
        Medium,
    }

    public enum MedalTypes
    {
        GoldMedal,
        SilverMedal,
        BronzeMedal,
    }

    public static readonly string LevelsKey = "level_counter_key";
    public static readonly string SessionsKey = "session_counter_key";
}
