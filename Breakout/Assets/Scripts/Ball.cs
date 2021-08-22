using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;

    bool ballReleased = false;
    Rigidbody2D rigidBody;
    float randomTweak = 0.5f;
    Vector2 paddleToBallVector;
    float xPush = 0.2f;
    float yPush = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ballReleased)
        {
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
        }

        if(Input.GetMouseButtonDown(0))
        {
            rigidBody.velocity = new Vector2(xPush, yPush);
            ballReleased = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0, randomTweak), Random.Range(0, randomTweak));
        rigidBody.velocity += velocityTweak;
    }
}
