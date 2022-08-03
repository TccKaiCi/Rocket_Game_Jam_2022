using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool: MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public List<PoolPack> packs;
    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        Generate();
    }

    private void Generate()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        foreach (PoolPack pack in packs)
            for (int i = 0; i < pack.amount; i++)
            {
                tmp = Instantiate(pack.objToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
    }

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy&&pooledObjects[i].CompareTag(tag))
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}