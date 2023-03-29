using Lefrut.Framework;
using UnityEngine;

public class PlayerGunProvider : MonoProvider
{
    public PlayerGunComponent component;

    public override IData Data => component;
}
