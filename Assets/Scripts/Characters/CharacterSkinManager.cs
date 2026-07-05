using UnityEngine;
using System.Collections.Generic;

public class CharacterSkinManager : MonoBehaviour
{
    public static CharacterSkinManager Instance { get; private set; }

    [System.Serializable]
    public class CharacterSkin
    {
        public string skinId;
        public string skinName;
        public Character baseCharacter;
        public Material skinMaterial;
        public Sprite skinIcon;
        public float price;
        public bool isPremium;
    }

    private Dictionary<string, CharacterSkin> skins = new Dictionary<string, CharacterSkin>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegisterSkin(CharacterSkin skin)
    {
        skins[skin.skinId] = skin;
        Debug.Log($"🎨 Skin registered: {skin.skinName}");
    }

    public CharacterSkin GetSkin(string skinId)
    {
        if (skins.TryGetValue(skinId, out var skin))
        {
            return skin;
        }
        return null;
    }

    public void ApplySkinToCharacter(PlayerController player, string skinId)
    {
        var skin = GetSkin(skinId);
        if (skin != null)
        {
            Renderer renderer = player.GetComponentInChildren<Renderer>();
            if (renderer != null)
            {
                renderer.material = skin.skinMaterial;
                Debug.Log($"✅ Skin applied: {skin.skinName}");
            }
        }
    }

    public Dictionary<string, CharacterSkin> GetAllSkins()
    {
        return new Dictionary<string, CharacterSkin>(skins);
    }
}