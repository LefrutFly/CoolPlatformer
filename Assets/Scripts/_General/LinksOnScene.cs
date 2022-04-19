using UnityEngine;

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
}