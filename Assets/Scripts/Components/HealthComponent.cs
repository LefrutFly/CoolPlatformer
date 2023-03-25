using Lefrut.Framework;
using System;
using UnityEngine;

[Serializable]
public class HealthComponent : IData
{
    public event Action ChangedHealth;
    public event Action TakedDamage;
    public event Action ZeroHealth;


    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value <= 0)
            {
                health = 0;
                ZeroHealth?.Invoke();
            }
            else if(value > maxHealth)
            {
                health = maxHealth;
            }
            else
            {
                health = value;
            }

            ChangedHealth?.Invoke();
        }
    }

    public float MaxHealth { get => maxHealth; set => maxHealth = value; }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        TakedDamage?.Invoke();
    }
}
