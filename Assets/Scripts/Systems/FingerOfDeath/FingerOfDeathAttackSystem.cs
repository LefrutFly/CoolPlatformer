using Lefrut.Framework;
using System.Collections;
using UnityEngine;

public class FingerOfDeathAttackSystem : BaseSystem, IUpdatableSystem, IEnableSystem
{
    private Coroutine attack_1;
    private Coroutine attack_2;
    private FingerOfDeathVisionData dataVision;
    private FingerOfDeathAttackData dataAttack;


    public override void AddProviders()
    {
        NeededProviders.Set(new FingerOfDeathAttackProvider(), this);
    }

    public void Enable()
    {
        if (IsActive == false) return;
        dataVision = (FingerOfDeathVisionData)Providers.Get<FingerOfDeathVisionProvider>().Data;
        dataAttack = (FingerOfDeathAttackData)Providers.Get<FingerOfDeathAttackProvider>().Data;
    }

    public void Update()
    {
        if (IsActive == false) return;

        if (attack_1 == null)
        {
            attack_1 = Coroutines.Start(Attack_1());
        }
        if (attack_2 == null)
        {
            attack_2 = Coroutines.Start(Attack_2());
        }
    }

    private IEnumerator Attack_1()
    {
        yield return new WaitForSeconds(dataAttack.DelayBeforeAttack_1);
        var isArea_1 = dataVision.IsPlayerInArea1;

        if (isArea_1)
        {
            var triggerAttack = dataAttack.AttackTriggerAnimation_1;
            var animator = dataAttack.Animator;

            animator.SetTrigger(triggerAttack);
        }

        yield return new WaitForSeconds(dataAttack.DelayAfterAttack_1);

        if (attack_1 != null)
        {
            Coroutines.Stop(attack_1);
            attack_1 = null;
        }
    }

    private IEnumerator Attack_2()
    {
        yield return new WaitForSeconds(dataAttack.DelayBeforeAttack_2);
        var isArea_2 = dataVision.IsPlayerInArea2;

        if (isArea_2)
        {
            var triggerAttack = dataAttack.AttackTriggerAnimation_2;
            var animator = dataAttack.Animator;

            animator.SetTrigger(triggerAttack);
        }

        yield return new WaitForSeconds(dataAttack.DelayAfterAttack_2);

        if (attack_2 != null)
        {
            Coroutines.Stop(attack_2);
            attack_2 = null;
        }
    }
}