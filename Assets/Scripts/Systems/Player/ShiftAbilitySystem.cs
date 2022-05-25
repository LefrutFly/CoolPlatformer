using UnityEngine;
using DG.Tweening;
using System.Collections;

public class ShiftAbilitySystem : BaseSystem, IUpdatableSystem
{
    private Coroutine cooldownCoroutine;
    private bool isReady = true;

    public void Update()
    {
        if (Providers.Has<ShiftAbilityProvider>() == false ||
            Providers.Has<EntityProvider>() == false ||
            Providers.Has<PlayerMoveProvider>() == false ||
            IsActive == false)
            return;

        var shiftAbilityComponent = Providers.Get<ShiftAbilityProvider>().component;
        var entity = Providers.Get<EntityProvider>().component.entity;
        var moveCmponent = Providers.Get<PlayerMoveProvider>().component;

        Shift(shiftAbilityComponent, entity, moveCmponent);
    }

    private void Shift(ShiftAbilityComponent shiftAbility, Entity entity, PlayerMoveComponent moveComponent)
    {
        var range = shiftAbility.range;
        var duration = shiftAbility.duration;
        var cooldown = shiftAbility.cooldown;
        var manaCost = shiftAbility.manaCost;
        var keyCode = shiftAbility.keyCode;

        var leftKeyCode = moveComponent.left;
        var rightKeyCode = moveComponent.right;

        Vector3 direction = FindDirection(keyCode, leftKeyCode, rightKeyCode);
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

    private Vector3 FindDirection(KeyCode keyCode, KeyCode leftKeyCode, KeyCode rightKeyCode)
    {
        Vector3 direction = new Vector3(0, 0);

        if (Input.GetKey(keyCode) && Input.GetKeyDown(leftKeyCode) || 
            Input.GetKeyDown(keyCode) && Input.GetKey(leftKeyCode))
        {
            direction = new Vector3(-1, 0);
        }
        else if (Input.GetKey(keyCode) && Input.GetKeyDown(rightKeyCode) || 
                 Input.GetKeyDown(keyCode) && Input.GetKey(rightKeyCode))
        {
            direction = new Vector3(1, 0);
        }
        else
        {
            direction = Vector3.zero;
        }

        return direction;
    }

    private void MoveEntity(Entity entity, Vector3 nextPoint, float duration, float cooldown)
    {
        if (isReady)
        {
            entity.transform.DOMove(nextPoint, duration);

            if(cooldownCoroutine == null)
            {
                cooldownCoroutine = Coroutines.Start(Timer(cooldown));
            }
        }
    }

    private void MoveEntity(Entity entity, Vector3 nextPoint, float duration, float cooldown, ManaComponent mana, float manaCost)
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

        if(cooldownCoroutine != null)
        {
            Coroutines.Stop(cooldownCoroutine);
            cooldownCoroutine = null;
        }
    }
}