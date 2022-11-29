using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RainWeather : Weather
{
    [SerializeField] private Animator[] animators;
    [SerializeField] private float timeBeforeRain;
    [SerializeField] private List<GameObject> rainEffects;
    [SerializeField] private GameObject rainObject;

    public override void StartWeather()
    {
        StartCoroutine(StartRain());
    }

    public override void StopWeather()
    {
        StartCoroutine(StopRain());
    }

    private IEnumerator StartRain()
    {
        rainObject.SetActive(true);

        foreach(var rain in rainEffects)
        {
            rain.SetActive(true);
        }

        foreach (var animator in animators)
        {
            animator.SetTrigger("Start");
        }

        yield return new WaitForSeconds(timeBeforeRain);
    }

    private IEnumerator StopRain()
    {
        foreach (var animator in animators)
        {
            animator.SetTrigger("Stop");
        }

        yield return new WaitForSeconds(timeBeforeRain);

        rainObject.SetActive(false);

        foreach (var rain in rainEffects)
        {
            rain.SetActive(false);
        }
    }
}
