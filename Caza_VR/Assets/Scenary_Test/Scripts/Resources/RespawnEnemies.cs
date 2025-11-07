using UnityEngine;
using System.Collections;

public class RespawnEnemies : MonoBehaviour
{
    public GameObject[] objectsToCheck;
    public Transform[] respawnPoints;

    private bool[] isRespawning;

    private void Start()
    {
        isRespawning = new bool[objectsToCheck.Length];
    }
    public void Update()
    {
        EnemyState();
    }
    public void EnemyState()
    {
        for (int i = 0; i < objectsToCheck.Length; i++)
        {
            GameObject obj = objectsToCheck[i];

            // Si está desactivado y NO se está haciendo respawn…
            if (!obj.activeSelf && !isRespawning[i])
            {
                StartCoroutine(RespawnObject(obj, i));
            }
        }
    }
    private IEnumerator RespawnObject(GameObject obj, int index)
    {
        isRespawning[index] = true;

        yield return new WaitForSeconds(2f);

        int p = Random.Range(0, respawnPoints.Length);

        obj.transform.position = respawnPoints[p].position;
        obj.transform.rotation = respawnPoints[p].rotation;

        obj.SetActive(true);

        isRespawning[index] = false;

    }
}
