using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D playerRB;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float bulletSpeed = 7f;
    [SerializeField] GameObject bullet;

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
        Rigidbody2D currentBullet = Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        currentBullet.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    void Update()
    {
        playerRB.linearVelocity = moveInput * moveSpeed;
    }
}
