using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class LevelData
{
    public int levelNumber;
    public string levelName;
    public string levelTheme;
    public int difficulty;
    public string description;
    public float estimatedTime;
    public bool isUnlocked;
    public float progressPercentage;
    public int obstacleCount;
    public int checkpoints;
}

[CreateAssetMenu(fileName = "New Level", menuName = "Stunt Kings/Level")]
public class Level : ScriptableObject
{
    public int levelId;
    public string levelName;
    public string theme;
    public int difficulty;
    public float timeLimit = 300f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public List<Vector3> checkpointPositions = new List<Vector3>();
    public int maxPlayers = 20;
    public float progressPercentagePerWin;
    public bool hasSpecialModifier;
    public string specialModifierName;
}
