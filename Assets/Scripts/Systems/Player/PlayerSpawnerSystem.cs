using System.Collections;
using UnityEngine;

public class PlayerSpawnerSystem : BaseSystem, IStartableSystem, IUpdatableSystem
{
    private Coroutine spawnPlayer;
    private PlayerSpawnerComponent playerSpawnerComponent;

    public void Start()
    {
        if (IsActive == false) return;

        if (Providers.Has<PlayerSpawnerProvider>() == false)
            return;

        playerSpawnerComponent = Providers.Get<PlayerSpawnerProvider>().component;

        if (playerSpawnerComponent.player == null)
            playerSpawnerComponent.player = GameLinks.GetLink<Player>() as Player;

        var animator = playerSpawnerComponent.animator;
        var animatorTrigger = playerSpawnerComponent.animatorTrigger;

        DisablePlayer();
        PlayAnimator(animator, animatorTrigger);

        if (spawnPlayer != null) return;

        spawnPlayer = Coroutines.Start(SpawnPlayer());
    }

    public void Update()
    {
        if (IsActive == false) return;

        if (Providers.Has<PlayerSpawnerProvider>() == false)
            return;

        var playerSpawnerProvider = Providers.Get<PlayerSpawnerProvider>().component;

        var keyCode = playerSpawnerProvider.keyCode;
        var player = playerSpawnerProvider.player;

        if (player == null) return;

        if (Input.GetKeyDown(keyCode))
        {
            if (spawnPlayer != null) return;

            var spawnPoint = playerSpawnerProvider.spawnPoint;

            StartDeathAnimation();

            SetPlayerPosition(player.gameObject, spawnPoint);

            DisablePlayer();

            spawnPlayer = Coroutines.Start(SpawnPlayer());
        }
    }

    private IEnumerator SpawnPlayer()
    {
        var playerSpawnerProvider = Providers.Get<PlayerSpawnerProvider>().component;

        var player = playerSpawnerProvider.player;
        var delay = playerSpawnerProvider.delay;
        var animator = playerSpawnerProvider.animator;
        var animatorSpawnTrigger = playerSpawnerProvider.animatorTrigger;

        PlayAnimator(animator, animatorSpawnTrigger);

        EnableControlPlayer(player, false);

        yield return new WaitForSeconds(delay);

        SetPlayerRotation(player);
        ResetHealthPlayer(player);
        ResetManaPlayer(player);
        EnablePlayer();

        spawnPlayer = null;
    }

    private void StartDeathAnimation()
    {
        if (playerSpawnerComponent.player.Providers.Has<EntityIsDieProvider>() == true)
        {
            if (playerSpawnerComponent.player.Providers.Get<EntityIsDieProvider>().component.IsIt == false)
            {
                var player = Providers.Get<PlayerSpawnerProvider>().component.player;

                if (player.GetComponent<Player>().Systems.TryGet(out AnimaionDeathSystem animaionDeath))
                {
                    animaionDeath.Die();
                }
            }
        }
        else
        {
            var player = Providers.Get<PlayerSpawnerProvider>().component.player;

            if (player.GetComponent<Player>().Systems.TryGet(out AnimaionDeathSystem animaionDeath))
            {
                animaionDeath.Die();
            }
        }
    }

    private void EnablePlayer()
    {
        var player = Providers.Get<PlayerSpawnerProvider>().component.player;

        player.gameObject.SetActive(true);

        EnableControlPlayer(player, true);


        if (playerSpawnerComponent.player.Providers.Has<EntityIsDieProvider>() == true)
        {
            playerSpawnerComponent.player.Providers.Get<EntityIsDieProvider>().component.IsIt = false;
        }
    }

    private void DisablePlayer()
    {
        Providers.Get<PlayerSpawnerProvider>().component.player.gameObject.SetActive(false);
    }

    private void SetPlayerPosition(GameObject player, Transform spawnPoint)
    {
        player.transform.position = spawnPoint.position;
    }

    private void SetPlayerRotation(Player player)
    {
        if (player.Providers.TryGet(out ViewProvider viewProvider))
        {
            var view = viewProvider.component.view;

            view.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    private void PlayAnimator(Animator animator, string animatorTrigger)
    {
        animator.SetTrigger(animatorTrigger);
    }

    private void ResetHealthPlayer(Player player)
    {
        if (player.Providers.TryGet(out HealthProvider healthProvider))
        {
            var health = healthProvider.component;

            health.Health = health.MaxHealth;
        }
    }

    private void ResetManaPlayer(Player player)
    {
        if (player.Providers.TryGet(out ManaProvider manaProvider))
        {
            var mana = manaProvider.component;

            mana.Mana = mana.MaxHealth;
        }
    }

    private void EnableControlPlayer(Player player, bool enable)
    {
        if (player.Systems.TryGet(out PlayerMoveSystem moveSystem))
        {
            moveSystem.IsActive = enable;
        }
        if (player.Systems.TryGet(out PlayerJumpSystem jumpSystem))
        {
            jumpSystem.IsActive = enable;
        }
        if (player.Systems.TryGet(out PlayerAttackSystem attackSystem))
        {
            attackSystem.IsActive = enable;
        }
        if (player.Systems.TryGet(out PlayerGunSystem gunSystem))
        {
            gunSystem.IsActive = enable;
        }
        if(player.Systems.TryGet(out ShiftAbilitySystem shiftAbility))
        {
            shiftAbility.IsActive = enable;
        }
    }
}
