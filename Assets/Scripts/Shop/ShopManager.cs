using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance { get; private set; }

    private int playerMoney = 0;
    private int premiumCurrency = 0;
    private List<string> ownedSkins = new List<string>();
    private List<string> ownedCharacters = new List<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadShopData();
    }

    private void LoadShopData()
    {
        playerMoney = PlayerPrefs.GetInt("PlayerMoney", 1000);
        premiumCurrency = PlayerPrefs.GetInt("PremiumCurrency", 100);
        Debug.Log($"💰 Shop loaded: {playerMoney} Money, {premiumCurrency} Premium");
    }

    public void AddMoney(int amount)
    {
        playerMoney += amount;
        SaveShopData();
    }

    public void AddPremiumCurrency(int amount)
    {
        premiumCurrency += amount;
        SaveShopData();
    }

    public bool SpendMoney(int amount)
    {
        if (playerMoney >= amount)
        {
            playerMoney -= amount;
            SaveShopData();
            return true;
        }
        return false;
    }

    public bool SpendPremiumCurrency(int amount)
    {
        if (premiumCurrency >= amount)
        {
            premiumCurrency -= amount;
            SaveShopData();
            return true;
        }
        return false;
    }

    public int GetMoney() => playerMoney;
    public int GetPremiumCurrency() => premiumCurrency;

    private void SaveShopData()
    {
        PlayerPrefs.SetInt("PlayerMoney", playerMoney);
        PlayerPrefs.SetInt("PremiumCurrency", premiumCurrency);
        PlayerPrefs.Save();
    }
}
