using UnityEngine;

public class HoopTriggerScript : MonoBehaviour
{
    public LogicManagerScript logic;
    public GameObject hoop;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
            Destroy(hoop);
        }
    }
}
