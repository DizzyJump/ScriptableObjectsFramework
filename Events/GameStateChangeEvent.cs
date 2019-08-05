using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// ПРИ ИЗМЕНЕНИИ НАБОРА СТЕЙТОВ ОБЯЗАТЕЛЬНО ПРОВЕРИТЬ ВСЕ КОМПОНЕНТЫ В КОТОРЫХ ЕСТЬ КОНТЕЙНЕРЫ СТЕЙТОВ, НАПРИМЕР, GameStateObjectsController
public enum GameStates
{
    Tutorial,
    Play,
    LevelSuccess,
    LevelFailed,
}

[CreateAssetMenu(menuName ="Game/GameStateEvent")]
public class GameStateChangeEvent : BaseValue<GameStates>
{
    public static GameStateChangeEvent Import()
    {
        return Resources.Load<GameStateChangeEvent>("GameState");
    }
}
