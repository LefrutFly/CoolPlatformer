using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finishCanvas;


    private void Start()
    {
        finishCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            finishCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
