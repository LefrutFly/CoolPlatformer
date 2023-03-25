using Lefrut.Framework;

public class PlayerMoveProvider : MonoProvider 
{
    public PlayerMoveComponent component;

    public override IData Data => component;
}
