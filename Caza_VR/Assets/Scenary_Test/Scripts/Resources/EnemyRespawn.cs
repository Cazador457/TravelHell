using UnityEngine;
using System.Collections;

public class EnemyRespawn : MonoBehaviour
{
    public Transform[] respawnPoints;

    public void NotifyObjectDisabled(GameObject obj)
    {
        // Iniciar corrutina de respawn solo cuando se desactiva
        StartCoroutine(RespawnObject(obj));
    }

    private IEnumerator RespawnObject(GameObject obj)
    {
        yield return new WaitForSeconds(2f);

        // Elegir punto aleatorio
        int index = Random.Range(0, respawnPoints.Length);

        // Colocar el objeto
        obj.transform.position = respawnPoints[index].position;
        obj.transform.rotation = respawnPoints[index].rotation;

        // Activarlo
        obj.SetActive(true);
    }
}
