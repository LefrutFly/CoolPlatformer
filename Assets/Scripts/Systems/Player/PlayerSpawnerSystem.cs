using System.Collections;
using UnityEngine;

public class PlayerSpawnerSystem : BaseSystem, IStartableSystem, IUpdatableSystem
{
    private Coroutine spawnPlayer;

    public void Start()
    {
        if (IsActive == false) return;

        if (Providers.Has<PlayerSpawnerProvider>() == false)
            return;

        var playerSpawnerProvider = Providers.Get<PlayerSpawnerProvider>().component;

        if (playerSpawnerProvider.player == null)
            playerSpawnerProvider.player = GameLinks.GetLink<Player>() as Player;

        var animator = playerSpawnerProvider.animator;
        var animatorTrigger = playerSpawnerProvider.animatorTrigger;

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

    private void EnablePlayer()
    {
        var player = Providers.Get<PlayerSpawnerProvider>().component.player;

        player.gameObject.SetActive(true);

        EnableControlPlayer(player, true);
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
    }
}
