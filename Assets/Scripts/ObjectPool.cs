using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private int initialPoolSize;
    [SerializeField] private int refillPoolSize;
    [SerializeField] private int maxPoolSize;

    private Queue<GameObject> objectPool = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            BulletInstantiate();
        }
    }

    public GameObject GetBulletObjectFromObjectPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        if (objectPool.Count < maxPoolSize)
        {
            ObjectSizeRefill();
            return BulletInstantiate();
        }
        else
        {
            Debug.LogWarning("already max pool size");
            return null;
        }
    }

    public void RemoveBulletObjectToObjectPool(GameObject obj)
    {
        objectPool.Enqueue(obj);
        obj.SetActive(false);
    }

    private void ObjectSizeRefill()
    {
        for (int i = 0; i < refillPoolSize; i++)
        {
            BulletInstantiate();
        }
    }

    private GameObject BulletInstantiate()
    {
        GameObject bullet = Instantiate(_bullet);
        bullet.transform.parent = transform;
        _bullet.SetActive(false);
        objectPool.Enqueue(bullet);
        return bullet;
    }
}
