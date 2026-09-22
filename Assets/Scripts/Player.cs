using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRB;

    GameObject[] hearts = new GameObject[3];

    Vector2 moveInput;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float rotationSpeed = 700f;
    [SerializeField] float bulletSpeed = 7f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gun;
    [SerializeField] int health = 3;
    [SerializeField] float invincibilityTimer = 2f;
    bool Invincible = false;
    //public bool playerAlive = true;
    Vector2 screenBoundary;

    float targetAngle;

    void Start()    
    {
        playerRB = GetComponent<Rigidbody2D>();
        screenBoundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        hearts[0] = GameObject.Find("heart_1");
        hearts[1] = GameObject.Find("heart_2");
        hearts[2] = GameObject.Find("heart_3");
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

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBoundary.x, screenBoundary.x),
                                         Mathf.Clamp(transform.position.y, -screenBoundary.y, screenBoundary.y));
    }

    void FixedUpdate()
    {
        float rotation = Mathf.MoveTowardsAngle(playerRB.rotation, targetAngle - 90, rotationSpeed * Time.fixedDeltaTime);
        playerRB.MoveRotation(rotation);
    }

    void ResetInvincibility()
    {
        Invincible = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !Invincible)
        {
            health--;
            Debug.Log($"Health: {health}");
            if (health == 0)
            {
                //playerAlive = false;
                Destroy(gameObject);
                GameObject.Destroy(hearts[0]);
                Invoke("bye", 2);
            }
            else
            {
                Invincible = true;
                Invoke("ResetInvincibility", invincibilityTimer);
                GameObject.Destroy(hearts[health]);
            }
        }
    }

    void bye()
    {
        Application.Quit();
        Debug.Log("Bye!");
    }
}
