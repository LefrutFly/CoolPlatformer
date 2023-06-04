using Lefrut.Framework;
using UnityEngine;

public class PlayerGunProvider : IProvider
{
    public PlayerGunComponent component;

    public override IData Data => component;
}
