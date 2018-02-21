using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    float speed = 30f;

    [SerializeField]
    int damage = 50;

    [SerializeField]
    float explosionRadius = 0f;

    [SerializeField]
    GameObject impactEffect;

    public void Lockon(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if (dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distance, Space.World);
        transform.LookAt(target);

    }

    void HitTarget()
    {
        //GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(effectIns, 5f);

        //if (explosionRadius > 0f)
        //{
        //    Explode();
        //}
        //else
        //{
        //    //Damage(target);
        //}

        Damage(target);
        Destroy(gameObject);
    }

    void Explode()
    {
        //Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        //foreach (Collider collider in colliders)
        //{
        //    if (collider.tag == "Enemy")
        //    {
        //        Damage(collider.transform);
        //    }
        //}
    }

    void Damage(Transform enemy)
    {
        EnemyHealthScript eHp = enemy.GetComponent<EnemyHealthScript>();

        if (eHp != null)
        {
            eHp.AddHealth(-damage);
            Debug.Log(eHp.GetHealth());

            if (eHp.GetHealth() <= 0f)
                enemy.gameObject.SetActive(true);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
