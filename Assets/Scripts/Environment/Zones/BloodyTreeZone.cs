using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodyTreeZone : MonoBehaviour
{
    private PlyareSpawner spawner;

    private void Start()
    {
        spawner = GameLinks.GetLink<PlyareSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (player.Providers.TryGet(out ManaProvider manaProvider))
            {
                manaProvider.component.Mana = 0;
            }
            if (spawner.Systems.TryGet(out PlayerSpawnerSystem playerSpawnerSystem))
            {
                playerSpawnerSystem.IsActive = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            if (spawner.Systems.TryGet(out PlayerSpawnerSystem playerSpawnerSystem))
            {
                playerSpawnerSystem.IsActive = true;
            }
        }
    }
}
