using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    public Animator animator;
    public List<BaseStat> Stats { get; set; }

    public Transform ProjectileSpawn{ get; set; }
    Fireball fireball;

    void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
        animator = GetComponentInParent<Animator>();
    }
    public void PerformAttack()
    {
        animator.SetTrigger("Base_Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("Special_Attack");

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))         {             GetComponentInChildren<BoxCollider>().enabled = true;         }
        else 
        {
            if (Input.GetKeyUp(KeyCode.X))
            {
                GetComponentInChildren<BoxCollider>().enabled = false;
            }
        } 
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
        throw new System.NotImplementedException();
    }
}
