using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private List<Level> allLevels = new List<Level>();
    [SerializeField] private int totalLevels = 67;

    private int currentLevel = 1;
    private float currentLevelProgress = 0f;
    private Dictionary<int, LevelData> levelProgressData = new Dictionary<int, LevelData>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        InitializeLevels();
        LoadLevelProgress();
    }

    private void InitializeLevels()
    {
        for (int i = 1; i <= totalLevels; i++)
        {
            var levelData = new LevelData
            {
                levelNumber = i,
                levelName = $"Level {i}",
                levelTheme = GetThemeForLevel(i),
                difficulty = GetDifficultyForLevel(i),
                isUnlocked = (i == 1),
                progressPercentage = 0f,
                obstacleCount = 5 + (i / 5),
                checkpoints = 3 + (i / 10)
            };

            levelProgressData[i] = levelData;
        }

        Debug.Log($"✅ {totalLevels} Levels initialized!");
    }

    private string GetThemeForLevel(int levelNumber)
    {
        if (levelNumber <= 22) return "City";
        if (levelNumber <= 45) return "Jungle";
        return "Space";
    }

    private int GetDifficultyForLevel(int levelNumber)
    {
        if (levelNumber <= 10) return 1;
        if (levelNumber <= 35) return 2;
        return 3;
    }

    public void CompleteLevel(int placement)
    {
        float percentageGain = CalculateProgressPercentage(currentLevel, placement);

        if (placement == 1)
        {
            currentLevelProgress += percentageGain;
            Debug.Log($"🏆 1. Platz! +{percentageGain}% Progress (Total: {currentLevelProgress}%)");

            if (currentLevelProgress >= 100f)
            {
                LevelUp();
            }
        }
    }

    private float CalculateProgressPercentage(int levelNumber, int placement)
    {
        if (placement != 1) return 0f;

        if (levelNumber <= 10)
            return 20f;
        else if (levelNumber <= 35)
            return 33.33f;
        else
            return 50f;
    }

    private void LevelUp()
    {
        if (currentLevel < totalLevels)
        {
            currentLevel++;
            currentLevelProgress = 0f;
            UnlockLevel(currentLevel);
            SaveLevelProgress();

            Debug.Log($"🎉 LEVEL UP! 🎉 Jetzt Level {currentLevel}!");
        }
        else
        {
            Debug.Log("🏁 ALLE LEVELS ABGESCHLOSSEN! 🏁");
        }
    }

    private void UnlockLevel(int levelNumber)
    {
        if (levelProgressData.ContainsKey(levelNumber))
        {
            levelProgressData[levelNumber].isUnlocked = true;
            Debug.Log($"🔓 Level {levelNumber} freigeschaltet!");
        }
    }

    public int GetCurrentLevel() => currentLevel;
    public float GetCurrentLevelProgress() => currentLevelProgress;
    public LevelData GetLevelData(int levelNumber) => levelProgressData.ContainsKey(levelNumber) ? levelProgressData[levelNumber] : null;
    public bool IsLevelUnlocked(int levelNumber) => levelProgressData.ContainsKey(levelNumber) && levelProgressData[levelNumber].isUnlocked;
    public List<LevelData> GetAllLevels() => levelProgressData.Values.ToList();
    public int GetTotalLevels() => totalLevels;
    public float GetCompletionPercentage() => (currentLevel - 1 + (currentLevelProgress / 100f)) / totalLevels * 100f;

    public void StartLevel(int levelNumber)
    {
        if (IsLevelUnlocked(levelNumber))
        {
            currentLevel = levelNumber;
            Debug.Log($"🎮 Starting Level {levelNumber}!");
        }
    }

    private void SaveLevelProgress()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetFloat("CurrentLevelProgress", currentLevelProgress);
        PlayerPrefs.Save();
        Debug.Log("💾 Level Progress saved!");
    }

    private void LoadLevelProgress()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        currentLevelProgress = PlayerPrefs.GetFloat("CurrentLevelProgress", 0f);
        Debug.Log($"📂 Level Progress loaded: Level {currentLevel} ({currentLevelProgress}%)");
    }
}
