using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [Header("Targeting Settings")]
    [SerializeField] Transform weapon;
    [Tooltip("Distance the tower will be able to shoot (Drawn on screen by gizmo)")]
    [SerializeField] float range = 15f;
    [Tooltip("Partical Effect for the Tower projectiles")]
    [SerializeField] ParticleSystem projectileParticles;


    Transform target;
  
    void Update()
    {
        FindClosestTarget();
        AimWeapon();        
    }
    
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy e in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, e.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = e.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }    
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
