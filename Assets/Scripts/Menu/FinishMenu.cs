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
        var sceneName = "Level_" + (currentLevel + 1);
        var sceneCount = SceneManager.sceneCount;

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
}
