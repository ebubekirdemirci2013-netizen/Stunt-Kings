using UnityEngine;
using System.Collections.Generic;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance { get; private set; }

    [SerializeField] private float matchDuration = 300f;
    private float timeRemaining;
    private bool matchActive = false;

    private List<PlayerRanking> playerRankings = new List<PlayerRanking>();
    private int finishOrder = 1;

    [System.Serializable]
    public class PlayerRanking
    {
        public PlayerController player;
        public int placement;
        public int score;
        public float finishTime;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        StartMatch();
    }

    private void Update()
    {
        if (matchActive)
        {
            UpdateMatchTimer();
        }
    }

    public void StartMatch()
    {
        matchActive = true;
        timeRemaining = matchDuration;
        playerRankings.Clear();
        finishOrder = 1;
        Debug.Log("🎮 Match gestartet!");
    }

    private void UpdateMatchTimer()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            EndMatch();
        }
    }

    public void PlayerFinished(PlayerController player)
    {
        var ranking = new PlayerRanking
        {
            player = player,
            placement = finishOrder,
            score = player.GetScore(),
            finishTime = matchDuration - timeRemaining
        };

        playerRankings.Add(ranking);
        finishOrder++;

        Debug.Log($"🏆 {player.name} finished at position #{ranking.placement}!");

        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.CompleteLevel(ranking.placement);
        }

        if (BattlePassManager.Instance != null)
        {
            int xpReward = 500 - (ranking.placement * 50);
            BattlePassManager.Instance.AddXP(xpReward);
        }
    }

    public void EndMatch()
    {
        matchActive = false;
        Debug.Log("🏁 Match beendet!");
        ShowResults();
    }

    private void ShowResults()
    {
        Debug.Log("📊 === MATCH RESULTS ===");
        foreach (var ranking in playerRankings)
        {
            Debug.Log($"#{ranking.placement} - {ranking.player.name}: {ranking.score} points ({ranking.finishTime:F1}s)");
        }
    }

    public List<PlayerRanking> GetRankings() => playerRankings;
    public float GetTimeRemaining() => timeRemaining;
    public bool IsMatchActive() => matchActive;
}
