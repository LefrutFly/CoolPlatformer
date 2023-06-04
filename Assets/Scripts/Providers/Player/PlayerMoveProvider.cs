using Lefrut.Framework;

public class PlayerMoveProvider : IProvider 
{
    public PlayerMoveComponent component;

    public override IData Data => component;
}
