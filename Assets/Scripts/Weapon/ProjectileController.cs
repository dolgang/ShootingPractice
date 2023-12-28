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
        transform.LookAt(_shootingPoint.forward);
    }

    private void Update()
    {
        //_rigidbody.velocity = _shootingPoint.forward * _shootingForce;
        transform.LookAt(_shootingPoint.forward);
    }

    public void InitProjectileData(float shootingForce, Transform shootingPoint)
    {
        _shootingForce = shootingForce;
        _shootingPoint = shootingPoint;
    }
}
