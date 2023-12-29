using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    private float _shootingForce;
    private Transform _shootingPoint;
    private float _curDuration;
    private LayerMask _layerMask;

    private bool isReady = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
        _layerMask = LayerMask.NameToLayer("Environments");
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!isReady)
            return;

        if (isReady && !_rigidbody.isKinematic)
            _curDuration += Time.deltaTime;

        if (_curDuration > 5 && !_rigidbody.isKinematic)
            DestroyBulletObject();

        if (_rigidbody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
    }

    public void InitProjectileData(float shootingForce, Transform shootingPoint)
    {
        _shootingForce = shootingForce;
        _shootingPoint = shootingPoint;

        isReady = true;
    }

    public void ShootingStart()
    {
        _rigidbody.AddForce(_shootingPoint.forward * _shootingForce, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & _layerMask.value) != 0)
        {
            _rigidbody.isKinematic = true;
        }
    }


    private void DestroyBulletObject()
    {
        isReady = false;
        _curDuration = 0;
        _rigidbody.velocity = Vector3.zero;
        ProjectileManager.instance.RemoveBulletObject(gameObject);
    }
}
