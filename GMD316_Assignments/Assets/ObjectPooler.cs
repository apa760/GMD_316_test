using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{

    public GameObject objectToPool;
    public int poolSize;
    public List<GameObject> objectPool = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializePool(objectToPool, poolSize);
    }


    void InitializePool(GameObject pooledObject, int poolSizeGiven)
    {
        for (int i = 0; i < poolSizeGiven; i++)
        {
            GameObject newObject = Instantiate(pooledObject);
            newObject.SetActive(false);
            objectPool.Add(newObject);
        }
    }

    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }

        }

        GameObject newObject = Instantiate(objectToPool);
        objectPool.Add(newObject);
        newObject.SetActive(true);

        return newObject;
    }

    public void ReturnObjectToPool(GameObject objectToPool)
    {
        objectToPool.SetActive(false);
    }
}
