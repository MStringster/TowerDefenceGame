using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health Settings")]
    [SerializeField] int maxHealth = 5;
    [Tooltip("Adds amount to max hitpoints when enemy dies")]
    [SerializeField] int difficultyRamp = 1;
    int currentHealth = 0;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hit");
        ProcessHit();

    }
    void ProcessHit()
    {
        Debug.Log("Hit");
        currentHealth--;

        if (currentHealth <= 0)
        {
            EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        enemy.RewardGold();
        maxHealth += difficultyRamp;
        gameObject.SetActive(false);
    }
}
