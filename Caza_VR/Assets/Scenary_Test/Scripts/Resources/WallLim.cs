using UnityEngine;

public class WallLim : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject wall;
    public float open;
    void Update()
    {
        DesactiveWall();
    }
    public void DesactiveWall()
    {
        if (gameManager.enemiesKilled >= open)
        {
            wall.SetActive(false);
        }
    }
}
