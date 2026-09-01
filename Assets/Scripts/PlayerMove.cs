using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D playerRB;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 3f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        playerRB.linearVelocity = moveInput * moveSpeed;
    }
}
