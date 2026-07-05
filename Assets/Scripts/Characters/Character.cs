using UnityEngine;

public enum Rarity { Common, Uncommon, Rare, Epic, Legendary, Mythic }

public class Character : MonoBehaviour
{
    [SerializeField] private string characterId;
    [SerializeField] private string characterName;
    [SerializeField] private Rarity rarity;
    [SerializeField] private Sprite characterIcon;
    [SerializeField] private float speedBonus = 1f;
    [SerializeField] private float jumpBonus = 1f;
    [SerializeField] private float healthBonus = 1f;

    private bool isUnlocked = false;

    public string GetCharacterId() => characterId;
    public string GetCharacterName() => characterName;
    public Rarity GetRarity() => rarity;
    public Sprite GetIcon() => characterIcon;
    public float GetSpeedBonus() => speedBonus;
    public float GetJumpBonus() => jumpBonus;
    public float GetHealthBonus() => healthBonus;
    public bool IsUnlocked() => isUnlocked;

    public void Unlock()
    {
        isUnlocked = true;
    }
}
