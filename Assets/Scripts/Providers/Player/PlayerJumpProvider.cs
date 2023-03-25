using Lefrut.Framework;

public class PlayerJumpProvider : MonoProvider
{
    public PlayerJumpComponent component;

    public override IData Data => component;
}
