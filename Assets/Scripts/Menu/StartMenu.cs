using DG.Tweening;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform pointLevelsMenu;
    [SerializeField] private float durationToLevelsMenu;


    public void Play()
    {
        var vector = pointLevelsMenu.transform.position;

        camera.transform.DOMoveY(vector.y, durationToLevelsMenu);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
