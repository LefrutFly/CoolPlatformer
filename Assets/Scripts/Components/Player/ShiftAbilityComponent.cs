using Lefrut.Framework;

[System.Serializable]
public struct ShiftAbilityComponent : IData
{
    public float range;
    public float duration;
    public float cooldown;
    public float manaCost;
}
