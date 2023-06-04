using Lefrut.Framework;

public class AnimationDeathProvider : IProvider
{
    public AnimaionDeathComponent component;

    public override IData Data => component;
}