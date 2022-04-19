using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : BaseSystem, IUpdatableSystem
{
    private Coroutine attack;

    public void Update()
    {
        if (Providers.Has<AttackProvider>() == false ||
            Providers.Has<EntityProvider>() == false ||
            Providers.Has<PossibleToAttackProvider>() == false)
            return;

        if (attack != null) return;

        attack = Coroutines.Start(Attack());
    }

    private IEnumerator Attack()
    {
        var playerAttackComponent = Providers.Get<AttackProvider>().component;

        var collider = playerAttackComponent.collider;
        var animator = playerAttackComponent.animator;
        var animationTrigger = playerAttackComponent.animationTrigger;
        var delayBeforeAttack = playerAttackComponent.delayBeforeAttack;
        var delayAfterAttack = playerAttackComponent.delayAfterAttack;
        var damage = playerAttackComponent.damage;

        var thisEntity = Providers.Get<EntityProvider>().component.entity;

        bool isPossibleToAttack;

        if (Providers.Has<PossibleToAttackProvider>() == false) 
            isPossibleToAttack = true;
        else 
            isPossibleToAttack = Providers.Get<PossibleToAttackProvider>().component.IsIt;


        if (isPossibleToAttack == true)
        {
            PlayAnimation(animator, animationTrigger);

            yield return new WaitForSeconds(delayBeforeAttack);

            TakeDamage(collider, thisEntity, damage);

            yield return new WaitForSeconds(delayAfterAttack);

            StopAttack();
        }
    }

    private void PlayAnimation(Animator animator, string animationTrigger)
    {
        if (animationTrigger == null || animationTrigger == null) return;

        animator.SetTrigger(animationTrigger);
    }

    private void TakeDamage(Collider2D collider, Entity thisEntity, float damage)
    {
        if (collider == null || thisEntity == null) return;

        List<Collider2D> colliders = new List<Collider2D>();
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;
        collider.OverlapCollider(contactFilter, colliders);

        foreach (var c in colliders)
        {
            if (c.gameObject.TryGetComponent(out Entity entity) && c.gameObject != thisEntity.gameObject)
            {
                if (entity.Providers.TryGet(out HealthProvider healthProvider))
                {
                    var healthComponent = healthProvider.component;

                    healthComponent.TakeDamage(damage);
                }
            }
        }
    }

    private void StopAttack()
    {
        if (attack != null)
        {
            Coroutines.Stop(attack);
            attack = null;
        }
    }
}
