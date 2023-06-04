using Lefrut.Framework;

public class PlayerJumpProvider : IProvider
{
    public PlayerJumpComponent component;

    public override IData Data => component;
}
