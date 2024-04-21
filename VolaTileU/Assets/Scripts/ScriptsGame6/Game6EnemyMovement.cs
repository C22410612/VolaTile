using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 8.0f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = Game6Manager.main.path[pathIndex];
    }

    private void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if(pathIndex == Game6Manager.main.path.Length)
            {
                Game6Spawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }

            else
            {
                target = Game6Manager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
}