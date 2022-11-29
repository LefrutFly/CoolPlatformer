using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : BaseSystem, IUpdatableSystem
{
    private Coroutine attack;

    public void Update()
    {
        if (IsActive == false) return;

        if (Providers.Has<PlayerAttackProvider>() == false) return;

        if (attack != null) return;

        attack = Coroutines.Start(Attack());
    }

    private IEnumerator Attack()
    {
        var playerAttackComponent = Providers.Get<PlayerAttackProvider>().component;

        var collider = playerAttackComponent.collider;
        var animator = playerAttackComponent.animator;
        var animationTrigger = playerAttackComponent.animationTrigger;
        var delayBeforeAttack = playerAttackComponent.delayBeforeAttack;
        var delayAfterAttack = playerAttackComponent.delayAfterAttack;
        var damage = playerAttackComponent.damage;

        Player player = Actor as Player;
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
                if (c.gameObject.TryGetComponent(out Entity entity) && c.gameObject.GetComponent<Player>() == null)
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