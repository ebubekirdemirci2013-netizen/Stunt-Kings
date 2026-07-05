using UnityEngine;

public class BattlePassManager : MonoBehaviour
{
    public static BattlePassManager Instance { get; private set; }

    [SerializeField] private int maxTier = 100;
    [SerializeField] private int xpPerTier = 1000;

    private int currentTier = 1;
    private int currentXP = 0;
    private bool hasPremiumBattlePass = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadBattlePassData();
    }

    private void LoadBattlePassData()
    {
        currentTier = PlayerPrefs.GetInt("BattlePassTier", 1);
        currentXP = PlayerPrefs.GetInt("BattlePassXP", 0);
        hasPremiumBattlePass = PlayerPrefs.GetInt("PremiumBattlePass", 0) == 1;
        Debug.Log($"⭐ Battle Pass loaded: Tier {currentTier}, {currentXP} XP");
    }

    public void AddXP(int xpAmount)
    {
        currentXP += xpAmount;
        Debug.Log($"✅ +{xpAmount} XP (Total: {currentXP})");

        while (currentXP >= xpPerTier && currentTier < maxTier)
        {
            currentXP -= xpPerTier;
            currentTier++;
            Debug.Log($"🎉 TIER UP! Now Tier {currentTier}");
        }

        SaveBattlePassData();
    }

    public void UnlockPremiumBattlePass()
    {
        hasPremiumBattlePass = true;
        SaveBattlePassData();
        Debug.Log("💎 Premium Battle Pass unlocked!");
    }

    public int GetCurrentTier() => currentTier;
    public int GetCurrentXP() => currentXP;
    public float GetTierProgress() => (float)currentXP / xpPerTier;
    public bool HasPremiumBattlePass() => hasPremiumBattlePass;

    private void SaveBattlePassData()
    {
        PlayerPrefs.SetInt("BattlePassTier", currentTier);
        PlayerPrefs.SetInt("BattlePassXP", currentXP);
        PlayerPrefs.SetInt("PremiumBattlePass", hasPremiumBattlePass ? 1 : 0);
        PlayerPrefs.Save();
    }
}
