using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private string savePath;
    public GameData stats = new GameData();

    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "gameData.json");
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(stats, true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Datos guardados en: {savePath}");
    }
    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            stats = JsonUtility.FromJson<GameData>(json);
            Debug.Log("Datos cargados");
        }
        else
        {
            Debug.Log("Archivo JSON no encontrado, creando uno");
            SaveData();
        }
    }
}
[System.Serializable]
public class GameData
{
    public int bulletsFired;
    public int enemiesKilled;
    public float playTime;
}