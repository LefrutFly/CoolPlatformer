using System.Collections;
using UnityEngine;

public class PlayerGunSystem : BaseSystem, IUpdatableSystem, IStartableSystem
{
    private Coroutine attack;
    private Coroutine close;
    private bool isOpen;

    public void Start()
    {
        if (IsActive == false) return;

        if (Providers.Has<PlayerGunProvider>() == false) return;

        var gunComponent = Providers.Get<PlayerGunProvider>().component;


        CreateGun(gunComponent);
        var collider = gunComponent.gun.Providers.Get<Collider2DProvider>().component.collider;

        collider.enabled = false;

        gunComponent.gun.gameObject.SetActive(false);
        isOpen = false;

        PlayerInputs inputs = (Actor as Player).inputs;

        inputs.Player.SummonGun.performed += context => EnableGun(gunComponent);
    }

    public void Update()
    {
        if (IsActive == false) return;

        if (Providers.Has<PlayerGunProvider>() == false) return;

        var gunComponent = Providers.Get<PlayerGunProvider>().component;

        RotateGun(gunComponent);

        if (attack != null) return;
        attack = Coroutines.Start(Attack(gunComponent));
    }

    private IEnumerator Attack(PlayerGunComponent gunComponent)
    {
        PlayerInputs inputs = (Actor as Player).inputs;
        float isAttackButton = inputs.Player.GunAttack.ReadValue<float>();

        var collider = gunComponent.gun.Providers.Get<Collider2DProvider>().component.collider;
        var cooldown = gunComponent.cooldown;

        if (isAttackButton > 0 && isOpen == true)
        {
            if (Providers.TryGet(out ManaProvider manaProvider))
            {
                var manaComponent = manaProvider.component;

                if (manaComponent.TakeMana(gunComponent.manaCost))
                {
                    collider.enabled = true;
                    StartAttackAnimation(gunComponent);

                    yield return new WaitForSeconds(0.3f);

                    collider.enabled = false;

                    yield return new WaitForSeconds(cooldown);
                }
            }
            else
            {
                collider.enabled = true;
                StartAttackAnimation(gunComponent);

                yield return new WaitForSeconds(0.3f);

                collider.enabled = false;

                yield return new WaitForSeconds(cooldown);
            }


            if (attack != null)
            {
                Coroutines.Stop(attack);
                attack = null;
            }
        }
    }

    private void EnableGun(PlayerGunComponent gunComponent)
    {
        if (isOpen == false)
        {
            gunComponent.gun.gameObject.SetActive(true);
            gunComponent.gun.gameObject.transform.position = gunComponent.gunPosition.position;

            isOpen = true;

            return;
        }
        else if (isOpen == true)
        {
            isOpen = false;

            if (close != null) return;
            close = Coroutines.Start(StartCloseAnimation(gunComponent));

            return;
        }
    }

    private void CreateGun(PlayerGunComponent gunComponent)
    {
        var prefab = gunComponent.gunPrefab;
        var position = gunComponent.gunPosition;

        PlayerGun gun = GameObject.Instantiate(prefab, position);
        gunComponent.gun = gun;

        gunComponent.gun.gameObject.SetActive(true);

        gunComponent.animator = gun.GetComponent<Animator>();

        if (gun.Providers.TryGet(out GunDamageProvider gunDamageProvider))
        {
            gunDamageProvider.component.damage = gunComponent.damage;
        }
    }

    private void StartAttackAnimation(PlayerGunComponent gunComponent)
    {
        var animator = gunComponent.animator;
        var trigger = gunComponent.attackAnimatorTrigger;

        animator.SetTrigger(trigger);
    }

    private IEnumerator StartCloseAnimation(PlayerGunComponent gunComponent)
    {
        var animator = gunComponent.animator;
        var closeTrigger = gunComponent.closeGunAnimatorTrigger;

        animator.SetTrigger(closeTrigger);

        yield return new WaitForSeconds(0.2f);

        gunComponent.gun.gameObject.SetActive(false);


        if (close != null)
        {
            Coroutines.Stop(close);
            close = null;
        }
    }

    private void RotateGun(PlayerGunComponent gunComponent)
    {
        if (Providers.Has<DirectionProvider>() == false) return;

        var direction = Providers.Get<DirectionProvider>().component.direction;

        if (direction.x > 0)
        {
            gunComponent.gun.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction.x < 0)
        {
            gunComponent.gun.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void TriggetStay(Collider2D collision) { }

    public void TriggetExit(Collider2D collision) { }
}
