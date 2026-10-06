using UnityEngine;

// This attribute adds your ScriptableObject to the right-click Create menu
[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class EnemyStats : ScriptableObject
{
    public int startingHealth = 100;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    public int enemyID;
}
