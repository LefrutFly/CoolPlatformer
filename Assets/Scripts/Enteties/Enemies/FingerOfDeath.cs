using DG.Tweening;
using Lefrut.Framework;
using UnityEngine;

public class FingerOfDeath : EnemyTag
{
	[SerializeField] private GameObject Wall;

    protected override void InitData()
	{
        AddDataFromSystem(new AnimatorDeathSystem());
		AddDataFromSystem(new FingerOfDeathVisionSystem());
		AddDataFromSystem(new FingerOfDeathAttackSystem());
		//AddDataFromSystem(new FingerOfDeathOpenWall());

        AddNewDataProvider(new HealthProvider());
	}

	protected override void InitSystems()
	{
		AddSystem(new AnimatorDeathSystem());
		AddSystem(new FingerOfDeathVisionSystem());
		AddSystem(new FingerOfDeathAttackSystem());
		//AddSystem(new FingerOfDeathOpenWall());
	}

    public override void Run()
    {
        base.Run();
		if(Providers.Get<HealthProvider>().component.Health <= 0)
		{
			Wall.transform.DOMoveY(-35, 8f);
        }
    }
}

public class FingerOfDeathOpenWall : BaseSystem
{
    public override void AddProviders()
    {
        //throw new System.NotImplementedException();
    }
}