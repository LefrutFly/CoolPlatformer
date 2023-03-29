using Lefrut.Framework;
using UnityEngine;

public class Player : Facade
{
    public PlayerInputs inputs;
    public IInventory inventory = new InventorySlotsData(99);


    protected override void InitData()
    {
        AddDataFromSystem(new PointCheckerSystem());
        AddDataFromSystem(new PlayerMoveSystem());
        AddDataFromSystem(new PlayerJumpSystem());
        AddDataFromSystem(new PlayerAttackSystem());
        AddDataFromSystem(new PlayerGunSystem());
        AddDataFromSystem(new ShiftAbilitySystem());
        AddDataFromSystem(new HighlightDamageSystem());
        AddDataFromSystem(new StuckInGroundSystem());

        AddDataFromSystem(new AnimationDeathSystem());
        AddDataFromSystem(new DisableDeathSystem());

        AddNewDataProvider(new HealthProvider());
        AddNewDataProvider(new ManaProvider());
    }

    protected override void InitSystems()
    {
        inputs = new PlayerInputs();

        AddSystem(new PointCheckerSystem());
        AddSystem(new PlayerMoveSystem());
        AddSystem(new PlayerJumpSystem());
        AddSystem(new PlayerAttackSystem());
        AddSystem(new PlayerGunSystem());
        AddSystem(new ShiftAbilitySystem());
        AddSystem(new HighlightDamageSystem());
        AddSystem(new StuckInGroundSystem());

        AddSystem(new AnimationDeathSystem());
        AddSystem(new DisableDeathSystem());
    }

    protected override void OnEnable()
    {
        inputs.Enable();

        base.OnEnable();
    }

    protected override void OnDisable()
    {
        inputs.Disable();

        base.OnDisable();
    }
}