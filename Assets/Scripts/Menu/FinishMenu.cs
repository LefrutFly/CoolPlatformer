using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishMenu : MonoBehaviour
{
    [SerializeField] private Button goToNextLevelButton;
    [SerializeField] private int currentLevel;

    public bool isOnline;

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
        var sceneNameOnline = "Level_" + unlockLevel;
        var sceneNameOfline = "Level_" + unlockLevel + "_Of";

        if (isOnline)
        {
            SaveToServer(unlockLevel);
        }
        else
        {
            OfflineSaver.unlockedLevel = unlockLevel;
        }

        if (unlockLevel <= 6)
        {
            if (isOnline)
            {
                SceneManager.LoadScene(sceneNameOnline);
            }
            else
            {
                SceneManager.LoadScene(sceneNameOfline);
            }
            return;
        }

        Debug.LogError($"The '{sceneNameOnline}' scene doesn't exist.");
        Time.timeScale = 1;
        if (isOnline)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene("MainMenuOffline");
        }
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
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}
