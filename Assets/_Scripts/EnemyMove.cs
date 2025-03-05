using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Stats")]
    [SerializeField] private float moveSpeed = 2.0f;

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = GameManager.main.path[pathIndex];
    }
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            

            if (pathIndex == GameManager.main.path.Length)
            {
                EnemySpawner.onEnemyDeath.Invoke();
                Debug.Log("Player Loses 1 Health!");
                Destroy(gameObject);
                return;
                
            } 
            else
            {
                target = GameManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }

}
