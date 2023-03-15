using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyRight : MonoBehaviour
{
    public float speed = 10f;

    public int health = 100;
    public int value = 50;

    private Transform targetRight;
    private int wavepointIndexRight = 0;

    void Start()
    {
        targetRight = WaypointsRight.pointsRight[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 dir = targetRight.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetRight.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndexRight >= WaypointsRight.pointsRight.Length - 1)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }

        wavepointIndexRight++;
        targetRight = WaypointsRight.pointsRight[wavepointIndexRight];
    }


}
