using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour {

    private Transform target;

    [SerializeField]
    Transform defaulttarget;

    private EnemyHealthScript targetEnemy;

    [SerializeField]
    float range = 10f;

    [SerializeField]
    GameObject bullets;
    [SerializeField]
    float DefaultFireCooldown = 3f;
    float FireCooldown;

    [SerializeField]
    string enemyTag = "Enemy";

    [SerializeField]
    Transform RotatePart;
    [SerializeField]
    float turnSpeed = 10f;
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    float maxhealth = 100;
    
    float health;

    void Start()
    {
        health = maxhealth;
        FireCooldown = DefaultFireCooldown;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<EnemyHealthScript>();

            if (targetEnemy.GetHealth() <= 0f)
                target = defaulttarget;
        }
        else
        {
            target = defaulttarget;
        }

    }

    // Update is called once per frame
    void Update()
    {
        LockOnTarget();

        if (target != defaulttarget)
        {
            if (FireCooldown <= 0f)
            {
                Fire();
                FireCooldown = DefaultFireCooldown;
            }

            FireCooldown -= Time.deltaTime;
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(RotatePart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        RotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Fire()
    {
        GameObject Bullets = (GameObject)Instantiate(bullets, firePoint.position, firePoint.rotation);
        Bullet bullet = Bullets.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Lockon(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void AddHealth(float amt)
    {
        health += amt;
    }

    public float GetHealth()
    {
        return health;
    }
}