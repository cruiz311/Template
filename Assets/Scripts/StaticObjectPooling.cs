using System.Collections.Generic;
using UnityEngine;

public class StaticObjectPooling : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;

    private List<PoolObject> pool = new List<PoolObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            PoolObject poolObject = obj.GetComponent<PoolObject>();
            if (poolObject != null)
            {
                poolObject.Deactivate();
                pool.Add(poolObject);
            }
            else
            {
                Debug.LogError("Prefab does not contain PoolObject component.");
                Destroy(obj);
            }
        }
    }

    public PoolObject GetObjectFromPool()
    {
        foreach (PoolObject obj in pool)
        {
            if (obj.isAvailable)
            {
                return obj;
            }
        }

        Debug.LogWarning("No available objects in the pool. Consider increasing the pool size.");
        return null;
    }
}
