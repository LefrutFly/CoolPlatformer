using Lefrut.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : BaseSystem, IUpdatableSystem
{
    private Coroutine attack;

    public override void AddProviders()
    {
        NeededProviders.Set(new PlayerAttackProvider(), this);
    }

    public void Update()
    {
        if (IsActive == false) return;

        if (attack != null) return;

        attack = Coroutines.Start(Attack());
    }

    private IEnumerator Attack()
    {
        var playerAttackComponent = (PlayerAttackComponent)Providers.Get<PlayerAttackProvider>().Data;

        var collider = playerAttackComponent.collider;
        var animator = playerAttackComponent.animator;
        var animationTrigger = playerAttackComponent.animationTrigger;
        var delayBeforeAttack = playerAttackComponent.delayBeforeAttack;
        var delayAfterAttack = playerAttackComponent.delayAfterAttack;
        var damage = playerAttackComponent.damage;

        Player player = Facade as Player;
        PlayerInputs inputs = player.inputs;
        float meleeAtackKey = inputs.Player.MeleeAttack.ReadValue<float>();

        if (meleeAtackKey > 0)
        {
            List<Collider2D> colliders = new List<Collider2D>();

            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.useTriggers = true;

            collider.OverlapCollider(contactFilter, colliders);

            animator.SetTrigger(animationTrigger);
            yield return new WaitForSeconds(delayBeforeAttack);

            foreach (var c in colliders)
            {
                if (c.gameObject.TryGetComponent(out Facade entity) && c.gameObject.GetComponent<Player>() == null)
                {
                    if (entity.Providers.TryGet(out HealthProvider healthProvider))
                    {
                        var healthComponent = healthProvider.component;

                        healthComponent.TakeDamage(damage);
                    }
                }
            }

            yield return new WaitForSeconds(delayAfterAttack);

            if (attack != null)
            {
                Coroutines.Stop(attack);
                attack = null;
            }
        }
    }
}