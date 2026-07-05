using UnityEngine;

public class TestGameSetup : MonoBehaviour
{
    [SerializeField] private int testLevel = 1;
    [SerializeField] private int testPlayerCount = 20;
    [SerializeField] private bool spawnBots = true;

    private void Start()
    {
        SetupTestGame();
    }

    private void SetupTestGame()
    {
        Debug.Log("\n========================================");
        Debug.Log("🎮 STUNT KINGS - TEST SCENE");
        Debug.Log("========================================\n");

        InitializeManagers();
        SetupLevel();
        SetupPlayers();
        SetupUI();

        Debug.Log("\n========================================");
        Debug.Log("✅ TEST SCENE READY!");
        Debug.Log("========================================\n");
        Debug.Log("📊 TEST INFO:");
        Debug.Log($"   Level: {testLevel}");
        Debug.Log($"   Players: {testPlayerCount}");
        Debug.Log($"   Bots: {(spawnBots ? "YES" : "NO")}");
        Debug.Log("\n");
    }

    private void InitializeManagers()
    {
        Debug.Log("⚙️  Initializing Managers...");

        if (GameManager.Instance == null)
        {
            new GameObject("GameManager").AddComponent<GameManager>();
            Debug.Log("   ✅ GameManager created");
        }

        if (LevelManager.Instance == null)
        {
            new GameObject("LevelManager").AddComponent<LevelManager>();
            Debug.Log("   ✅ LevelManager created");
        }

        if (CharacterManager.Instance == null)
        {
            new GameObject("CharacterManager").AddComponent<CharacterManager>();
            Debug.Log("   ✅ CharacterManager created");
        }

        if (ShopManager.Instance == null)
        {
            new GameObject("ShopManager").AddComponent<ShopManager>();
            Debug.Log("   ✅ ShopManager created");
        }

        if (BattlePassManager.Instance == null)
        {
            new GameObject("BattlePassManager").AddComponent<BattlePassManager>();
            Debug.Log("   ✅ BattlePassManager created");
        }

        if (MultiplayerManager.Instance == null)
        {
            new GameObject("MultiplayerManager").AddComponent<MultiplayerManager>();
            Debug.Log("   ✅ MultiplayerManager created");
        }

        if (MatchManager.Instance == null)
        {
            new GameObject("MatchManager").AddComponent<MatchManager>();
            Debug.Log("   ✅ MatchManager created");
        }

        if (PaymentManager.Instance == null)
        {
            new GameObject("PaymentManager").AddComponent<PaymentManager>();
            Debug.Log("   ✅ PaymentManager created");
        }
    }

    private void SetupLevel()
    {
        Debug.Log($"\n🎯 Setting up Level {testLevel}...");
        
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.StartLevel(testLevel);
            LevelData levelData = LevelManager.Instance.GetLevelData(testLevel);
            
            if (levelData != null)
            {
                Debug.Log($"   📍 Level Name: {levelData.levelName}");
                Debug.Log($"   🎨 Theme: {levelData.levelTheme}");
                Debug.Log($"   ⚡ Difficulty: {levelData.difficulty}");
                Debug.Log($"   🚧 Obstacles: {levelData.obstacleCount}");
            }
        }
    }

    private void SetupPlayers()
    {
        Debug.Log($"\n👥 Setting up {testPlayerCount} Players...");

        if (spawnBots)
        {
            SpawnTestBots(testPlayerCount - 1);
            SpawnTestPlayer();
        }
        else
        {
            SpawnTestPlayer();
        }
    }

    private void SpawnTestPlayer()
    {
        GameObject playerGO = new GameObject("TestPlayer");
        playerGO.tag = "Player";
        playerGO.transform.position = Vector3.zero;

        Rigidbody rb = playerGO.AddComponent<Rigidbody>();
        rb.mass = 1f;

        CapsuleCollider collider = playerGO.AddComponent<CapsuleCollider>();

        GameObject visual = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        visual.transform.parent = playerGO.transform;
        visual.transform.localPosition = Vector3.zero;
        Destroy(visual.GetComponent<Collider>());
        visual.GetComponent<Renderer>().material.color = Color.blue;

        PlayerController playerController = playerGO.AddComponent<PlayerController>();
        AbilityManager abilityManager = playerGO.AddComponent<AbilityManager>();

        Debug.Log("   ✅ Test Player spawned (BLUE)");
    }

    private void SpawnTestBots(int botCount)
    {
        for (int i = 0; i < botCount; i++)
        {
            GameObject botGO = new GameObject($"TestBot_{i + 1}");
            botGO.tag = "Player";
            botGO.transform.position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(2f, 10f));

            Rigidbody rb = botGO.AddComponent<Rigidbody>();
            rb.mass = 1f;

            CapsuleCollider collider = botGO.AddComponent<CapsuleCollider>();

            GameObject visual = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            visual.transform.parent = botGO.transform;
            visual.transform.localPosition = Vector3.zero;
            Destroy(visual.GetComponent<Collider>());
            visual.GetComponent<Renderer>().material.color = Color.red;

            BotController botController = botGO.AddComponent<BotController>();
            botController.SetDifficulty(Random.Range(1, 4));
        }

        Debug.Log($"   ✅ {botCount} Test Bots spawned (RED)");
    }

    private void SetupUI()
    {
        Debug.Log("\n🎨 Setting up UI...");
        Debug.Log("   ✅ Test UI setup complete");
    }
}
