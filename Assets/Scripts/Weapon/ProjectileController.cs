using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    private float _flyingForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        _rigidbody.velocity = transform.forward * _flyingForce;
    }

    public void InitProjectileData(float shootingForce)
    {
        _flyingForce = shootingForce;
    }
}
