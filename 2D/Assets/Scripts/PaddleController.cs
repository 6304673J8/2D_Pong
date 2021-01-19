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

    //AI
    public GameObject Ball;
    private Transform aiPaddle;
    private float aiDirection = 1f;
    public float aiSpeed = 1.75f;
    public float topBound = 1f;
    public float bottomBound = -1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        aiPaddle = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;
        KeyCode upButton = KeyCode.None;
        KeyCode downButton = KeyCode.None;

        switch (controller)
        {
            default: break;
            case Controller.PLAYER1:
                upButton = KeyCode.W;
                downButton = KeyCode.S;
                break;
            case Controller.PLAYER2:
                upButton = KeyCode.UpArrow;
                downButton = KeyCode.DownArrow;
                break;
            //case Controller.AI:
                
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
        } else if (direction == Direction.DOWN)
        {
            currentSpeedV = -baseSpeed;
        }
        if (controller == Controller.AI)
        {
            if (Ball.transform.position.y > aiPaddle.position.y)
            {
                if (rigidBody.velocity.y < 0)
                {
                    rigidBody.velocity = Vector2.zero;
                }
                rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.up * aiSpeed, aiDirection * Time.deltaTime);
            }
            else if (Ball.transform.position.y < transform.position.y)
            {
                if (rigidBody.velocity.y > 0) rigidBody.velocity = Vector2.zero;
                rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.down * aiSpeed, aiDirection * Time.deltaTime);
            }
            else
            {
                rigidBody.velocity = Vector2.Lerp(rigidBody.velocity, Vector2.zero * aiSpeed, aiDirection * Time.deltaTime);
            }
        }
    }
    /*private void aiLogic()
    {
        aiPaddle = this.transform;
        if (aiPaddle.position.x < Ball.transform.position.x)
        {
            if (aiPaddle.position.y < Ball.transform.position.y)
            {
                rigidBody.velocity = new Vector2(0, 1) * aiSpeed;
            }
            else if (aiPaddle.position.y > Ball.transform.position.y)
            {
                rigidBody.velocity = new Vector2(0, -1) * aiSpeed;
            }
            else
            {
                rigidBody.velocity = new Vector2(0, 0) * aiSpeed;
            }
        }
    }*/
}
    /*private void aiLogic() 
    {
        float delta = Time.fixedDeltaTime;
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
        ballRigidBody = ball.GetComponent<Rigidbody2D>();
        aiDirection = ball.position.y - transform.position.y;
        if (ballRigidBody.velocity.x < 0)
        {
            if (aiDirection > 0)
            {
                move.y = aiSpeed * Mathf.Min(aiDirection, 1.0f);
            }
            if (aiDirection < 0)
            {
                move.y = -(aiSpeed * Mathf.Min(-aiDirection, 1.0f));
            }
            transform.position += move * delta;
        }
    }*/