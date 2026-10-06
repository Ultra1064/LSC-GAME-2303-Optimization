using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] GameObject Zombear;
    [SerializeField] GameObject Zombunny;
    [SerializeField] GameObject Hellephant;
    EnemyHealth ZombearHealth;
    EnemyHealth HellephantHealth;
    EnemyHealth ZombunnyHealth;

    [SerializeField] int ZombearCount;
    [SerializeField] int ZombunnyCount;
    [SerializeField] int HellephantCount;

    Queue<GameObject> remainingZombears = new Queue<GameObject>();
    Queue<GameObject> remainingZombunnies = new Queue<GameObject>();
    Queue<GameObject> remainingHellephants = new Queue<GameObject>();

    private void Awake()
    {
        if (Zombear.GetComponent<EnemyHealth>() != null)
        {
            ZombearHealth = Zombear.GetComponent<EnemyHealth>();
        }
        if (Zombunny.GetComponent<EnemyHealth>() != null)
        {
            ZombunnyHealth = Zombunny.GetComponent<EnemyHealth>();
        }
        if (Hellephant.GetComponent<EnemyHealth>() != null)
        {
            HellephantHealth = Hellephant.GetComponent<EnemyHealth>();
        }
    }
    void Start()
    {
        for(int x = 0; x < ZombearCount; x++)
        {
            GameObject Zombear = Instantiate(this.Zombear);
            ZombearHealth.SetPool(this);
            Zombear.SetActive(false);
            AddToZombearQueue(Zombear);
        }
        for (int x = 0; x < ZombunnyCount; x++)
        {
            GameObject Zombunny = Instantiate(this.Zombunny);
            ZombunnyHealth.SetPool(this);
            Zombunny.SetActive(false);
            AddToZombunnyQueue(Zombunny);
        }
        for (int x = 0; x < HellephantCount; x++)
        {
            GameObject Hellephant = Instantiate(this.Hellephant);
            HellephantHealth.SetPool(this);
            Hellephant.SetActive(false);
            AddToHellephantQueue(Hellephant);
        }
    }
    public void SpawnZombearAtLocation(Vector3 location)
    {
        if (remainingZombears.Count > 0)
        {
            //Debug.Log("Spawning");
            GameObject current = remainingZombears.Dequeue();

            current.SetActive(true);

            current.transform.position = location;
        }
    }
    public void SpawnZombunnyAtLocation(Vector3 location)
    {
        if (remainingZombunnies.Count > 0)
        {
            //Debug.Log("Spawning");
            GameObject current = remainingZombunnies.Dequeue();

            current.SetActive(true);

            current.transform.position = location;
        }
    }
    public void SpawnHellephantAtLocation(Vector3 location)
    {
        if (remainingHellephants.Count > 0)
        {
            //Debug.Log("Spawning");
            GameObject current = remainingHellephants.Dequeue();

            current.SetActive(true);

            current.transform.position = location;
        }
    }

    public void CheckEnemyIDThenSpawn(Vector3 location, int enemyID)
    {
        switch (enemyID)
        {
            case 0:
                SpawnZombearAtLocation(location);
                break;
            case 1:
                SpawnZombunnyAtLocation(location);
                break;
            case 2:
                SpawnHellephantAtLocation(location);
                break;
        }
    }

    public void AddToZombearQueue(GameObject enemy) //ID = 0
    {
        remainingZombears.Enqueue(enemy);
    }
    public void AddToZombunnyQueue(GameObject enemy) //ID = 1
    {
        remainingZombears.Enqueue(enemy);
    }
    public void AddToHellephantQueue(GameObject enemy) //ID = 2
    {
        remainingHellephants.Enqueue(enemy);
    }

    public void CheckEnemyIDThenQueue(GameObject enemy, int enemyID)
    {
        switch (enemyID)
        {
            case 0:
                AddToZombearQueue(enemy);
                break;
            case 1:
                AddToZombunnyQueue(enemy);
                break;
            case 2:
                AddToHellephantQueue(enemy);
                break;
        }
    }
}
