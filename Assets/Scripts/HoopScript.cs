using UnityEngine;

public class HoopScript : MonoBehaviour
{
    public float moveSpeed = 1;
    public float deadZone = -2.5f;
    public LogicManagerScript logic;
    public GameObject heartPowerUp;
    public int spawnChance = 50;

    void Start()
    {
        int roll = Random.Range(1, 100);

        if (roll < spawnChance)
        {
            heartPowerUp.SetActive(true);
        }
        else
        {
            heartPowerUp.SetActive(false);
        }

        moveSpeed = DifficultyScript.hoopSpeed;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    void Update()
    {
        MoveHoop();
    }

    void MoveHoop()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
            logic.reduceHealth();
        }
    }
}
