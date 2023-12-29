using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;

    private ObjectPool _objectPool;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _objectPool = GetComponentInChildren<ObjectPool>();
    }

    public GameObject GetBulletObject()
    {
        GameObject obj = _objectPool.GetBulletObjectFromObjectPool();
        obj.SetActive(true);
        return obj;
    }

    public void RemoveBulletObject(GameObject obj)
    {
        _objectPool.RemoveBulletObjectToObjectPool(obj);
    }
}
