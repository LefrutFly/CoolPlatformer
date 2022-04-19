public class HealthBar : Entity
{
    protected override void Initialize()
    {
        AddSystem(new HealthBarSystem());
    }
}
