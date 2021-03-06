﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public Animator animator;
    public List<BaseStat> Stats { get; set; }

    void Start()
    {
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

    //
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<IEnemy>().TakeDamange(Stats[0].GetCalculatedStatValue());
        }
    }
}
