using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public Animator animator;
    public float value = 100;
    public void DealDamage(float damage)
    {
        value -= damage;
        if (value <= 0)
        {
            animator.SetTrigger("death");
            GetComponent<EnemyAI>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("hit");
        }
    }
}
