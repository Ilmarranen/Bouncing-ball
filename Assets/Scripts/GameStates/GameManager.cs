using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Action<GameState> onGameStateChanged;
    public GameState state;

    private void Awake()
    {
        //Singleton
        if (instance && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        Scaler.onScaleLimitReached += OnScaleLimitReached;
        PlayerCollision.onPlayerDestruction += OnPlayerDestruction;
        VictoryCondition.onVictory += OnVictory;
    }

    private void OnDestroy()
    {
        Scaler.onScaleLimitReached -= OnScaleLimitReached;
    }

    private void OnScaleLimitReached()
    {
        UpdateGameState(GameState.Fire);
    }

    private void OnPlayerDestruction()
    {
        UpdateGameState(GameState.Defeat);
    }
    private void OnVictory()
    {
        UpdateGameState(GameState.Victory);
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.ClearObstacles);    
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.ClearObstacles:
                break;
            case GameState.Fire:
                break;
            case GameState.Victory:
                break;
            case GameState.Defeat:
                break;
            default:
                break;
        }
        onGameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    ClearObstacles,
    Fire,
    Victory,
    Defeat
}
