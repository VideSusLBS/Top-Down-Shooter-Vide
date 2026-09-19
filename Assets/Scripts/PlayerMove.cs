using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D playerRB;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float rotationSpeed = 700f;
    [SerializeField] float bulletSpeed = 7f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gun;

    float targetAngle;

    void Start()    
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnAttack()
    {
        Rigidbody2D currentBullet = Instantiate(bullet, gun.transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        currentBullet.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    void Update()
    {
        playerRB.linearVelocity = moveInput * moveSpeed;
        if (moveInput != Vector2.zero)
        {
            targetAngle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
        }
        
    }

    void FixedUpdate()
    {
        float rotation = Mathf.MoveTowardsAngle(playerRB.rotation, targetAngle - 90, rotationSpeed * Time.fixedDeltaTime);
        playerRB.MoveRotation(rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
