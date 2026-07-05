using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    [SerializeField] private Button applePayButton;
    [SerializeField] private Button googlePayButton;
    [SerializeField] private Button payPalButton;
    [SerializeField] private Button klarnaButton;
    [SerializeField] private Text selectedProductText;
    [SerializeField] private Text priceText;
    [SerializeField] private Image productIcon;

    private PaymentManager paymentManager;
    private ShopManager shopManager;
    private string selectedProductId;

    private void Start()
    {
        paymentManager = PaymentManager.Instance;
        shopManager = ShopManager.Instance;

        // Button Listeners
        applePayButton.onClick.AddListener(() => InitiatePurchase(PaymentProvider.ApplePay));
        googlePayButton.onClick.AddListener(() => InitiatePurchase(PaymentProvider.GooglePay));
        payPalButton.onClick.AddListener(() => InitiatePurchase(PaymentProvider.PayPal));
        klarnaButton.onClick.AddListener(() => InitiatePurchase(PaymentProvider.Klarna));

        // Platform-specific button visibility
        #if UNITY_IOS
            googlePayButton.gameObject.SetActive(false);
            payPalButton.gameObject.SetActive(true);
            klarnaButton.gameObject.SetActive(true);
            applePayButton.gameObject.SetActive(true);
        #elif UNITY_ANDROID
            googlePayButton.gameObject.SetActive(true);
            payPalButton.gameObject.SetActive(true);
            klarnaButton.gameObject.SetActive(true);
            applePayButton.gameObject.SetActive(false);
        #endif

        DisplayAvailableProducts();
    }

    private void DisplayAvailableProducts()
    {
        var products = paymentManager.GetProducts();
        Debug.Log($"📦 {products.Count} products available");
        
        foreach (var product in products)
        {
            Debug.Log($"  💎 {product.name}: {product.price} {product.currency} → {product.premiumCurrencyAmount} Premium Currency");
        }
    }

    public void SelectProduct(string productId)
    {
        selectedProductId = productId;
        var product = paymentManager.GetProduct(productId);
        
        if (product != null)
        {
            selectedProductText.text = product.name;
            priceText.text = $"{product.price} {product.currency}";
            productIcon.sprite = product.icon;
            Debug.Log($"🎯 Selected: {product.name}");
        }
    }

    private void InitiatePurchase(PaymentProvider provider)
    {
        if (string.IsNullOrEmpty(selectedProductId))
        {
            Debug.LogWarning("⚠️ No product selected!");
            return;
        }

        Debug.Log($"💳 Initiating purchase via {provider}...");

        paymentManager.PurchaseProduct(selectedProductId, provider, OnPaymentComplete);
    }

    private void OnPaymentComplete(bool success, string message)
    {
        if (success)
        {
            Debug.Log($"✅ {message}");
            DisplayPurchaseConfirmation();
        }
        else
        {
            Debug.Log($"❌ {message}");
            DisplayPurchaseError();
        }
    }

    private void DisplayPurchaseConfirmation()
    {
        Debug.Log("🎉 Purchase successful! Premium Currency added to your account.");
    }

    private void DisplayPurchaseError()
    {
        Debug.Log("❌ Purchase failed. Please try again.");
    }
}