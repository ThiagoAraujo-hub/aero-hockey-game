using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private readonly float MaxSpeed = 15f;
    private readonly float MinSpeed = 0.1f;
    private readonly float DislodgeForce = 0.5f;

    void GoBall()
    {
        float rand = Random.Range(0, 4);

        if (rand < 1)
            rb2d.AddForce(new Vector2(30, -20));
        else if (rand < 2)
            rb2d.AddForce(new Vector2(-30, 20));
        else if (rand < 3)
            rb2d.AddForce(new Vector2(30, 20));
        else
            rb2d.AddForce(new Vector2(-30, -20));
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke(nameof(GoBall), 1);
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player1") || collision.collider.CompareTag("Player2"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = rb2d.velocity.y;

            if (vel.magnitude > MaxSpeed)
                vel = vel.normalized * MaxSpeed;
            else if (vel.magnitude < MinSpeed)
                vel = vel.normalized * MinSpeed;

            if (IsStuckInCorner())
                rb2d.AddForce(DislodgeForce * -rb2d.velocity.normalized, ForceMode2D.Impulse);

            rb2d.velocity = vel;
        }
    }

    bool IsStuckInCorner()
    {
        Vector2 diskPosition = rb2d.position;

        float xFieldSize = 14f;
        float yFieldSize = 8.2f;

        float distanceToTopLeftCorner = (diskPosition - new Vector2(-xFieldSize / 2, yFieldSize / 2)).magnitude;
        float distanceToTopRightCorner = (diskPosition - new Vector2(xFieldSize / 2, yFieldSize / 2)).magnitude;
        float distanceToBottomLeftCorner = (diskPosition - new Vector2(-xFieldSize / 2, -yFieldSize / 2)).magnitude;
        float distanceToBottomRightCorner = (diskPosition - new Vector2(xFieldSize / 2, -yFieldSize / 2)).magnitude;

        float cornerThreshold = 0.1f;

        return (
            distanceToTopLeftCorner < cornerThreshold ||
            distanceToTopRightCorner < cornerThreshold ||
            distanceToBottomLeftCorner < cornerThreshold ||
            distanceToBottomRightCorner < cornerThreshold
        );
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke(nameof(GoBall), 1);
    }

}
