using Lefrut.Framework;
using UnityEngine;

public class FingerOfDeathVisionSystem : BaseSystem, IUpdatableSystem, IEnableSystem
{
    private Collider2D visionArea1;
    private Collider2D visionArea2;
    private FingerOfDeathVisionData data;
    private ColliderDeterminant colliderDeterminant = new ColliderDeterminant();


    public override void AddProviders()
    {
        NeededProviders.Set(new FingerOfDeathVisionProvider(), this);
    }

    public void Enable()
    {
        data = (FingerOfDeathVisionData)Providers.Get<FingerOfDeathVisionProvider>().Data;
        visionArea1 = data.VisionArea1;
        visionArea2 = data.VisionArea2;
    }

    public void Update()
    {
        data.IsPlayerInArea1 = colliderDeterminant.IsItT<Player>(visionArea1, Facade);
        data.IsPlayerInArea2 = colliderDeterminant.IsItT<Player>(visionArea2 , Facade);
    }
}
