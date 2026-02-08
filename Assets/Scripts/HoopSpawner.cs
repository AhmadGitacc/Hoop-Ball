using UnityEngine;

public class HoopSpawner : MonoBehaviour
{
    public GameObject hoop;
    public float timer;
    public float spawnRate;
    public float offset = 3f;

    void Start()
    {
        spawnRate = MenuManagerScript.spawnRate;
        SpawnHoop();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnHoop();
            timer = 0;
        }
    }

    void SpawnHoop()
    {
        float lowestPoint = transform.position.y - offset;
        float highestPoint = transform.position.y + offset;

        Instantiate(hoop, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }
}
