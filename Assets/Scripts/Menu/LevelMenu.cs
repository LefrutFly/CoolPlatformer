using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform pointStartMenu;
    [SerializeField] private float durationToStartMenu;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private bool isOnline = true;

    public void BackToMainMenu()
    {
        var vector = pointStartMenu.transform.position;

        camera.transform.DOMoveY(vector.y, durationToStartMenu);
    }

    public void LoadLevel(int levelIndex)
    {
        if (isOnline)
        {
            var unlockedLevel = DataBase.LoadedUserData.UnlockLevel;

            if (levelIndex <= unlockedLevel)
            {
                loadingScreen.SetActive(true);
                SceneManager.LoadScene("Level_" + levelIndex);
            }
            else
            {
                errorText.text = $"Level {levelIndex} unavailable";
            }
        }
        else
        {
            if (levelIndex <= OfflineSaver.unlockedLevel)
            {
                loadingScreen.SetActive(true);
                SceneManager.LoadScene("Level_" + levelIndex + "_Of");
            }
            else
            {
                errorText.text = $"Level {levelIndex} unavailable";
            }
        }
    }
}

public static class OfflineSaver
{
    public static int unlockedLevel = 1;
}
