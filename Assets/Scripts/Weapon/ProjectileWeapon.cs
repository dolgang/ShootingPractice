using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    public float attackRate;
    public float shootingForce;

    public GameObject shootingObject;

    private float _attackCooldown;
    private Transform _shootingPosition;
    private Camera _camera;

    private void Awake()
    {
        _shootingPosition = transform.Find("FirePoint");
        _camera = Camera.main;
    }

    private void Update()
    {
        CooldownApply();
        TryAttack();
        ApplyShootingPositionRotate();
    }

    private void ApplyShootingPositionRotate()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;
        
        Vector3 lookAtPoint = Vector3.zero;

        if (Physics.Raycast(ray, out hit))
        {
            lookAtPoint = hit.point;
        }
        else
        {
            lookAtPoint = ray.origin + ray.direction * 200;
        }

        _shootingPosition.LookAt(lookAtPoint);
    }

    private void CooldownApply()
    {
        if (_attackCooldown > 0)
        {
            _attackCooldown -= Time.deltaTime;
        }
    }

    private void TryAttack()
    {
        if (IsAttacking && _attackCooldown <= 0)
        {
            OnAttackInput();
            _attackCooldown = attackRate;
        }
    }    

    public override void OnAttackInput()
    {
        GameObject shootedProjectile = Instantiate(shootingObject, _shootingPosition.position, _shootingPosition.rotation);
        ProjectileController shootedController = shootedProjectile.GetComponent<ProjectileController>();
        shootedController.InitProjectileData(shootingForce, _shootingPosition);
    }
}
