using System.Collections;
using UnityEngine;

public class WeatherMachine : MonoBehaviour
{
    [SerializeField] private float weatherChangeTimer;
    [Space]
    [SerializeField] private RainWeather rain;
    [SerializeField] private ClearWeather clear;
    [SerializeField] private ForWeather fog;

    private Weather currentWeather;

    private void Start()
    {
        int id = Random.RandomRange(0, 4);

        switch (id)
        {
            case 0:
                SetClear();
                break;
            case 1:
                SetRain();
                break;
            case 2:
                SetFog();
                break;
        }

        StartCoroutine(RandomWhether());
    }

    public void SetWether(Weather weather)
    {
        if (currentWeather != null)
        {
            currentWeather.StopWeather();
        }

        currentWeather = weather;
        currentWeather.StartWeather();
    }

    private IEnumerator RandomWhether()
    {
        yield return new WaitForSeconds(weatherChangeTimer);

        int id = Random.RandomRange(0, 4);

        switch (id)
        {
            case 0:
                SetClear();
                break;
            case 1:
                SetRain();
                break;
            case 2:
                SetFog();
                break;
        }

        StartCoroutine(RandomWhether());
    }

    private void SetRain()
    {
        SetWether(rain);
    }

    private void SetFog()
    {
        SetWether(fog);
    }

    private void SetClear()
    {
        SetWether(clear);
    }
}
