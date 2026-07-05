using UnityEngine;

public class TestInputHandler : MonoBehaviour
{
    private void Update()
    {
        TestPaymentSystem();
        TestBattlePass();
        TestLevelProgression();
        TestShop();
    }

    private void TestPaymentSystem()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("\n💳 TESTING PAYMENT SYSTEM\n");

            if (PaymentManager.Instance != null)
            {
                TestPaymentMethod(PaymentProvider.ApplePay);
                TestPaymentMethod(PaymentProvider.GooglePay);
                TestPaymentMethod(PaymentProvider.PayPal);
                TestPaymentMethod(PaymentProvider.Klarna);
            }
        }
    }

    private void TestPaymentMethod(PaymentProvider provider)
    {
        Debug.Log($"Testing {provider}...");
        PaymentManager.Instance.PurchaseProduct("test_product", provider, (success, message) =>
        {
            if (success)
                Debug.Log($"✅ {provider} Payment: SUCCESS - {message}");
            else
                Debug.Log($"❌ {provider} Payment: FAILED - {message}");
        });
    }

    private void TestBattlePass()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("\n⭐ TESTING BATTLE PASS\n");

            if (BattlePassManager.Instance != null)
            {
                BattlePassManager.Instance.AddXP(500);
                Debug.Log($"Current Tier: {BattlePassManager.Instance.GetCurrentTier()}");
                Debug.Log($"XP Progress: {BattlePassManager.Instance.GetCurrentXP()}");
                Debug.Log($"Tier Progress: {BattlePassManager.Instance.GetTierProgress() * 100}%");
            }
        }
    }

    private void TestLevelProgression()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("\n📍 TESTING LEVEL PROGRESSION\n");

            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.CompleteLevel(1);
                Debug.Log($"Current Level: {LevelManager.Instance.GetCurrentLevel()}");
                Debug.Log($"Progress: {LevelManager.Instance.GetCurrentLevelProgress()}%");
                Debug.Log($"Completion: {LevelManager.Instance.GetCompletionPercentage()}%");
            }
        }
    }

    private void TestShop()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("\n🛍️  TESTING SHOP SYSTEM\n");

            if (ShopManager.Instance != null)
            {
                ShopManager.Instance.AddMoney(1000);
                ShopManager.Instance.AddPremiumCurrency(500);
                
                Debug.Log($"Money: {ShopManager.Instance.GetMoney()}");
                Debug.Log($"Premium Currency: {ShopManager.Instance.GetPremiumCurrency()}");
            }
        }
    }
}
