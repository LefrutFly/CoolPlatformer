using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReincarnationScreen : MonoBehaviour
{
    [SerializeField] private GameObject ReincarnationScreenObject;

    private HealthComponent health;

    private void Start()
    {
        health = GameLinks.GetLink<Player>().Providers.Get<HealthProvider>().component;

        if (health == null) return;
        health.ZeroHealth += ShowScreen;
    }

    private void OnDestroy()
    {
        if (health == null) return;
        health.ZeroHealth -= ShowScreen;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CloseScreen();
        }
    }

    private void ShowScreen()
    {
        ReincarnationScreenObject.SetActive(true);
    }

    private void CloseScreen()
    {
        ReincarnationScreenObject.SetActive(false);
    }
}
