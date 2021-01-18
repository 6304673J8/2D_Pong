using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public enum Controller { NONE, PLAYER1, PLAYER2, AI };
    public enum Direction { NONE, UP, DOWN };

    public Controller controller = Controller.NONE;
    private Direction direction = Direction.NONE;
    
    public float baseSpeed = 0.3f;
    private float currentSpeedV = 0.0f;
    private Rigidbody2D rigidBody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;
        KeyCode upButton = KeyCode.None;
        KeyCode downButton = KeyCode.None;

        switch (controller)
        {
            default:break;
            case Controller.PLAYER1:
                upButton = KeyCode.W;
                downButton = KeyCode.S;
                break;
            case Controller.PLAYER2:
                upButton = KeyCode.UpArrow;
                downButton = KeyCode.DownArrow;
                break;
        }
        direction = Direction.NONE;
        if (upButton != KeyCode.None && downButton != KeyCode.None)
        {
            if (Input.GetKey(upButton))
            {
                direction = Direction.UP;
            }
            else if (Input.GetKey(downButton))
            {
                direction = Direction.DOWN;
            }
        }
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;
        currentSpeedV = 0;
        if (direction == Direction.UP)
        {
            currentSpeedV = baseSpeed;
        }else if (direction == Direction.DOWN)
        {
            currentSpeedV = -baseSpeed;
        }
        rigidBody.velocity = new Vector2(0, currentSpeedV * delta);
    }
}
