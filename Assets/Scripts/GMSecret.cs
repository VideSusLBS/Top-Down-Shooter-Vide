using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GMSecret : MonoBehaviour
{
    Rigidbody2D gm;
    [SerializeField]Transform GMOtherPos;
    Vector2 direction;
    
    void Start()
    {
        gm = GetComponent<Rigidbody2D>();
        direction = (GMOtherPos.position - transform.position);
    }

    void Update()
    {
        Invoke("stupid", 1.0f);
    }

    void stupid()
    {
        if (Random.Range(0, 10001) <= 100)
        {
            gm.MovePosition(gm.position + direction * 40 * Time.fixedDeltaTime);
        }
    }
}
