public class ManaBar : Entity
{
    protected override void Initialize()
    {
        AddSystem(new ManaBarSystem());
    }
}
