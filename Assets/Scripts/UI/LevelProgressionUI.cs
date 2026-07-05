using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionUI : MonoBehaviour
{
    [SerializeField] private Text levelText;
    [SerializeField] private Image progressBar;
    [SerializeField] private Text progressText;
    [SerializeField] private Text themeText;
    [SerializeField] private Text difficultyText;

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = LevelManager.Instance;
        UpdateUI();
    }

    private void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (levelManager == null) return;

        int currentLevel = levelManager.GetCurrentLevel();
        float progress = levelManager.GetCurrentLevelProgress();
        LevelData levelData = levelManager.GetLevelData(currentLevel);

        if (levelData != null)
        {
            levelText.text = $"Level {currentLevel}/67";
            progressBar.fillAmount = progress / 100f;
            progressText.text = $"{progress:F1}%";
            themeText.text = $"🎨 {levelData.levelTheme}";

            string difficultyName = levelData.difficulty switch
            {
                1 => "🟢 Easy",
                2 => "🟡 Medium",
                3 => "🔴 Hard",
                _ => "Unknown"
            };

            difficultyText.text = difficultyName;
        }
    }

    public void ShowLevelInfo(int levelNumber)
    {
        LevelData levelData = levelManager.GetLevelData(levelNumber);
        if (levelData != null)
        {
            Debug.Log($"📍 Level {levelNumber}");
            Debug.Log($"🎨 Theme: {levelData.levelTheme}");
            Debug.Log($"⚡ Difficulty: {levelData.difficulty}");
            Debug.Log($"🚧 Obstacles: {levelData.obstacleCount}");
            Debug.Log($"🚩 Checkpoints: {levelData.checkpoints}");
        }
    }
}
