using UnityEngine;
using System.Collections.Generic;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private Ability[] equippedAbilities = new Ability[4];
    private float[] abilityCooldowns = new float[4];
    private const float ABILITY_COOLDOWN = 10f;

    private void Update()
    {
        HandleAbilityInput();
        UpdateCooldowns();
    }

    private void HandleAbilityInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) UseAbility(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) UseAbility(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) UseAbility(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) UseAbility(3);
    }

    public void UseAbility(int slot)
    {
        if (slot >= 0 && slot < 4 && abilityCooldowns[slot] <= 0)
        {
            abilityCooldowns[slot] = ABILITY_COOLDOWN;
            Debug.Log($"🎭 Ability slot {slot + 1} used! Cooldown: 10s");
        }
    }

    private void UpdateCooldowns()
    {
        for (int i = 0; i < 4; i++)
        {
            if (abilityCooldowns[i] > 0)
            {
                abilityCooldowns[i] -= Time.deltaTime;
            }
        }
    }

    public void EquipAbility(int slot, Ability ability)
    {
        if (slot >= 0 && slot < 4)
        {
            equippedAbilities[slot] = ability;
        }
    }

    public float GetCooldownProgress(int slot)
    {
        return 1f - (abilityCooldowns[slot] / ABILITY_COOLDOWN);
    }
}
