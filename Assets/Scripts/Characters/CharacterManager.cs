using UnityEngine;
using System.Collections.Generic;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }

    private Dictionary<string, Character> characters = new Dictionary<string, Character>();
    private string selectedCharacterId = "char_001";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        InitializeCharacters();
    }

    private void InitializeCharacters()
    {
        Debug.Log("🎭 Initializing 20+ Characters...");
        
        string[] characterNames = new string[]
        {
            "Shadow", "Nova", "Blaze", "Frost", "Volt", "Stone",
            "Phoenix", "Dragon", "Tiger", "Eagle", "Wolf", "Bear",
            "Fox", "Panther", "Hawk", "Shark", "Knight", "Ninja",
            "Cyborg", "Alien", "Robot", "Phantom", "Ghost", "Specter"
        };

        for (int i = 0; i < characterNames.Length; i++)
        {
            Character character = new Character();
            string charId = $"char_{i + 1:000}";
            characters[charId] = character;
            Debug.Log($"✅ Character {i + 1}: {characterNames[i]}");
        }
    }

    public Character GetCharacter(string characterId)
    {
        if (characters.TryGetValue(characterId, out var character))
        {
            return character;
        }
        return null;
    }

    public void SelectCharacter(string characterId)
    {
        if (characters.ContainsKey(characterId))
        {
            selectedCharacterId = characterId;
            Debug.Log($"✅ Selected: {characterId}");
        }
    }

    public string GetSelectedCharacterId()
    {
        return selectedCharacterId;
    }

    public Dictionary<string, Character> GetAllCharacters()
    {
        return new Dictionary<string, Character>(characters);
    }
}
