using System.Collections;
using UnityEngine;

[System.Serializable]
public class RainWeather : Weather
{
    [SerializeField] private Animator[] animators;
    [SerializeField] private float timeBeforeRain;
    [SerializeField] private GameObject rainEffect;
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
        rainEffect.SetActive(false);

        foreach (var animator in animators)
        {
            animator.SetTrigger("Start");
        }

        yield return new WaitForSeconds(timeBeforeRain);

        rainEffect.SetActive(true);
    }

    private IEnumerator StopRain()
    {
        foreach (var animator in animators)
        {
            animator.SetTrigger("Stop");
        }

        rainEffect.SetActive(false);

        yield return new WaitForSeconds(timeBeforeRain);

        rainObject.SetActive(false);
    }
}
