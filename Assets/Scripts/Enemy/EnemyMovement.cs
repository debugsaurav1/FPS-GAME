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
    private bool firstPunch;
    private bool secondPunch;


    private Animator enemyAnimator;
    private float punchTimer;

    private void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        punchTimer = 0;
    }
    private void Awake()
    {
        playerTarget = player.transform;

    }
    void Update()
    {
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
            print("" + punchTimer);
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
      
    }
}
