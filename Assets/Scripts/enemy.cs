using System;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D enemyRb;

    [SerializeField] Transform playerLoc;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = (playerLoc.position - transform.position).normalized;
        enemyRb.MovePosition(enemyRb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
