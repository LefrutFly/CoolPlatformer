using System.Collections;
using UnityEngine;

public class ForWeather : Weather
{
    [SerializeField] private GameObject fogObject;
    [SerializeField] private Animator[] animators;

    public override void StartWeather()
    {
        fogObject.SetActive(true);
        foreach (var animator in animators)
        {
            animator.SetTrigger("Start");
        }
    }

    public override void StopWeather()
    {
        StartCoroutine(Stop());
    }

    private IEnumerator Stop()
    {
        fogObject.SetActive(false);

        yield return new WaitForSeconds(1);

        foreach (var animator in animators)
        {
            animator.SetTrigger("Stop");
        }
    }
}