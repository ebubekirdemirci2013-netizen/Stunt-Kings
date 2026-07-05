using UnityEngine;
using System.Collections.Generic;

public class MultiplayerManager : MonoBehaviour
{
    public static MultiplayerManager Instance { get; private set; }

    [SerializeField] private bool isOnlineMode = false;
    private List<PlayerController> connectedPlayers = new List<PlayerController>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void StartOnlineMatch()
    {
        isOnlineMode = true;
        Debug.Log("🌐 Online match started");
    }

    public void StartOfflineMatch()
    {
        isOnlineMode = false;
        Debug.Log("📱 Offline match started");
    }

    public void RegisterPlayer(PlayerController player)
    {
        connectedPlayers.Add(player);
        Debug.Log($"✅ Player registered. Total: {connectedPlayers.Count}");
    }

    public void UnregisterPlayer(PlayerController player)
    {
        connectedPlayers.Remove(player);
    }

    public int GetPlayerCount() => connectedPlayers.Count;
    public bool IsOnlineMode() => isOnlineMode;
    public List<PlayerController> GetAllPlayers() => new List<PlayerController>(connectedPlayers);
}
