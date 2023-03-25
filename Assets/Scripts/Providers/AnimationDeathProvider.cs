using Lefrut.Framework;

public class AnimationDeathProvider : MonoProvider
{
    public AnimaionDeathComponent component;

    public override IData Data => component;
}