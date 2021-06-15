using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public float Speed;
    public float MaxHealth = 100;
    public float Health;
    public bool isShield = false;
    public static event Action onDie;
    private void OnEnable()
    {
        PlayerTriggerController.onTriggerCollision += UpdateHealth;
    }
    private void OnDisable()
    {
        PlayerTriggerController.onTriggerCollision -= UpdateHealth;
    }
    private void UpdateHealth(AbstractTrigger abstractTrigger)
    {
        Health += abstractTrigger.heal;
        Health -= abstractTrigger.damage;

        if (Health > MaxHealth)
            Health = MaxHealth;
        if (Health <= 0)
            onDie?.Invoke();
    }
}
