using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    public float jumpStrength;
    public Rigidbody2D ballRigidBody;
    public LogicManagerScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && logic.isAlive)
        {
            ballRigidBody.linearVelocity = Vector2.up * jumpStrength;
            transform.rotation = Quaternion.Euler(0, 0, 40f);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 5f);
    }
}
