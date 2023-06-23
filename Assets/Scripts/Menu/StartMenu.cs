using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform pointLevelsMenu;
    [SerializeField] private float durationToLevelsMenu;
    [SerializeField] private GameObject canvasLogin;


    public void Play()
    {
        var vector = pointLevelsMenu.transform.position;

        camera.transform.DOMoveY(vector.y, durationToLevelsMenu);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LogOut()
    {
        DataBase.isFirstOpen = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoOnline()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
