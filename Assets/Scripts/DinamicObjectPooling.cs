using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectPooling : MonoBehaviour
{
    public GameObject prefab;

    private List<PoolObject> pool = new List<PoolObject>();

    public PoolObject CreatePooledObject()
    {
        GameObject obj = Instantiate(prefab, transform);
        PoolObject poolObject = obj.GetComponent<PoolObject>();
        if (poolObject != null)
        {
            poolObject.Deactivate();
            pool.Add(poolObject);
            return poolObject;
        }
        else
        {
            Debug.LogError("Prefab does not contain PoolObject component.");
            Destroy(obj);
            return null;
        }
    }

    public void ReclaimObject(PoolObject obj)
    {
        obj.Deactivate();
    }
}
