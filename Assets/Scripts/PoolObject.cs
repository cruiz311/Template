using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public bool isAvailable = true;

    public void Activate()
    {
        gameObject.SetActive(true);
        isAvailable = false;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        isAvailable = true;
    }
}
