using Lefrut.Framework;
using UnityEngine;

public class Player : Facade
{
    public PlayerInputs inputs;
    public IInventory inventory = new InventorySlotsData(99);


    protected override void InitData()
    {
        AddData(new PointCheckerSystem());
        AddData(new PlayerMoveSystem());
        AddData(new PlayerJumpSystem());
        AddData(new PlayerAttackSystem());
        AddData(new PlayerGunSystem());
        AddData(new ShiftAbilitySystem());
        AddData(new HighlightDamageSystem());
        AddData(new StuckInGroundSystem());

        AddData(new AnimationDeathSystem());
        AddData(new DisableDeathSystem());
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