using System;
using UnityEngine;

public abstract class InventoryItem
{
    public event Action UpdatedEvent;

    public virtual long ID { get; }
    public virtual string Name { get; }
    public virtual bool IsEquipped 
    {
        get
        {
            return IsEquipped;
        }
        set
        {
            IsEquipped = value;
            UpdatedEvent?.Invoke();
        }
    }
    public virtual int Count
    {
        get
        {
            return Count;
        }
        set
        {
            Count = value;
            UpdatedEvent?.Invoke();
        }
    }
    public virtual Sprite Sprite
    {
        get
        {
            return Sprite;
        }
        set
        {
            Sprite = value;
            UpdatedEvent?.Invoke();
        }
    }
}
