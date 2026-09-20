using System;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D enemyRb;
    Transform playerLoc;
    Vector2 direction;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        playerLoc = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (playerLoc != null)
        {
            direction = (playerLoc.position - transform.position).normalized;
        }
    }

    void FixedUpdate()
    {
        if (playerLoc != null)
        {
            enemyRb.MovePosition(enemyRb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
