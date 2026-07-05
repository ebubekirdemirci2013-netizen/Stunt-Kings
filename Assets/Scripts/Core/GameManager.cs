using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private bool isDebugMode = true;
    private GameState currentState = GameState.Menu;

    public enum GameState { Menu, Playing, Paused, GameOver, LevelComplete }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void SetGameState(GameState newState)
    {
        currentState = newState;
        Time.timeScale = (newState == GameState.Paused) ? 0f : 1f;
    }

    public GameState GetGameState()
    {
        return currentState;
    }

    public void TogglePause()
    {
        SetGameState(currentState == GameState.Paused ? GameState.Playing : GameState.Paused);
    }

    public void StartGame()
    {
        SetGameState(GameState.Playing);
    }

    public void EndGame()
    {
        SetGameState(GameState.GameOver);
    }

    public void CompleteLevel()
    {
        SetGameState(GameState.LevelComplete);
    }
}
