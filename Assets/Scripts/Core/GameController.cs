using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private int maxPlayersPerMatch = 20;
    [SerializeField] private bool isOnlineMode = true;

    private List<PlayerController> activePlayers = new List<PlayerController>();
    private int playerCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartMatch(bool online)
    {
        isOnlineMode = online;
        playerCount = 0;
        activePlayers.Clear();

        if (online)
        {
            Debug.Log($"🌐 Online Match startet mit bis zu {maxPlayersPerMatch} Spielern!");
            // Photon PUN 2 Integration
        }
        else
        {
            Debug.Log($"🤖 Offline Match startet - spawne {maxPlayersPerMatch - 1} Bots!");
            SpawnBots(maxPlayersPerMatch - 1);
        }
    }

    private void SpawnBots(int botCount)
    {
        for (int i = 0; i < botCount; i++)
        {
            Debug.Log($"🤖 Bot {i + 1}/{botCount} spawned");
        }
    }

    public void AddPlayer(PlayerController player)
    {
        if (activePlayers.Count < maxPlayersPerMatch)
        {
            activePlayers.Add(player);
            playerCount++;
            Debug.Log($"✅ Player joined: {playerCount}/{maxPlayersPerMatch}");
        }
        else
        {
            Debug.LogWarning("⚠️ Match is full!");
        }
    }

    public int GetPlayerCount()
    {
        return playerCount;
    }

    public int GetMaxPlayers()
    {
        return maxPlayersPerMatch;
    }

    public List<PlayerController> GetActivePlayers()
    {
        return new List<PlayerController>(activePlayers);
    }

    public bool IsMatchFull()
    {
        return playerCount >= maxPlayersPerMatch;
    }
}