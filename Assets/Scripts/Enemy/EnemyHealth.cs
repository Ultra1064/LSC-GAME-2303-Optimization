using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public EnemyStats stats;
    public int currentHealth;
    public AudioClip deathClip;

    protected Animator anim;
    protected AudioSource enemyAudio;
    protected ParticleSystem hitParticles;
    protected CapsuleCollider capsuleCollider;
    protected Rigidbody myBody;
    protected NavMeshAgent myLegs;
    protected bool isDead;
    protected bool isSinking;

    protected int deadHash;

    protected EnemyPool pool;

    public void SetPool(EnemyPool pool)
    {
        this.pool = pool;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        myBody = GetComponent<Rigidbody>();
        myLegs = GetComponent<NavMeshAgent>();


        currentHealth = stats.startingHealth;

        deadHash = Animator.StringToHash("Dead");
    }

    void Update()
    {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * stats.sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;

        enemyAudio.Play();

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger(deadHash);

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }

    public void StartSinking()
    {
        myLegs.enabled = false;
        myBody.isKinematic = true;
        isSinking = true;
        ScoreManager.score.score += stats.scoreValue;

        StartCoroutine(ReturnToPool());
        //Destroy (gameObject, 2f); //Check ReturnToPool
    }

    IEnumerator ReturnToPool()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        if (pool != null)
        {
            pool.CheckEnemyIDThenQueue(gameObject, stats.enemyID); //On Disable does not work here because I believe it only works when the script is disabled, not the object it's attached to
        }
    }
}
