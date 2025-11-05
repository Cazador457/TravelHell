using UnityEngine;

public class BlockWalls : MonoBehaviour
{
    public GameObject key;
    public GameObject[] wallObs;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == key)
        {
            GameManager.Instance.InsideObject(false);
            GameManager.Instance.OffWalls(wallObs);
            Debug.Log("Walls Off");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject obj in wallObs)
                obj.SetActive(true);
        }
        Debug.Log("On Secret Room");
    }
}
