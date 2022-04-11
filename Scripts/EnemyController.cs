using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    public Transform target;
    float distance;
    NavMeshAgent agent;

    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > 10)
        {
            agent.enabled = false;
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
            animator.SetBool("Attack", false);
        }

        if (distance <= 10 & distance > 1.5f)
        {
            agent.enabled = true;
            agent.SetDestination(target.position);
            animator.SetBool("Idle", false);
            animator.SetBool("Run", true);
            animator.SetBool("Attack", false);
        }

        if (distance <= 1.5f)
        {
            agent.enabled = false;
            animator.SetBool("Idle", false);
            animator.SetBool("Run", false);
            animator.SetBool("Attack", true);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
         animator.SetBool("isDeath", true);

        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }
}
