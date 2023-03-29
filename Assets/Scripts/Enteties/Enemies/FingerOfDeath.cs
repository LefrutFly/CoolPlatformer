using Lefrut.Framework;

public class FingerOfDeath : Facade
{
	public AnimatorDeathSystem AnimatorDeathSystem { get; private set; } = new AnimatorDeathSystem();

	public HealthProvider HealthProvider { get; private set; } = new HealthProvider();


    protected override void InitData()
	{
        AddDataFromSystem(AnimatorDeathSystem);

        AddNewDataProvider(HealthProvider);
	}

	protected override void InitSystems()
	{
		AddSystem(AnimatorDeathSystem);
	}
}
