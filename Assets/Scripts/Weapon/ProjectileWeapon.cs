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

    private void Update()
    {
        CooldownApply();
        TryAttack();
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
        GameObject shootedProjectile = Instantiate(shootingObject, _shootingPosition.position, Quaternion.identity);
        ProjectileController shootedController = shootedProjectile.GetComponent<ProjectileController>();
    }
}
