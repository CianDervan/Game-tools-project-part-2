using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;

    [SerializeField] List<Pool> pools;

    Dictionary<string, Queue<GameObject>> poolsDictionary;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if(Instance != this)
            {
                Destroy(this);
            }
        }
    }
    private void Start()
    {
        poolsDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            // Create queue
            Queue<GameObject> objectPool = new Queue<GameObject>();
            // Instantiate all elements

            for (int i = 0; i < pool.size; i++)
            {
                GameObject go = Instantiate(pool.prefab);
                go.SetActive(false);
                objectPool.Enqueue(go);
            }

            poolsDictionary.Add(pool.tag, objectPool);

            // Add to dictionary

        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolsDictionary.ContainsKey(tag))
        {
            return null;
        }


        GameObject go = poolsDictionary[tag].Dequeue();
        go.SetActive(true);
        go.transform.position = position;
        go.transform.rotation = rotation;

        poolsDictionary[tag].Enqueue(go);


        IPoolable objectToPool = go.GetComponent<IPoolable>();
        if (objectToPool != null)
        {
            objectToPool.OnObjectPolled();
        }

        return go;

    }
}
