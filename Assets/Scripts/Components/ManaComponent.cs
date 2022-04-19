using System;
using UnityEngine;

[System.Serializable]
public class ManaComponent
{
    public event Action ChangedMana;
    public event Action ChangedMaxMana;
    public event Action TakedMana;
    public event Action AddedMana;


    [SerializeField] private float mana;
    [SerializeField] private float maxMana;

    public float Mana
    {
        get
        {
            return mana;
        }
        set
        {
            if (value <= 0)
            {
                mana = 0;
            }
            else if (value > maxMana)
            {
                mana = maxMana;
            }
            else
            {
                mana = value;
            }

            ChangedMana?.Invoke();
        }
    }

    public float MaxHealth
    {
        get
        {
            return maxMana;
        }
        set
        {
            if (value <= 0)
            {
                maxMana = 0;
                Mana = maxMana;
            }
            else if (value > maxMana)
            {
                maxMana = value;
                Mana = maxMana;
            }
            else if (value < maxMana)
            {
                maxMana = value;

                if (mana > value)
                {
                    Mana = maxMana;
                }
            }

            ChangedMaxMana?.Invoke();
        }
    }

    public bool TakeMana(float take)
    {
        if (mana - take < 0)
        {
            return false;
        }
        else
        {
            Mana -= take;
            TakedMana?.Invoke();
            return true;
        }
    }

    public void AddMana(float value)
    {
        if (mana + value > maxMana)
        {
            Mana = maxMana;
        }
        else
        {
            Mana += value;
        }

        AddedMana?.Invoke();
    }

    public bool IsThereMana(float availabilityMana)
    {
        if (mana >= availabilityMana)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
