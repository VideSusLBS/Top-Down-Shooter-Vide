using UnityEngine;

public class HealthMan : MonoBehaviour
{
    int i;
    
    [SerializeField]int startingHealth = 3;
    int health;
    [SerializeField]GameObject heart;
    Vector3 createPosition = new Vector3 (-7.81f, 4.1f, 0f);
    Vector3 createDifference = new Vector3(-1.635f, 0f, 0f);
    GameObject[] currentHearts;

    [SerializeField]AudioSource ded;
    [SerializeField] GameObject gameOver;

    void Start()
    {
        currentHearts = new GameObject[startingHealth];
        health = startingHealth;

        while (i < startingHealth)
        {
            currentHearts[i] = Instantiate(heart, createPosition - createDifference * i, Quaternion.identity);
            i++;
        }
    }

    public void takeDamage()
    {
        GameObject.Destroy(currentHearts[health - 1]);
        health--;
        if (health <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            ded.Play();
            gameOver.SetActive(true);
        }
    }
}
