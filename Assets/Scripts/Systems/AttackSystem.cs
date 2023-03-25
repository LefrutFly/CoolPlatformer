using Lefrut.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem<AlliesType> : BaseSystem, IUpdatableSystem where AlliesType : Facade
{
    private Coroutine attack;


    public override void AddProviders()
    {
        NeededProviders.Set(new AttackProvider(), this);
        NeededProviders.Set(new EntityProvider(), this);
        NeededProviders.Set(new PossibleToAttackProvider(), this);
    }

    public void Update()
    {
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

    private void TakeDamage(Collider2D collider, Facade thisEntity, float damage)
    {
        if (collider == null || thisEntity == null) return;

        List<Collider2D> colliders = new List<Collider2D>();
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;
        collider.OverlapCollider(contactFilter, colliders);

        foreach (var c in colliders)
        {
            if (c.gameObject.TryGetComponent(out Facade entity) && c.gameObject != thisEntity.gameObject)
            {
                if (entity.Providers.TryGet(out HealthProvider healthProvider))
                {
                    var healthComponent = healthProvider.component;

                    if(entity.gameObject.GetComponent<AlliesType>() == null)
                    {
                        healthComponent.TakeDamage(damage);
                    }
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
