using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool IsAttacking {  get; set; }

    public virtual void OnAttackInput()
    {

    }
}
