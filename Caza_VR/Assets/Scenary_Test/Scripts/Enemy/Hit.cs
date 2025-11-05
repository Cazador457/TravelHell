using UnityEngine;

public class Hit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.Res();
            Debug.Log("Die");
        }
    }
}
