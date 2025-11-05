using UnityEngine;

public class ReturnFlame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneChangeManager.Instance.ChangeScene();
            Debug.Log("lograste Salir");
        }
    }
}
