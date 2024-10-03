using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    Animator animator;
    SpawnRandomItem item;

    public bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        item = FindObjectOfType<SpawnRandomItem>();
    }

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().OnDamageTaken();
        enemyHealth -= damage;
        if(enemyHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        animator.SetTrigger("Die");
        item.SpawnItem();
        Destroy(gameObject);
    }

    
}
