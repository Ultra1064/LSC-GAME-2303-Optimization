using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public EnemyStats enemyStats;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    EnemyPool pool;

    private void Awake()
    {
        pool = GetComponent<EnemyPool>();
    }
    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        pool.CheckEnemyIDThenSpawn(spawnPoints[spawnPointIndex].position, enemyStats.enemyID);
        //Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
