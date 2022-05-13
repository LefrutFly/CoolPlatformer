using UnityEngine;
using UnityEngine.SceneManagement;

public class LinksOnScene : MonoBehaviour
{
    [SerializeField] private Player player;

    private void Awake()
    {
        GameLinks.AddLink(this);
        GameLinks.AddLink(player);
    }

    private void OnDisable()
    {
        GameLinks.DeleteAll();
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}