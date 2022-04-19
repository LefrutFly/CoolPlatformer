using UnityEngine;
/*
    public void TriggetEnter(Collider2D collision)
    {
        if (Providers.Has<PlayerGunProvider>() == false) return;

        var gunComponent = Providers.Get<PlayerGunProvider>().component;

        if(gunComponent.gun == null || gunComponent.gun.enabled == false) return;

        Damage(gunComponent, collision);
    }

    private void Damage(PlayerGunComponent gunComponent, Collider2D collision)
    {
        var damage = gunComponent.damage;

        if (collision.TryGetComponent(out Entity entity))
        {
            if (entity.Providers.TryGet(out HealthProvider healthProvider))
            {
                var health = healthProvider.component;

                health.TakeDamage(damage);
            }
        }
    }
 */

[System.Serializable]
public class DirectionComponent
{
    public Vector3 direction;
}
