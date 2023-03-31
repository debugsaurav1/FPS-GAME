using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] public float runSpeed;
    [SerializeField] public float jumpHeight;
    [SerializeField] public GameObject player;
    private Transform playerTarget;

    private void Awake()
    {
        playerTarget = player.transform;
    }
    void Update()
    {

        // Move our position a step closer to the target.
        var step = runSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, step);
    }
}
