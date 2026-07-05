using UnityEngine;

public enum EmoteType { Dance, Wave, Cheer, Laugh, Taunt, Celebrate, Flex, Emote }

public class Ability : MonoBehaviour
{
    [SerializeField] private EmoteType emoteType;
    [SerializeField] private float cooldownDuration = 10f;
    [SerializeField] private Sprite emoteIcon;
    [SerializeField] private string emoteName;

    private float cooldownTimer = 0f;

    public void ExecuteAbility(PlayerController player)
    {
        if (cooldownTimer <= 0)
        {
            cooldownTimer = cooldownDuration;
            Debug.Log($"🎭 Emote executed: {emoteName}");
        }
    }

    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public float GetCooldownProgress()
    {
        return 1f - (cooldownTimer / cooldownDuration);
    }

    public bool IsOnCooldown()
    {
        return cooldownTimer > 0;
    }
}
