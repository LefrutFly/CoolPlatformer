using Lefrut.Framework;

public class FingerOfDeath : EnemyTag
{
    protected override void InitData()
	{
        AddDataFromSystem(new AnimatorDeathSystem());
		AddDataFromSystem(new FingerOfDeathVisionSystem());
		AddDataFromSystem(new FingerOfDeathAttackSystem());

        AddNewDataProvider(new HealthProvider());
	}

	protected override void InitSystems()
	{
		AddSystem(new AnimatorDeathSystem());
		AddSystem(new FingerOfDeathVisionSystem());
		AddSystem(new FingerOfDeathAttackSystem());
	}
}