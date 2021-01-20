using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public GameObject player1Points;
    public GameObject player2Points;
    private int player1Score = 0;
    private int player2Score = 0;

    public float baseSpeed = 0.4f;
    public float maxSpeed = 1.5f;
    public float bounceSpeed = 0.1f;
    public float margin = 0.2f;


    public float currentSpeedH = 0;
    private float currentSpeedV = 0;
    private Rigidbody2D rigidBody;
    public Text scoreBoard_P1, scoreBoard_P2;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        float rand = Random.Range(0.0f, 1.0f);
        if (rand < 0.5)
        {
            currentSpeedH = -baseSpeed;
        }
        else
        {
            currentSpeedH = baseSpeed;
        }
    }

<<<<<<< Updated upstream
    // Update is called once per frame
    void Update()
    {
    }
=======

>>>>>>> Stashed changes

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;
        rigidBody.velocity = new Vector2(currentSpeedH, currentSpeedV) * delta;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Paddle")
        {
            //if (currentSpeedH < maxSpeed)
            //{
               // baseSpeed += bounceSpeed;
                currentSpeedH += -bounceSpeed;
                currentSpeedH = -1 * currentSpeedH;
                float ballY = transform.position.y;
                float paddleY = collision.collider.bounds.center.y;
                float paddleH = collision.collider.bounds.size.y;
                if (ballY < paddleY - (paddleH / 2) * margin)
                {
                    currentSpeedV = -baseSpeed;
                }
                else if (ballY > paddleY + (paddleH / 2) * margin)
                {
                    currentSpeedV = baseSpeed;
                }
                else
                {
                    currentSpeedV = 0;
                }
            //}
        }else if (collision.gameObject.tag == "Wall")
        {
            currentSpeedV = -1 * currentSpeedV;

        }else if (collision.gameObject.tag == "Goal")
        {
            transform.position = new Vector3(0,0,1);

            currentSpeedH = -Mathf.Sign(currentSpeedH) * baseSpeed;
            currentSpeedV = -Mathf.Sign(currentSpeedV) * baseSpeed;

            float goalX = collision.transform.position.x;
            
            int score = 0;
            if(goalX < 0) //P2 Scores
            {
                player2Score++;
                scoreBoard_P2.text = player2Score.ToString();
                score = player2Score;
            }
            else
            {
                player1Score++;
                scoreBoard_P1.text = player1Score.ToString();
                score = player1Score;
            }
        }
    }
}
