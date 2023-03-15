using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public int damage = 50;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    public GameObject impactEffectTarget;

    public void Seek (Transform _target)
    {
        target = _target;   
    }

    void Update()
    {
       if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);


    }
     void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
            DamageRight(target);
            DamageBig(target);
            DamageBigRight(target);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
       Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
                DamageRight(collider.transform);
                DamageBig(collider.transform);
                DamageBigRight(collider.transform);
            }
        }
    }

 
    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void DamageRight(Transform enemyRight)
    {
        EnemyRight eRight = enemyRight.GetComponent<EnemyRight>();

        if (eRight != null)
        {
            eRight.TakeDamage(damage);
        }
    }

    void DamageBig(Transform bigenemy)
    {
        BigEnemy eBig = bigenemy.GetComponent<BigEnemy>();

        if (eBig != null)
        {
            eBig.TakeDamage(damage);
        }
    }
    void DamageBigRight(Transform bigenemyright)
    {
        BigEnemyRight eBigRight = bigenemyright.GetComponent<BigEnemyRight>();

        if (eBigRight != null)
        {
            eBigRight.TakeDamage(damage);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
