using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform pointStartMenu;
    [SerializeField] private float durationToStartMenu;

    public void BackToMainMenu()
    {
        var vector = pointStartMenu.transform.position;

        camera.transform.DOMoveY(vector.y, durationToStartMenu);
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
