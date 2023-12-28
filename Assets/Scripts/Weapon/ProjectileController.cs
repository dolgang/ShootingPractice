using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    private float _shootingForce;
    private Transform _shootingPoint;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        _rigidbody.AddForce(_shootingPoint.forward * _shootingForce, ForceMode.Impulse);
    }

    private void Update()
    {
        if (_rigidbody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }

    public void InitProjectileData(float shootingForce, Transform shootingPoint)
    {
        _shootingForce = shootingForce;
        _shootingPoint = shootingPoint;
    }
}
