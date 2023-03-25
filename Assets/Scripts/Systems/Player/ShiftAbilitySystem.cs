using UnityEngine;
using DG.Tweening;
using System.Collections;
using Lefrut.Framework;

public class ShiftAbilitySystem : BaseSystem, IUpdatableSystem
{
    private Coroutine cooldownCoroutine;
    private bool isReady = true;



    public override void AddProviders()
    {
        NeededProviders.Set(new ShiftAbilityProvider(), this);
        NeededProviders.Set(new EntityProvider(), this);
        NeededProviders.Set(new PlayerMoveProvider(), this);
    }

    public void Update()
    {
        if (IsActive == false)
            return;

        var shiftAbilityComponent = Providers.Get<ShiftAbilityProvider>().component;
        var entity = Providers.Get<EntityProvider>().component.entity;
        var moveCmponent = Providers.Get<PlayerMoveProvider>().component;

        Player player = Facade as Player;
        PlayerInputs inputs = player.inputs;

        Shift(shiftAbilityComponent, entity, moveCmponent, inputs);
    }

    private void Shift(ShiftAbilityComponent shiftAbility, Facade entity, PlayerMoveComponent moveComponent, PlayerInputs inputs)
    {
        var range = shiftAbility.range;
        var duration = shiftAbility.duration;
        var cooldown = shiftAbility.cooldown;
        var manaCost = shiftAbility.manaCost;

        Vector3 direction = FindDirection(inputs);
        if (direction == Vector3.zero) return;

        Vector3 nextPoint = entity.transform.position + direction * range;

        if (Providers.Has<ManaProvider>())
        {
            var mana = Providers.Get<ManaProvider>().component;

            if (mana.IsThereMana(manaCost))
            {
                MoveEntity(entity, nextPoint, duration, cooldown, mana, manaCost);
            }
        }
        else
        {
            MoveEntity(entity, nextPoint, duration, cooldown);
        }
    }

    private Vector3 FindDirection(PlayerInputs inputs)
    {
        Vector3 direction = Vector3.zero;

        var moveDirection = inputs.Player.Move.ReadValue<Vector2>();
        var acceleration = inputs.Player.Acceleration.ReadValue<float>();

        if (acceleration > 0)
        {
            if(moveDirection.x > 0)
            {
                direction = new Vector3(1, 0);
            }
            else if(moveDirection.x < 0)
            {
                direction = new Vector3(-1, 0);
            }
        }

        return direction;
    }

    private void MoveEntity(Facade entity, Vector3 nextPoint, float duration, float cooldown)
    {
        if (isReady)
        {
            entity.transform.DOMove(nextPoint, duration);

            if (cooldownCoroutine == null)
            {
                cooldownCoroutine = Coroutines.Start(Timer(cooldown));
            }
        }
    }

    private void MoveEntity(Facade entity, Vector3 nextPoint, float duration, float cooldown, ManaComponent mana, float manaCost)
    {
        if (isReady)
        {
            entity.transform.DOMoveX(nextPoint.x, duration);
            mana.TakeMana(manaCost);

            if (cooldownCoroutine == null)
            {
                cooldownCoroutine = Coroutines.Start(Timer(cooldown));
            }
        }
    }

    private IEnumerator Timer(float cooldown)
    {
        isReady = false;

        yield return new WaitForSeconds(cooldown);

        isReady = true;

        if (cooldownCoroutine != null)
        {
            Coroutines.Stop(cooldownCoroutine);
            cooldownCoroutine = null;
        }
    }
}