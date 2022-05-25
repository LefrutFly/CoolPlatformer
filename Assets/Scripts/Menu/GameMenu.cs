using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject MenuObject;
    [SerializeField] private string startMenuName;

    private void LateUpdate()
    {
        UseMenu();
    }

    public void ContinueButton()
    {
        CloseMenu();
    }

    public void ReloadButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(startMenuName);
    }

    private void UseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuObject.activeSelf == true)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    private void OpenMenu()
    {
        MenuObject.SetActive(true);
        Time.timeScale = 0;
    }

    private void CloseMenu()
    {
        MenuObject.SetActive(false);
        Time.timeScale = 1;
    }
}
