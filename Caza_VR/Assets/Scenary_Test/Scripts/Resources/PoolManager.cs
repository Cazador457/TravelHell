using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform[] optionalRoute = null)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"No existe el tag {tag} en el PoolManager");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        //MUY IMPORTANTE: moverlo ANTES de activarlo
        objectToSpawn.transform.SetPositionAndRotation(position, rotation);
        objectToSpawn.SetActive(true);

        // Si tiene un script con IPath, pasa la ruta
        IPath patrolPool = objectToSpawn.GetComponent<IPath>();
        if (patrolPool != null)
        {
            patrolPool.OnSpawned(optionalRoute);
        }

        //Reencolar después de usarlo
        poolDictionary[tag].Enqueue(objectToSpawn);

        //Log de depuración
        Debug.Log($"Spawned '{objectToSpawn.name}' en posición {position}");

        return objectToSpawn;
    }
}