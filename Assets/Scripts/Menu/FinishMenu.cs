using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    [SerializeField] private Button goToNextLevelButton;
    [SerializeField] private int currentLevel;

    private void OnEnable()
    {
        goToNextLevelButton.onClick.AddListener(GoToNextLevel);
    }

    private void OnDisable()
    {
        goToNextLevelButton.onClick.RemoveListener(GoToNextLevel);
    }

    private void GoToNextLevel()
    {
        var unlockLevel = currentLevel + 1;
        var sceneName = "Level_" + unlockLevel;
        var sceneCount = SceneManager.sceneCount;

        SaveToServer(unlockLevel);

        for (int i = 0; i < sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);

            if (scene.name == sceneName)
            {
                SceneManager.LoadScene(sceneName);
                return;
            }
        }
        Debug.LogError($"The '{sceneName}' scene doesn't exist.");
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    private void SaveToServer(int unlockLevel)
    {
        try
        {
            var separator = DataBase.LoadedUserData.Username;
            var newData = DataBase.LoadedUserData;
            newData.UnlockLevel = unlockLevel;

            DataBase.SendToDataBase(newData, separator);
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }
}
