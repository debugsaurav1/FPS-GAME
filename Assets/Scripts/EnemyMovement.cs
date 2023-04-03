using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] public float runSpeed;
    [SerializeField] public float jumpHeight;
    [SerializeField] public GameObject player;
    private Transform playerTarget;
    private bool firstPunch = false;
    private bool secondPunch = false;
    private Animator enemyAnimator;
    private float punchTimer;
    private float attackDelay;


    [Header("Health parameters")]
    [SerializeField] public float health;

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        punchTimer = 0;
    }
    private void Awake()
    {
        playerTarget = player.transform;
        health = 100f;

    }
    void Update()
    {
        /*
        if (Vector3.Distance(transform.position, playerTarget.position) > 1.5f)
        {
            var step = runSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, step);
            transform.LookAt(playerTarget.transform);
        }
    
        if (Vector3.Distance(transform.position, playerTarget.position) < 2.5f)
        {
            enemyAnimator.SetBool("firstPunch", true);
            firstPunch = true;
            punchTimer += Time.deltaTime;
        }*/
        StartAttack();
    
      
    }
   
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die() 
    {
        Destroy(this.gameObject);
    }
    public void StartAttack() 
    {
        attackDelay += Time.deltaTime;
        if (Vector3.Distance(transform.position, playerTarget.position) > 1.5f)
        {
            var step = runSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, step);
            transform.LookAt(playerTarget.transform);
        }

        if (Vector3.Distance(transform.position, playerTarget.position) < 2.5f)
        {
            enemyAnimator.SetBool("firstPunch", true);
            firstPunch = true;
            punchTimer += Time.deltaTime;

        }
        else
        {
            enemyAnimator.SetBool("firstPunch", false);
            punchTimer = 0;
        }
        if (firstPunch == true && punchTimer > 2f)
            {
                enemyAnimator.SetBool("secondPunch", true);
                secondPunch = true;
        }

        if (firstPunch == true && Vector3.Distance(transform.position, playerTarget.position) < 2.5f && attackDelay > 5f)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            FirstPersonController firstPersonControllerScript = playerObject.GetComponent<FirstPersonController>();
            firstPersonControllerScript.EnemyDamage(10f);
            attackDelay = 0;
        }
        if (firstPunch == true && secondPunch == true && Vector3.Distance(transform.position, playerTarget.position) < 2.5f && attackDelay > 5f)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            FirstPersonController firstPersonControllerScript = playerObject.GetComponent<FirstPersonController>();
            firstPersonControllerScript.EnemyDamage(20f);
            attackDelay = 0;
        }
    }
     
}
