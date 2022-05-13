using System.Collections;
using UnityEngine;

public class DeletableObjectCreator
{
    private GameObject prefab;
    private float timerBeforeDelete;
    private Transform spawnPoint;
    private Coroutine delete;

    public DeletableObjectCreator(GameObject prefab, float timerBeforeDelete, Transform spawnPoint)
    {
        this.prefab = prefab;
        this.timerBeforeDelete = timerBeforeDelete;
        this.spawnPoint = spawnPoint;
    }

    public void Create()
    {
        GameObject deathObject = GameObject.Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        if (delete != null) return;

        delete = Coroutines.Start(DeleteDeathObject(timerBeforeDelete, deathObject));
    }

    private IEnumerator DeleteDeathObject(float timerBeforeDelete, GameObject deathObject)
    {
        yield return new WaitForSeconds(timerBeforeDelete);
        MonoBehaviour.Destroy(deathObject);
        delete = null;
    }
}