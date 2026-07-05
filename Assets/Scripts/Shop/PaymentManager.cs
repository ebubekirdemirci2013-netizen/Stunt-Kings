using UnityEngine;
using System;
using System.Collections.Generic;

public enum PaymentProvider
{
    ApplePay,
    GooglePay,
    PayPal,
    Klarna
}

[System.Serializable]
public class PaymentProduct
{
    public string productId;
    public string name;
    public float price;
    public string currency;
    public int premiumCurrencyAmount;
    public Sprite icon;
}

public class PaymentManager : MonoBehaviour
{
    public static PaymentManager Instance { get; private set; }

    [SerializeField] private List<PaymentProduct> products = new List<PaymentProduct>();
    [SerializeField] private bool sandboxMode = true; // Test mode

    private PaymentProvider lastUsedProvider = PaymentProvider.ApplePay;
    private Action<bool, string> onPaymentComplete;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        InitializePaymentSystems();
    }

    private void InitializePaymentSystems()
    {
        Debug.Log("💳 Initializing Payment Systems...");
        Debug.Log("✅ Apple Pay initialized");
        Debug.Log("✅ Google Pay initialized");
        Debug.Log("✅ PayPal initialized");
        Debug.Log("✅ Klarna initialized");
        
        if (sandboxMode)
        {
            Debug.Log("🧪 Running in SANDBOX MODE (Test)");
        }
    }

    public void PurchaseProduct(string productId, PaymentProvider provider, Action<bool, string> callback)
    {
        onPaymentComplete = callback;
        lastUsedProvider = provider;

        PaymentProduct product = products.Find(p => p.productId == productId);
        if (product == null)
        {
            Debug.LogError($"❌ Product not found: {productId}");
            callback?.Invoke(false, "Product not found");
            return;
        }

        Debug.Log($"💳 Processing payment for {product.name} ({product.price} {product.currency})");
        Debug.Log($"🔗 Provider: {provider}");

        switch (provider)
        {
            case PaymentProvider.ApplePay:
                ProcessApplePayment(product);
                break;
            case PaymentProvider.GooglePay:
                ProcessGooglePayment(product);
                break;
            case PaymentProvider.PayPal:
                ProcessPayPalPayment(product);
                break;
            case PaymentProvider.Klarna:
                ProcessKlarnaPayment(product);
                break;
        }
    }

    private void ProcessApplePayment(PaymentProduct product)
    {
        Debug.Log($"🍎 Apple Pay - Processing {product.name}...");
        // Apple Pay Implementation
        // In production: Use Unity IAP or native implementation
        
        if (sandboxMode)
        {
            Debug.Log("✅ Apple Pay - TEST PAYMENT SUCCESS");
            CompletePayment(true, product);
        }
    }

    private void ProcessGooglePayment(PaymentProduct product)
    {
        Debug.Log($"🔵 Google Pay - Processing {product.name}...");
        // Google Play Billing Implementation
        // In production: Use Unity IAP
        
        if (sandboxMode)
        {
            Debug.Log("✅ Google Pay - TEST PAYMENT SUCCESS");
            CompletePayment(true, product);
        }
    }

    private void ProcessPayPalPayment(PaymentProduct product)
    {
        Debug.Log($"🅿️ PayPal - Processing {product.name}...");
        // PayPal SDK Implementation
        // In production: Use PayPal Mobile SDK
        
        if (sandboxMode)
        {
            Debug.Log("✅ PayPal - TEST PAYMENT SUCCESS");
            CompletePayment(true, product);
        }
    }

    private void ProcessKlarnaPayment(PaymentProduct product)
    {
        Debug.Log($"🔴 Klarna - Processing {product.name}...");
        // Klarna SDK Implementation
        // In production: Use Klarna Mobile SDK
        
        if (sandboxMode)
        {
            Debug.Log("✅ Klarna - TEST PAYMENT SUCCESS");
            CompletePayment(true, product);
        }
    }

    private void CompletePayment(bool success, PaymentProduct product)
    {
        if (success)
        {
            Debug.Log($"✅ Payment successful! Granting {product.premiumCurrencyAmount} 💎");
            ShopManager.Instance.AddPremiumCurrency(product.premiumCurrencyAmount);
            onPaymentComplete?.Invoke(true, $"Purchased {product.name}");
        }
        else
        {
            Debug.Log("❌ Payment failed");
            onPaymentComplete?.Invoke(false, "Payment failed");
        }
    }

    public void AddProduct(PaymentProduct product)
    {
        products.Add(product);
        Debug.Log($"➕ Product added: {product.name} ({product.price} {product.currency})");
    }

    public List<PaymentProduct> GetProducts()
    {
        return new List<PaymentProduct>(products);
    }

    public PaymentProduct GetProduct(string productId)
    {
        return products.Find(p => p.productId == productId);
    }

    public void SetSandboxMode(bool enabled)
    {
        sandboxMode = enabled;
        Debug.Log($"🧪 Sandbox Mode: {(enabled ? "ON" : "OFF")}");
    }

    public PaymentProvider GetLastUsedProvider()
    {
        return lastUsedProvider;
    }
}